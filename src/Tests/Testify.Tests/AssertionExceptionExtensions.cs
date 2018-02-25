﻿using System;
using System.Collections.Generic;
using System.Linq;
using static Testify.Assertions;

namespace Testify
{
    internal static class AssertionExceptionExtensions
    {
        internal static void ExpectMessage(this AssertionException exception, string message)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (!exception.Message.StartsWith(message))
            {
                Fail("Unexpected message: '{0}'. Expected message: '{1}'.", exception.Message, message);
            }
        }

        internal static void ExpectInnerAssertion(this AssertionException exception, string message)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var stack = new Stack<AssertionException>();
            stack.Push(exception);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                foreach (var inner in current.InnerExceptions)
                {
                    if (inner.Message.StartsWith(message))
                    {
                        return;
                    }

                    if (inner is AssertionException toAdd)
                    {
                        stack.Push(toAdd);
                    }
                }
            }

            Fail("Inner assertion not found. Message: {0}", message);
        }
    }
}