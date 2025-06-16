using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator_V1.BusinessLogic;

namespace Calculator_V1.Tests
{
    [TestClass]
    public class ComputeServiceTests
    {
        private ComputeService _engine; // engine = old name (engineService) nowadays known as ComputeService

        [TestInitialize]
        public void Setup()
        {
            _engine = new ComputeService();
        }

        [TestMethod]
        public void Compute_Adds_TwoNumbers()
        {
            double result = _engine.Compute(5, 7, "+");
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Compute_Subtracts_TwoNumbers()
        {
            double result = _engine.Compute(10, 3, "-");
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Compute_Multiplies_TwoNumbers()
        {
            double result = _engine.Compute(4, 2.5, "*");
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Compute_Divides_TwoNumbers()
        {
            double result = _engine.Compute(9, 3, "/");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Compute_DivideByZero_Throws()
        {
            _engine.Compute(5, 0, "/");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Compute_InvalidOperation_Throws()
        {
            _engine.Compute(1, 1, "%");
        }
    }
}
