using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpLinearAlgebra;

namespace UnitTests
{
    [TestClass]
    public class MatCoreTest
    {
        [TestMethod]
        public void TestMatCreation()
        {
            // Create 3 x 6 matrix.
            VecCollection collection1 = new VecCollection(6, new Vec[]
            {
                new Vec(6),
                new Vec(6),
                new Vec(6),  
            });
            var matArray = new Mat[]
            {
                new Mat(4), // Create 4x4 matrix.
                new Mat(collection1), // Create 3x6 matrix.
                new Mat(2,3) // Create 2x3 matrix.
            };


            Assert.AreEqual(new MatSize(4, 4), matArray[0].Size);
            Assert.AreEqual(new MatSize(3, 6), matArray[1].Size);
            Assert.AreEqual(new MatSize(2, 3), matArray[2].Size);

            matArray[0][0][0] = 5;

            Assert.AreEqual(5, matArray[0][0][0]);
        }
    }
}
