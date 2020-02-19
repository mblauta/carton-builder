using System;
using System.Web.Mvc;
using CartonBuilder.Web.Controllers;
using CartonBuilder.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartonBuilder.Web.Tests.Controllers
{
    [TestClass]
    public class CartonControllerTest
    {
        private readonly int _cartonId = 1;
        private readonly int _equipmentId = 1;

        [TestMethod]
        public void Index_Returns_ViewResult()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_Returns_ViewResult()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.Details(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_Returns_ViewResult()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_Returns_ViewResult()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.Edit(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_ReturnsView_Result()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.Delete(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListAvailableEquipment_Returns_ViewResult()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.ListAvailableEquipment(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddEquipment_Returns_ViewResult()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.AddEquipment(_cartonId, _equipmentId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListAddedEquipment_Returns_ViewResult()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.ListAddedEquipment(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RemoveEquipment_Returns_ViewResult()
        {
            // Arrage
            var cartonController = new CartonController();

            // Act
            var result = cartonController.RemoveEquipment(_cartonId, _equipmentId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
