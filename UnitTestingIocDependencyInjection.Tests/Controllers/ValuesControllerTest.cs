using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using UnitTestingIocDependencyInjection.Business;
using UnitTestingIocDependencyInjection.Controllers;

namespace UnitTestingIocDependencyInjection.Tests.Controllers
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ValuesControllerTest
    {
        private Mock<IValues> _values;
        private ValuesController _target;
        private int _idToGet;
        private Exception _exceptionCaught;
        private Exception _exceptionThrown;
        private string _valueReturned;

        [TestInitialize]
        public void Initialize()
        {
            _values = new Mock<IValues>();
            _values.Setup(m => m.GetValueById(It.IsAny<int>())).Returns("a");

            _exceptionCaught = null;
            _exceptionThrown = new Exception("z");

            _idToGet = 1;

            _target = new ValuesController(_values.Object);
        }

        [TestMethod]
        public void GetByIdEverythingWorks()
        {
            RunGetById();

            Assert.AreEqual(_valueReturned, "a");
            Assert.AreEqual(_exceptionCaught, null);
            _values.Verify(m => m.GetValueById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetByIdThrowsException()
        {
            _values.Setup(m => m.GetValueById(It.IsAny<int>())).Throws(_exceptionThrown);

            RunGetById();

            Assert.AreNotEqual(_exceptionCaught, null);
            Assert.AreEqual(_exceptionCaught, _exceptionThrown);
            _values.Verify(m => m.GetValueById(It.IsAny<int>()), Times.Once);
        }

        private void RunGetById()
        {
            try
            {
                _valueReturned = _target.Get(_idToGet);
            }
            catch (Exception e)
            {
                _exceptionCaught = e;
            }
        }
    }
}
