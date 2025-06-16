using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Calculator_V1.BusinessLogic;
using Calculator_V1.DataAccess;
using Calculator_V1.Models;

namespace Calculator_V1.Tests
{
    [TestClass]
    public class CalculationServiceTests
    {
        private Mock<IDataAccess> _mockDal;
        private CalculationService _service;
        private ComputeService _engine;

        [TestInitialize]
        public void Setup()
        {
            // 1) create a mock IDataAccess
            _mockDal = new Mock<IDataAccess>();

            // 2) optional: set up LoadHistory to return an empty list by default
            _mockDal
                .Setup(dal => dal.LoadHistory(It.IsAny<int>()))
                .Returns(new List<Calculation>());

            // 3) create your engine and service under test
            _engine = new ComputeService();
            _service = new CalculationService(_mockDal.Object, _engine);
        }

        [TestMethod]
        public void Calculate_Calls_InsertAndDelete_NoRounding()
        {
            // act
            var calc = _service.Calculate(2, 3, "+", roundResult: false);

            // assert result correctness
            Assert.AreEqual(5, calc.Result);

            // verify InsertCalculation was called exactly once with a Calculation whose Result = 5
            _mockDal.Verify(dal =>
                dal.InsertCalculation(It.Is<Calculation>(c => c.Result == 5)),
                Times.Once);

            // verify pruning was called once
            _mockDal.Verify(dal => dal.DeleteOldRecords(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void Calculate_Rounds_Result_WhenRequested()
        {
            // act: 2.3 + 2.3 = 4.6 → rounded to 5
            var calc = _service.Calculate(2.3, 2.3, "+", roundResult: true);

            // assert rounding
            Assert.AreEqual(Math.Round(4.6), calc.Result);

            // still persisted
            _mockDal.Verify(dal => dal.InsertCalculation(It.IsAny<Calculation>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculate_DivideByZero_Throws()
        {
            // act → should throw before any data-access calls
            _service.Calculate(5, 0, "/", roundResult: false);
        }
    }
}

