﻿using System;
using System.Linq;
using Testify;
using Xunit;
using static Testify.Assertions;

namespace Examples.Assertions
{
    public static class CustomStringAssertion
    {
        public static void IsLower(this ActualValue<string> actual)
        {
            if (actual == null)
            {
                throw new ArgumentNullException(nameof(actual));
            }

            actual.IsLower(null, null);
        }

        public static void IsLower(this ActualValue<string> actual, string message)
        {
            if (actual == null)
            {
                throw new ArgumentNullException(nameof(actual));
            }

            actual.IsLower(message, null);
        }

        public static void IsLower(
            this ActualValue<string> actual,
            string message,
            params object[] args)
        {
            if (actual == null)
            {
                throw new ArgumentNullException(nameof(actual));
            }

            if (!actual.Value.All(c => !char.IsLetter(c) || char.IsLower(c)))
            {
                Throw(
                   nameof(IsLower),
                   $"{actual.Value} is not all lowercase.",
                   message,
                   args);
            }
        }
    }

    public class CustomAssertionExample
    {
        [Fact]
        public void String_ToLower_ShouldReturnLowercaseString()
        {
            const string original = "The Quick Brown Fox";

            var result = original.ToLower();

            Assert(result).IsLower();
        }
    }
}