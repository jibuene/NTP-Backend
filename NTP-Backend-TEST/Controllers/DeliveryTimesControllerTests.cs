using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTP_Backend2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP_Backend_TEST.Controllers
{
    [TestClass]
    public class DeliveryTimesControllerTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange
            DeliveryTimesController controller = new DeliveryTimesController();
            // Act
            controller.Post("{ min: 0, max: 0, time: 0, ProductId: 0}");

            // Assert
        }

    }
}
