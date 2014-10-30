using NUnit.Framework;
using System;
using System.Linq;
using StandardExtensions;

namespace StandardExtensions.Test
{
	[TestFixture ()]
	public class LinqExTest
	{
		public struct Structure{
			public string Member1 { get ; set; }
			public int Member2 { get; set; }
		}

		[Test()]
		public void DistinctByTest() {
			var datas = 10.Times ().Select (i => new Structure{ Member1 = 1.ToString(), Member2 = i });

			Assert.AreEqual(1, datas.DistinctBy (x => x.Member1).Count());
			Assert.AreEqual(10, datas.DistinctBy (x => x.Member2).Count());
		}
	}
}

