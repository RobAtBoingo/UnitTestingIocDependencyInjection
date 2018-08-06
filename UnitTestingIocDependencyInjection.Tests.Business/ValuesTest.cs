using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using UnitTestingIocDependencyInjection.Business;
using UnitTestingIocDependencyInjection.Data;

namespace UnitTestingIocDependencyInjection.Tests.Business
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ValuesTest
    {
        private Mock<IValuesRepository> _valuesRepository;
        private Values _target;
        private int _idToGet;
        private Exception _exceptionCaught;
        private Exception _exceptionThrown;
        private JToken _valueReturned;
        private string _valueToReturn = "{\"name\":\"Dirk\"}";


        [TestInitialize]
        public void Initialize()
        {
            _valuesRepository = new Mock<IValuesRepository>();
            _valuesRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns(_valueToReturn);

            _exceptionCaught = null;
            _exceptionThrown = new Exception("z");

            _idToGet = 1;

            _target = new Values(_valuesRepository.Object);
        }

        [TestMethod]
        public void GetValueByIdEverythingWorks()
        {
            RunGetValueById();

            Assert.AreEqual(_valueReturned.ToString(), JToken.Parse(_valueToReturn).ToString());
            Assert.AreEqual(_exceptionCaught, null);
            _valuesRepository.Verify(m => m.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetValueByIdThrowsException()
        {
            _valuesRepository.Setup(m => m.GetById(It.IsAny<int>())).Throws(_exceptionThrown);

            RunGetValueById();

            Assert.AreNotEqual(_exceptionCaught, null);
            Assert.AreEqual(_exceptionCaught, _exceptionThrown);
            _valuesRepository.Verify(m => m.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetValueByIdBadInputErrorReturned()
        {
            _valuesRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns("sdkh slg; ");

            RunGetValueById();

            Assert.AreEqual(_valueReturned.ToString(), JToken.Parse("{\"error\":\"SOLR!\"}").ToString());
            Assert.AreEqual(_exceptionCaught, null);
            _valuesRepository.Verify(m => m.GetById(It.IsAny<int>()), Times.Once);
        }

        private void RunGetValueById()
        {
            try
            {
                _valueReturned = _target.GetValueById(_idToGet);
            }
            catch (Exception e)
            {
                _exceptionCaught = e;
            }
        }
    }
}
