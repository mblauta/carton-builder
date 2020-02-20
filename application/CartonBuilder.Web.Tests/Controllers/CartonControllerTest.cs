using CartonBuilder.Common.Interfaces;
using CartonBuilder.Common.Models;
using CartonBuilder.Web.Controllers;
using CartonBuilder.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CartonBuilder.Web.Tests.Controllers
{
    [TestClass]
    public class CartonControllerTest
    {
        private readonly int _cartonId = 111;
        private readonly string _cartonNumber = "111A-TEST";
        private readonly int _equipmentId = 222;
        private readonly int _cartonDetailId = 333;
        private readonly bool _returnNull = true;

        private Mock<ICartonService> _mockCartonService;
        private Mock<IEquipmentService> _mockEquipmentService;
        private Mock<ICartonDetailService> _mockCartonDetailService;

        [TestInitialize]
        public void InstantiateServices()
        {
            _mockCartonService = new Mock<ICartonService>();
            _mockEquipmentService = new Mock<IEquipmentService>();
            _mockCartonDetailService = new Mock<ICartonDetailService>();
        }

        [TestCleanup]
        public void DisposeServices()
        {
            _mockCartonService = null;
            _mockEquipmentService = null;
            _mockCartonDetailService = null;
        }


        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            // Arrage
            _mockCartonService
                .Setup(cs => cs.ListCartons())
                .Returns(new List<Carton>());

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);


            // Act
            var result = cartonController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_WithCartonFound_ReturnsViewResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.Details(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_WithCartonNotFound_ReturnsHttpNotFoundResult()
        {
            // Arrage
            SetupCartonServiceGetCarton(_returnNull);

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.Details(_cartonId) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_Get_ReturnsViewResult()
        {
            // Arrage
            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_PostWithValidModelState_ReturnsRedirectToRouteResult()
        {
            // Arrage
            var cartonCreateViewModel = GetCartonCreateViewModel();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.Create(cartonCreateViewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_PostWithInvalidModelState_ReturnsViewResult()
        {
            // Arrage
            var cartonCreateViewModel = GetCartonCreateViewModel();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);
            cartonController.ModelState.AddModelError("CartonNumber", "Invalid Carton Number");

            // Act
            var result = cartonController.Create(cartonCreateViewModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_Get_ReturnsViewResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.Edit(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_PostWithValidModelState_ReturnsRedirectToRouteResult()
        {
            // Arrage
            var cartonEditViewModel = GetCartonEditViewModel();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.Edit(cartonEditViewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_PostWithInvalidModelState_ReturnsViewResult()
        {
            // Arrage
            var cartonEditViewModel = GetCartonEditViewModel();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);
            cartonController.ModelState.AddModelError("CartonNumber", "Invalid Carton Number");

            // Act
            var result = cartonController.Edit(cartonEditViewModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_WithCartonFound_ReturnsViewResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.Delete(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_WithCartonNotFound_ReturnsHttpNotFoundResult()
        {
            // Arrage
            SetupCartonServiceGetCarton(_returnNull);

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.Delete(_cartonId) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteConfirmed_ReturnsRedirectToRouteResult()
        {
            // Arrage
            _mockCartonService
                .Setup(cs => cs.RemoveCarton(It.IsAny<int>()));

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.DeleteConfirmed(_cartonId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListAvailableEquipment_WithCartonFound_ReturnsViewResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();
            SetupEquipmentServiceListAvailableEquipmentForCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.ListAvailableEquipment(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListAvailableEquipment_WithCartonNotFound_ReturnsHttpNotFoundResult()
        {
            // Arrage
            SetupCartonServiceGetCarton(_returnNull);
            SetupEquipmentServiceListAvailableEquipmentForCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.ListAvailableEquipment(_cartonId) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddEquipment_WithCartonAndEquipmentFound_ReturnsRedirectToRouteResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();
            SetupEquipmentServiceGetEquipment();
            SetupCartonDetailServiceAddEquipmentToCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.AddEquipment(_cartonId, _equipmentId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddEquipment_WithCartonNotFound_ReturnsHttpStatusCodeResult()
        {
            // Arrage
            SetupCartonServiceGetCarton(_returnNull);
            SetupEquipmentServiceGetEquipment();
            SetupCartonDetailServiceAddEquipmentToCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.AddEquipment(_cartonId, _equipmentId) as HttpStatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddEquipment_WithEquipmentNotFound_ReturnsHttpStatusCodeResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();
            SetupEquipmentServiceGetEquipment(_returnNull);
            SetupCartonDetailServiceAddEquipmentToCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.AddEquipment(_cartonId, _equipmentId) as HttpStatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListAddedEquipment_WithCartonFound_ReturnsViewResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();
            SetupEquipmentServiceListAddedEquipmentForCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.ListAddedEquipment(_cartonId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListAddedEquipment_WithCartonNotFound_ReturnsHttpStatusCodeResult()
        {
            // Arrage
            SetupCartonServiceGetCarton(_returnNull);
            SetupEquipmentServiceListAddedEquipmentForCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.ListAddedEquipment(_cartonId) as HttpStatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RemoveEquipment_WithCartonAndEquipmentFound_ReturnsRedirectToRouteViewResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();
            SetupEquipmentServiceGetEquipment();
            SetupCartonDetailServiceRemoveEquipmentFromCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.RemoveEquipment(_cartonId, _equipmentId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RemoveEquipment_WithCartonNotFound_ReturnsHttpStatusCodeResult()
        {
            // Arrage
            SetupCartonServiceGetCarton(_returnNull);
            SetupEquipmentServiceGetEquipment();
            SetupCartonDetailServiceRemoveEquipmentFromCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.RemoveEquipment(_cartonId, _equipmentId) as HttpStatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RemoveEquipment_WithEquipmentNotFound_ReturnsHttpStatusCodeResult()
        {
            // Arrage
            SetupCartonServiceGetCarton();
            SetupEquipmentServiceGetEquipment(_returnNull);
            SetupCartonDetailServiceRemoveEquipmentFromCarton();

            var cartonController = new CartonController(_mockCartonService.Object, _mockEquipmentService.Object, _mockCartonDetailService.Object);

            // Act
            var result = cartonController.RemoveEquipment(_cartonId, _equipmentId) as HttpStatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
        }

        #region Helper Methods

        private void SetupCartonServiceGetCarton(bool isReturnNull = false)
        {
            if (isReturnNull)
            {
                _mockCartonService
                    .Setup(cs => cs.GetCarton(It.IsAny<int>()))
                    .Returns((Carton)null);
            }
            else
            {
                _mockCartonService
                    .Setup(cs => cs.GetCarton(It.IsAny<int>()))
                    .Returns(new Carton());
            }
        }

        private void SetupEquipmentServiceGetEquipment(bool isReturnNull = false)
        {
            if (isReturnNull)
            {
                _mockEquipmentService
                    .Setup(es => es.GetEquipment(It.IsAny<int>()))
                    .Returns((Equipment)null);
            }
            else
            {
                _mockEquipmentService
                    .Setup(es => es.GetEquipment(It.IsAny<int>()))
                    .Returns(new Equipment());
            }
        }

        private void SetupEquipmentServiceListAvailableEquipmentForCarton()
        {
            _mockEquipmentService
                .Setup(es => es.ListAvailableEquipmentForCarton(It.IsAny<int>()))
                .Returns(new List<Equipment>());
        }

        private void SetupCartonDetailServiceAddEquipmentToCarton()
        {
            _mockCartonDetailService
                .Setup(cds => cds.AddEquipmentToCarton(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(_cartonDetailId);
        }

        private void SetupEquipmentServiceListAddedEquipmentForCarton()
        {
            _mockEquipmentService
                .Setup(es => es.ListAddedEquipmentForCarton(It.IsAny<int>()))
                .Returns(new List<Equipment>());
        }

        private void SetupCartonDetailServiceRemoveEquipmentFromCarton()
        {
            _mockCartonDetailService
                .Setup(cds => cds.RemoveEquipmentFromCarton(It.IsAny<int>(), It.IsAny<int>()));
        }

        private CartonCreateViewModel GetCartonCreateViewModel()
        {
            return new CartonCreateViewModel()
            {
                Id = _cartonId,
                CartonNumber = _cartonNumber
            };
        }

        private CartonEditViewModel GetCartonEditViewModel()
        {
            return new CartonEditViewModel()
            {
                Id = _cartonId,
                CartonNumber = _cartonNumber
            };
        }

        #endregion Helper Methods

    }
}
