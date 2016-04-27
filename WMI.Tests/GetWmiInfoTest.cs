using Domain;
using NUnit.Framework;

namespace WMI.Tests
{
    [TestFixture]
    public class GetWmiInfoTest
    {
        [SetUp]
        public void SetUp()
        {
            _model = new WmInfo().GetInfo();
        }

        [Test]
        public void GetInfo_Manufacturer_IsNotEmpty_Test()
        {
            Assert.IsNotEmpty(_model.Manufacturer.Name);
        }

        [Test]
        public void GetInfo_ComputerName_IsNotEmpty_Test()
        {
            Assert.IsNotEmpty(_model.ComputerName.Name);
        }

        [Test]
        public void GetInfo_UserNames_IsNotEmpty_Test()
        {
            Assert.IsNotEmpty(_model.UserNames);
        }

        EntitiesModel _model;
    }
}
