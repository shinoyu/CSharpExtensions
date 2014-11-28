using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using StandardExtensions;

namespace StandardExtensions.Test
{
	[TestFixture ()]
	public class LinqEx_RandomText
	{
		[Test ()]
		public void TestCase ()
		{
			var source = new[] { 
				Tuple.Create("a", 2), Tuple.Create("b", 3), Tuple.Create("c", 5)
			};
			var aCount = 0;
			var bCount = 0;
			var cCount = 0;

			foreach (var i in Enumerable.Range(0, 1000000))
			{
				var item = source.WeightedRandom (x => x.Item2);
				if (item.Item1 == "a")
					aCount++;
				else if (item.Item1 == "b")
					bCount++;
				else if (item.Item1 == "c")
					cCount++;
			}
			Console.WriteLine("a:" + aCount.ToString());
			Console.WriteLine("b:" + bCount.ToString());
			Console.WriteLine("c:" + cCount.ToString());

			aCount = 0;
			bCount = 0;
			cCount = 0;
			foreach (var i in Enumerable.Range(0, 1000000))
			{
				var item = source.WeightedSample(x => x.Item2).First();
				if (item.Item1 == "a")
					aCount++;
				else if (item.Item1 == "b")
					bCount++;
				else if (item.Item1 == "c")
					cCount++;

			}
			Console.WriteLine("a:" + aCount.ToString());
			Console.WriteLine("b:" + bCount.ToString());
			Console.WriteLine("c:" + cCount.ToString());

		}
	}
}

