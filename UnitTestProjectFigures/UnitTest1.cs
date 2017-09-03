using System;
using System.Collections.Generic;
using FindGetOutFigure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectFigures
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodNull()
        {
	        var result = GetElement(null, 4);
			Assert.AreEqual(result.Item1, false);
			Assert.AreEqual(result.Item2, null);
		}

		[TestMethod]
		public void TestMethodEmptyArray()
		{
			var result = GetElement(new int[]{}, 4);
			Assert.AreEqual(result.Item1, false);
			Assert.AreEqual(result.Item2, null);
		}

		[TestMethod]
		public void TestMethodSingleElementWrong()
		{
			var result = GetElement(new [] { 5 }, 4);
			Assert.AreEqual(result.Item1, false);
			Assert.AreEqual(result.Item2, null);
		}

		[TestMethod]
		public void TestMethodSingleElementRight()
		{
			var result = GetElement(new[] { 4 }, 4);
			Assert.AreEqual(result.Item1, true);
			Assert.AreEqual(result.Item2, 4);
		}

		[TestMethod]
		public void TestMethodManyElementWrong()
		{
			var result = GetElement(new[] { 5,2,3,54,6,3,5,7,5,3,3 }, 4);
			Assert.AreEqual(result.Item1, false);
			Assert.AreEqual(result.Item2, null);
		}

		[TestMethod]
		public void TestMethodManyElementRight()
		{
			var result = GetElement(new[] { 5, 2, 3, 54, 6, 4, 3, 5, 7, 5, 3, 3 }, 4);
			Assert.AreEqual(result.Item1, true);
			Assert.AreEqual(result.Item2, 4);
		}

		private Tuple<bool, int?> GetElement(IEnumerable<int> source, int valueToExtract)
	    {
		    var list = new ProccessListOfFigures(source);
		    var extractSuccess = list.ExtractFigure(valueToExtract);
		    var extracted = list.FindExtracted();
		    return new Tuple<bool, int?>(extractSuccess, extracted);
	    }
    }
}
