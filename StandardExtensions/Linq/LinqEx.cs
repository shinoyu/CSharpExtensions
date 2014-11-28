using System;
using System.Collections.Generic;

using System.Linq;

namespace StandardExtensions
{
	public static partial class LinqEx
	{
		/// <summary>
		/// Foreach the specified source and action.
		/// </summary>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static void Foreach<T>(this IEnumerable<T> source, Action<T> action) {
			foreach (var item in source)
				action (item);
		}

		/// <summary>
		/// Times the specified size.
		/// </summary>
		public static IEnumerable<int> Times(this int size) {
			for (var i = 0; i < size; i++) {
				yield return i;
			}
		}

		/// <summary>
		/// Distincts the by.
		/// </summary>
		/// <returns>The by.</returns>
		/// <param name="source">Source.</param>
		/// <param name="selector">Selector.</param>
		public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector) {
			return source.Distinct (new SelectorComparer<T, TKey> (selector));
		}

		/// <summary>
		/// Excepts the by.
		/// </summary>
		/// <returns>The by.</returns>
		/// <param name="first">First.</param>
		/// <param name="second">Second.</param>
		/// <param name="selector">Selector.</param>
		public static IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> first,  IEnumerable<T> second, Func<T,TKey> selector) {
			return first.Except (second, new SelectorComparer<T,TKey> (selector));
		}
			
		internal class SelectorComparer<T, TKey> : IEqualityComparer<T>
		{
			Func<T, TKey> _selector;
			public SelectorComparer(Func<T, TKey> selector) {
				_selector = selector;
			}
			public bool Equals(T x, T y)
			{
				return _selector(x).Equals(_selector(y));
			}
			public int GetHashCode(T obj)
			{
				return _selector(obj).GetHashCode();
			}
		}
	}
}

