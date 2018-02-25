﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Testify.Properties;
using static Testify.Assertions;
using static Testify.FrameworkMessages;

namespace Testify
{
    /// <summary>
    /// Provides assertion methods associated with strings in unit tests.
    /// </summary>
    public static class CollectionAssertions
    {
        /// <summary>
        /// Verifies that the elements in the specified collection are instances of the specified type.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to verify.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of every
        /// element in.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or
        /// <paramref name="expectedType"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">Not all items in the collection were of the specified
        /// type.</exception>
        public static void AllItemsAreInstancesOfType<T>(this ActualValue<T> collection, Type expectedType)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expectedType, nameof(expectedType));

            collection.AllItemsAreInstancesOfType(expectedType, null, null);
        }

        /// <summary>
        /// Verifies that the elements in the specified collection are instances of the specified type.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to verify.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of every
        /// element in.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or
        /// <paramref name="expectedType"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">Not all items in the collection were of the specified
        /// type.</exception>
        public static void AllItemsAreInstancesOfType<T>(
            this ActualValue<T> collection,
            Type expectedType,
            string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expectedType, nameof(expectedType));

            collection.AllItemsAreInstancesOfType(expectedType, message, null);
        }

        /// <summary>
        /// Verifies that the elements in the specified collection are instances of the specified type.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to verify.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of every
        /// element in.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or
        /// <paramref name="expectedType"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">Not all items in the collection were of the specified
        /// type.</exception>
        public static void AllItemsAreInstancesOfType<T>(
            this ActualValue<T> collection,
            Type expectedType,
            string message,
            params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expectedType, nameof(expectedType));

            var index = 0;
            foreach (var item in collection.Value)
            {
                if (!expectedType.IsInstanceOfType(item))
                {
                    Throw(
                        nameof(AllItemsAreInstancesOfType),
                        UnexpectedTypeAt(index, expectedType, item.GetType()),
                        message,
                        parameters);
                }

                ++index;
            }
        }

        /// <summary>
        /// Verifies that all items in the specified collection are not <see langword="null"/>. Displays a message if
        /// the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for elements that are <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is
        /// <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were <see langword="null"/>.</exception>
        public static void AllItemsAreNotNull<T>(this ActualValue<T> collection)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.AllItemsAreNotNull(null, null);
        }

        /// <summary>
        /// Verifies that all items in the specified collection are not <see langword="null"/>. Displays a message if
        /// the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for elements that are <see langword="null"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is
        /// <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were <see langword="null"/>.</exception>
        public static void AllItemsAreNotNull<T>(this ActualValue<T> collection, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.AllItemsAreNotNull(message, null);
        }

        /// <summary>
        /// Verifies that all items in the specified collection are not <see langword="null"/>. Displays a message if
        /// the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for elements that are <see langword="null"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is
        /// <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were <see langword="null"/>.</exception>
        public static void AllItemsAreNotNull<T>(
            this ActualValue<T> collection,
            string message,
            params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            foreach (var item in collection.Value)
            {
                if (item == null)
                {
                    Throw(
                        nameof(AllItemsAreNotNull),
                        null,
                        message,
                        parameters);
                }
            }
        }

        /// <summary>
        /// Verifies that all items in the specified collection are unique. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is
        /// <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were not unique.</exception>
        public static void AllItemsAreUnique<T>(this ActualValue<T> collection)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.AllItemsAreUnique(EqualityComparer<object>.Default, null, null);
        }

        /// <summary>
        /// Verifies that all items in the specified collection are unique. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or
        /// <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were not unique.</exception>
        public static void AllItemsAreUnique<T>(this ActualValue<T> collection, IEqualityComparer comparer)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            collection.AllItemsAreUnique(comparer, null, null);
        }

        /// <summary>
        /// Verifies that all items in the specified collection are unique. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is
        /// <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were not unique.</exception>
        public static void AllItemsAreUnique<T>(this ActualValue<T> collection, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.AllItemsAreUnique(EqualityComparer<object>.Default, message, null);
        }

        /// <summary>
        /// Verifies that all items in the specified collection are unique. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were not unique.</exception>
        public static void AllItemsAreUnique<T>(this ActualValue<T> collection, IEqualityComparer comparer, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            collection.AllItemsAreUnique(comparer, message, null);
        }

        /// <summary>
        /// Verifies that all items in the specified collection are unique. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were not unique.</exception>
        public static void AllItemsAreUnique<T>(this ActualValue<T> collection, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.AllItemsAreUnique(EqualityComparer<object>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies that all items in the specified collection are unique. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">One or more items in the collection were not unique.</exception>
        public static void AllItemsAreUnique<T>(this ActualValue<T> collection, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            var nullFound = false;
            var found = new HashSet<object>(Comparer.From(comparer));
            foreach (var item in collection.Value)
            {
                if (item == null)
                {
                    if (!nullFound)
                    {
                        nullFound = true;
                    }
                    else
                    {
                        Throw(
                            nameof(AllItemsAreUnique),
                            DuplicateFound(item),
                            message,
                            parameters);
                    }
                }
                else
                {
                    if (!found.Add(item))
                    {
                        Throw(
                            "AllItemsAreUnique",
                            DuplicateFound(item),
                            message,
                            parameters);
                    }
                }
            }
        }

        /// <summary>
        /// Verifies that the specified collection contains the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection does not contain the specified element.</exception>
        public static void Contains<T, TElement>(this ActualValue<T> collection, TElement element)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.Contains(element, EqualityComparer<object>.Default, null, null);
        }

        /// <summary>
        /// Verifies that the specified collection contains the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection does not contain the specified element.</exception>
        public static void Contains<T, TElement>(this ActualValue<T> collection, TElement element, IEqualityComparer comparer)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            collection.Contains(element, comparer, null, null);
        }

        /// <summary>
        /// Verifies that the specified collection contains the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection does not contain the specified element.</exception>
        public static void Contains<T, TElement>(this ActualValue<T> collection, TElement element, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.Contains(element, EqualityComparer<object>.Default, message, null);
        }

        /// <summary>
        /// Verifies that the specified collection contains the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection does not contain the specified element.</exception>
        public static void Contains<T, TElement>(this ActualValue<T> collection, TElement element, IEqualityComparer comparer, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            collection.Contains(element, comparer, message, null);
        }

        /// <summary>
        /// Verifies that the specified collection contains the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection does not contain the specified element.</exception>
        public static void Contains<T, TElement>(this ActualValue<T> collection, TElement element, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.Contains(element, EqualityComparer<object>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies that the specified collection contains the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection does not contain the specified element.</exception>
        public static void Contains<T, TElement>(this ActualValue<T> collection, TElement element, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            foreach (var item in collection.Value)
            {
                if (comparer.Equals(item, element))
                {
                    return;
                }
            }

            Throw(
                nameof(Contains),
                null,
                message,
                parameters);
        }

        /// <summary>
        /// Verifies that the specified collection does not contain the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection contains the specified element.</exception>
        public static void DoesNotContain<T, TElement>(this ActualValue<T> collection, TElement element)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.DoesNotContain(element, EqualityComparer<TElement>.Default, null, null);
        }

        /// <summary>
        /// Verifies that the specified collection does not contain the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection contains the specified element.</exception>
        public static void DoesNotContain<T, TElement>(this ActualValue<T> collection, TElement element, IEqualityComparer comparer)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            collection.DoesNotContain(element, comparer, null, null);
        }

        /// <summary>
        /// Verifies that the specified collection does not contain the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection contains the specified element.</exception>
        public static void DoesNotContain<T, TElement>(this ActualValue<T> collection, TElement element, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.DoesNotContain(element, EqualityComparer<TElement>.Default, message, null);
        }

        /// <summary>
        /// Verifies that the specified collection does not contain the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection contains the specified element.</exception>
        public static void DoesNotContain<T, TElement>(this ActualValue<T> collection, TElement element, IEqualityComparer comparer, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            collection.DoesNotContain(element, comparer, message, null);
        }

        /// <summary>
        /// Verifies that the specified collection does not contain the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection contains the specified element.</exception>
        public static void DoesNotContain<T, TElement>(this ActualValue<T> collection, TElement element, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));

            collection.DoesNotContain(element, EqualityComparer<TElement>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies that the specified collection does not contain the specified element. Displays a message if the assertion
        /// fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection contains the specified element.</exception>
        public static void DoesNotContain<T, TElement>(this ActualValue<T> collection, TElement element, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            foreach (var item in collection.Value)
            {
                if (comparer.Equals(item, element))
                {
                    Throw(nameof(DoesNotContain), null, message, parameters);
                }
            }
        }

        /// <summary>
        /// Verifies that two specified collections are equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are not equivalent.</exception>
        public static void IsEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsEquivalentTo(expected, EqualityComparer<object>.Default, null, null);
        }

        /// <summary>
        /// Verifies that two specified collections are equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are not equivalent.</exception>
        public static void IsEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            collection.IsEquivalentTo(expected, comparer, null, null);
        }

        /// <summary>
        /// Verifies that two specified collections are equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are not equivalent.</exception>
        public static void IsEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsEquivalentTo(expected, EqualityComparer<object>.Default, message, null);
        }

        /// <summary>
        /// Verifies that two specified collections are equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are not equivalent.</exception>
        public static void IsEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            collection.IsEquivalentTo(expected, comparer, message, null);
        }

        /// <summary>
        /// Verifies that two specified collections are equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are not equivalent.</exception>
        public static void IsEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsEquivalentTo(expected, EqualityComparer<object>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies that two specified collections are equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are not equivalent.</exception>
        public static void IsEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            if (object.ReferenceEquals(expected, collection.Value))
            {
                return;
            }

            var actualCollection = CollectionAssertions.GetCollection(collection.Value);
            var expectedCollection = CollectionAssertions.GetCollection(expected);
            if (expectedCollection.Count != actualCollection.Count)
            {
                Throw(nameof(IsEquivalentTo), null, message, parameters);
            }

            if (expectedCollection.Count == 0)
            {
                return;
            }

            var result = FindMismatchedElement(comparer, expectedCollection, actualCollection);
            if (result.found)
            {
                Throw(nameof(IsEquivalentTo), null, message, parameters);
            }
        }

        /// <summary>
        /// Verifies that two specified collections are not equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or
        /// <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are equivalent.</exception>
        public static void IsNotEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsNotEquivalentTo(expected, EqualityComparer<object>.Default, null, null);
        }

        /// <summary>
        /// Verifies that two specified collections are not equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are equivalent.</exception>
        public static void IsNotEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            collection.IsNotEquivalentTo(expected, comparer, null, null);
        }

        /// <summary>
        /// Verifies that two specified collections are not equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are equivalent.</exception>
        public static void IsNotEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsNotEquivalentTo(expected, EqualityComparer<object>.Default, message, null);
        }

        /// <summary>
        /// Verifies that two specified collections are not equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are equivalent.</exception>
        public static void IsNotEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            collection.IsNotEquivalentTo(expected, comparer, message, null);
        }

        /// <summary>
        /// Verifies that two specified collections are not equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are equivalent.</exception>
        public static void IsNotEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsNotEquivalentTo(expected, EqualityComparer<object>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies that two specified collections are not equivalent. Displays a message if the assertion fails, and
        /// applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <remarks>Two collections are equivalent if they have the same elements in the same quantity, but in any
        /// order.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collections are equivalent.</exception>
        public static void IsNotEquivalentTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            if (object.ReferenceEquals(expected, collection.Value))
            {
                Throw(nameof(IsNotEquivalentTo), null, message, parameters);
            }

            var expectedCollection = CollectionAssertions.GetCollection(expected);
            var actualCollection = CollectionAssertions.GetCollection(collection.Value);
            if (expectedCollection.Count != actualCollection.Count)
            {
                return;
            }

            var result = FindMismatchedElement(comparer, expectedCollection, actualCollection);
            if (result.found)
            {
                return;
            }

            Throw(nameof(IsNotEquivalentTo), null, message, parameters);
        }

        /// <summary>
        /// Verifies that two specified collections are not equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or
        /// <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsNotSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsNotSequenceEqualTo(expected, EqualityComparer<object>.Default, null, null);
        }

        /// <summary>
        /// Verifies that two specified collections are not equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsNotSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            collection.IsNotSequenceEqualTo(expected, comparer, null, null);
        }

        /// <summary>
        /// Verifies that two specified collections are not equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsNotSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsNotSequenceEqualTo(expected, EqualityComparer<object>.Default, message, null);
        }

        /// <summary>
        /// Verifies that two specified collections are not equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsNotSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            collection.IsNotSequenceEqualTo(expected, comparer, message, null);
        }

        /// <summary>
        /// Verifies that two specified collections are not equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsNotSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));

            collection.IsNotSequenceEqualTo(expected, EqualityComparer<object>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies that two specified collections are not equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsNotSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(comparer, nameof(comparer));

            var reason = string.Empty;
            var areEqual = CollectionAssertions.AreCollectionsEqual(
                CollectionAssertions.GetCollection(expected),
                CollectionAssertions.GetCollection(collection.Value),
                comparer,
                ref reason);
            if (!areEqual)
            {
                return;
            }

            Throw(nameof(IsNotSequenceEqualTo), CollectionNotEqualReason(reason), message, parameters);
        }

        /// <summary>
        /// Verifies that the specified collection is not a subset of another collection. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection not expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="collection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or
        /// <paramref name="superset"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsNotSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(superset, nameof(superset));

            collection.IsNotSubsetOf(superset, EqualityComparer<object>.Default, null, null);
        }

        /// <summary>
        /// Verifies that the specified collection is not a subset of another collection. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection not expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="superset"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsNotSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, IEqualityComparer comparer)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(superset, nameof(superset));
            Argument.NotNull(comparer, nameof(comparer));

            collection.IsNotSubsetOf(superset, comparer, null, null);
        }

        /// <summary>
        /// Verifies that the specified collection is not a subset of another collection. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection not expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or
        /// <paramref name="superset"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsNotSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(superset, nameof(superset));

            collection.IsNotSubsetOf(superset, EqualityComparer<object>.Default, message, null);
        }

        /// <summary>
        /// Verifies that the specified collection is not a subset of another collection. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection not expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="superset"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsNotSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, IEqualityComparer comparer, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(superset, nameof(superset));
            Argument.NotNull(comparer, nameof(comparer));

            collection.IsNotSubsetOf(superset, comparer, message, null);
        }

        /// <summary>
        /// Verifies that the specified collection is not a subset of another collection. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection not expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="superset"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsNotSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(superset, nameof(superset));

            collection.IsNotSubsetOf(superset, EqualityComparer<object>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies that the specified collection is not a subset of another collection. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection not expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="superset"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsNotSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull((object)collection.Value, nameof(collection));
            Argument.NotNull(superset, nameof(superset));
            Argument.NotNull(comparer, nameof(comparer));

            if (!CollectionAssertions.IsSubsetOfHelper(comparer, collection.Value, superset))
            {
                return;
            }

            Throw(nameof(IsNotSubsetOf), null, message, parameters);
        }

        /// <summary>
        /// Verifies that two specified collections are equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected)
            where T : IEnumerable =>
            collection.IsSequenceEqualTo(expected, EqualityComparer<object>.Default, null, null);

        /// <summary>
        /// Verifies that two specified collections are equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer)
            where T : IEnumerable =>
            collection.IsSequenceEqualTo(expected, comparer, null, null);

        /// <summary>
        /// Verifies that two specified collections are equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, string message)
            where T : IEnumerable =>
            collection.IsSequenceEqualTo(expected, EqualityComparer<object>.Default, message, null);

        /// <summary>
        /// Verifies that two specified collections are equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer, string message)
            where T : IEnumerable =>
            collection.IsSequenceEqualTo(expected, comparer, message, null);

        /// <summary>
        /// Verifies that two specified collections are equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="expected"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, string message, params object[] parameters)
            where T : IEnumerable =>
            collection.IsSequenceEqualTo(expected, EqualityComparer<object>.Default, message, parameters);

        /// <summary>
        /// Verifies that two specified collections are equal, using the specified method to compare the values
        /// of elements. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to compare. This is the collection the unit test produced.</param>
        /// <param name="expected">The collection to compare to. This is the collection the unit test expects.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="expected"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The collection sequences are equal.</exception>
        public static void IsSequenceEqualTo<T>(this ActualValue<T> collection, IEnumerable expected, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            var reason = string.Empty;
            var areEqual = CollectionAssertions.AreCollectionsEqual(
                CollectionAssertions.GetCollection(expected),
                CollectionAssertions.GetCollection(collection.Value),
                comparer,
                ref reason);
            if (areEqual)
            {
                return;
            }

            Throw(nameof(IsSequenceEqualTo), CollectionEqualReason(reason), message, parameters);
        }

        /// <summary>
        /// Verifies that the specified collection is a subset of another collection.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="collection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="superset"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull<IEnumerable>(collection.Value, "collection.Value");
            Argument.NotNull(superset, nameof(superset));

            collection.IsSubsetOf(superset, EqualityComparer<object>.Default, null, null);
        }

        /// <summary>
        /// Verifies that the specified collection is a subset of another collection.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="superset"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, IEqualityComparer comparer)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull<IEnumerable>(collection.Value, "collection.Value");
            Argument.NotNull(superset, nameof(superset));

            collection.IsSubsetOf(superset, comparer, null, null);
        }

        /// <summary>
        /// Verifies that the specified collection is a subset of another collection. Displays a message if the
        /// assertion fails.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="superset"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull<IEnumerable>(collection.Value, "collection.Value");
            Argument.NotNull(superset, nameof(superset));

            collection.IsSubsetOf(superset, EqualityComparer<object>.Default, message, null);
        }

        /// <summary>
        /// Verifies that the specified collection is a subset of another collection. Displays a message if the
        /// assertion fails.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="superset"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, IEqualityComparer comparer, string message)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull<IEnumerable>(collection.Value, "collection.Value");
            Argument.NotNull(superset, nameof(superset));

            collection.IsSubsetOf(superset, comparer, message, null);
        }

        /// <summary>
        /// Verifies that the specified collection is a subset of another collection. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value) or <paramref name="superset"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull<IEnumerable>(collection.Value, "collection.Value");
            Argument.NotNull(superset, nameof(superset));

            collection.IsSubsetOf(superset, EqualityComparer<object>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies that the specified collection is a subset of another collection. Displays a message if the
        /// assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection expected to be a subset of <paramref name="superset"/>.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="collection"/>.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can
        /// be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> (or it's value), <paramref name="superset"/> or <paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="AssertionException">The actual collection is a subset of the superset.</exception>
        public static void IsSubsetOf<T>(this ActualValue<T> collection, IEnumerable superset, IEqualityComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull<IEnumerable>(collection.Value, "collection.Value");
            Argument.NotNull(superset, nameof(superset));
            if (CollectionAssertions.IsSubsetOfHelper(comparer, collection.Value, superset))
            {
                return;
            }

            Throw(nameof(IsSubsetOf), null, message, parameters);
        }

        private static bool AreCollectionsEqual(ICollection expected, ICollection actual, IEqualityComparer comparer, ref string reason)
        {
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(actual, nameof(actual));
            Argument.NotNull(comparer, nameof(comparer));

            if (expected != actual)
            {
                if (expected.Count != actual.Count)
                {
                    reason = Resources.FrameworkMessage_NumberOfElementsDiff;
                    return false;
                }

                var expectedEnum = expected.GetEnumerator();
                var actualEnum = actual.GetEnumerator();
                var index = 0;
                while (expectedEnum.MoveNext() && actualEnum.MoveNext())
                {
                    if (!comparer.Equals(expectedEnum.Current, actualEnum.Current))
                    {
                        reason = FrameworkMessages.ElementsAtIndexDoNotMatch(index, expectedEnum.Current, actualEnum.Current);
                        return false;
                    }

                    ++index;
                }

                reason = Resources.FrameworkMessage_BothCollectionsSameElements;
                return true;
            }

            reason = Resources.FrameworkMessage_BothCollectionsSameReference;
            return true;
        }

        private static (bool found, int expectedCount, int actualCount, object mismatchedElement) FindMismatchedElement(IEqualityComparer comparer, ICollection expected, ICollection actual)
        {
            Argument.NotNull(comparer, nameof(comparer));
            Argument.NotNull(expected, nameof(expected));
            Argument.NotNull(actual, nameof(actual));

            var elementCounts1 = GetElementCounts(expected, comparer, out var nullCount1);
            var elementCounts2 = GetElementCounts(actual, comparer, out var nullCount2);
            if (nullCount2 != nullCount1)
            {
                return (true, nullCount1, nullCount2, null);
            }

            foreach (var key in elementCounts1.Keys)
            {
                elementCounts1.TryGetValue(key, out var expectedCount);
                elementCounts2.TryGetValue(key, out var actualCount);
                if (expectedCount != actualCount)
                {
                    return (true, expectedCount, actualCount, key);
                }
            }

            return (false, 0, 0, null);
        }

        private static ICollection GetCollection(IEnumerable collection)
        {
            Argument.NotNull(collection, nameof(collection));

            return collection as ICollection ?? collection.Cast<object>().ToArray();
        }

        private static Dictionary<object, int> GetElementCounts(IEnumerable collection, IEqualityComparer comparer, out int nullCount)
        {
            Argument.NotNull(collection, nameof(collection));
            Argument.NotNull(comparer, nameof(comparer));

            var dictionary = new Dictionary<object, int>(Comparer.From(comparer));
            nullCount = 0;
            foreach (var key in collection)
            {
                if (key == null)
                {
                    ++nullCount;
                }
                else
                {
                    dictionary.TryGetValue(key, out int num);
                    ++num;
                    dictionary[key] = num;
                }
            }

            return dictionary;
        }

        private static bool IsSubsetOfHelper(IEqualityComparer comparer, IEnumerable subset, IEnumerable superset)
        {
            Argument.NotNull(comparer, nameof(comparer));
            Argument.NotNull(subset, nameof(subset));
            Argument.NotNull(superset, nameof(superset));

            var elementCounts1 = CollectionAssertions.GetElementCounts(subset, comparer, out int nullCount1);
            var elementCounts2 = CollectionAssertions.GetElementCounts(superset, comparer, out int nullCount2);
            if (nullCount1 > nullCount2)
            {
                return false;
            }

            foreach (var key in elementCounts1.Keys)
            {
                elementCounts1.TryGetValue(key, out int num1);
                elementCounts2.TryGetValue(key, out int num2);
                if (num1 > num2)
                {
                    return false;
                }
            }

            return true;
        }

        private class Comparer : IEqualityComparer<object>
        {
            private readonly IEqualityComparer comparer;

            private Comparer(IEqualityComparer comparer)
            {
                Argument.NotNull(comparer, nameof(comparer));

                this.comparer = comparer;
            }

            public static Comparer From(IEqualityComparer comparer) => new Comparer(comparer);

            public new bool Equals(object x, object y) => comparer.Equals(x, y);

            public int GetHashCode(object obj) => comparer.GetHashCode(obj);
        }
    }
}