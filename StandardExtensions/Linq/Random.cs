using System;
using System.Linq;
using System.Collections.Generic;

namespace StandardExtensions
{
	public static partial class LinqEx
	{
		public static IEnumerable<T> WeightedSample<T>(this IEnumerable<T> source, Func<T, int> weightedSelector) 
		{
			return WeightedSampleCore (source.OrderByDescending(weightedSelector).ToArray(), weightedSelector);
		}

		static IEnumerable<T> WeightedSampleCore<T>(T[] source, Func<T, int> weightedSelector) 
		{
			var left = 1;
			var right = source.Length-1;
			var middle = (left + right) / 2;
			var pivot = weightedSelector(source[_rnd.Next (right)]);

			while (true) {
				if (middle == 1)
					middle++;

				if (weightedSelector (source[middle]) > pivot) {
					right = middle - 2;
					if (right < left)
						yield return source [middle - 1];
				} else {
					left = middle + 2;
					if (left > right)
						yield return source [middle + 1];
				}
				middle = (left + right) / 2;
			}
		}
			
		private static Random _rnd = new Random(); 
		public static T WeightedRandom<T>(this IEnumerable<T> source, Func<T, int> selector)
		{
			var totalWeight = source.Sum(x => selector(x));
			var baseWeight = _rnd.Next(0, totalWeight);
			var currentWeight = 0;
			return source.FirstOrDefault(x =>
				{
					currentWeight += selector(x);
					return currentWeight > baseWeight;
				});
		}
	}
}

