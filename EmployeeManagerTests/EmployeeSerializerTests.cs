using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManager;

namespace EmployeeManagerTests
{
    [TestClass]
    public class EmployeeSerializerTests
    {
        [TestMethod]
        public void EmployeeSerializedCorreclty()
        {
            // arrange
            var serializer = new EmployeeSerializer();

            // act
            var result = serializer.Serialize(new Employee("Slawek", "Nidecki", 33));

            // assert
            Assert.AreEqual("Slawek,Nidecki,33", result);
        }

        [TestMethod]
        public void EmployeeDeserializedCorreclty()
        {
            // arrange
            var serializer = new EmployeeSerializer();

            // act
            var result = serializer.Deserialize("Slawek,Nidecki,33");

            // assert
            Assert.AreEqual(new Employee("Slawek", "Nidecki", 33), result);
        }
    }
}
