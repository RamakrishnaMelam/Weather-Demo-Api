using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherReport.Api.Controllers;
using WeatherReport.Api.Models;

namespace WeatherReport.Api.Tests
{
    [TestClass]
    public class WeatherControllerTest
    {
        [TestMethod]
        public void ShouldReturnSuccessWeatherReport()
        {
            //Arrange
            var weatherController = new WeatherController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var actionResult = weatherController.Get("Australia","Sydney Airport");
            var contentResult = actionResult as OkNegotiatedContentResult<WeatherModel>;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(contentResult, typeof(OkNegotiatedContentResult<WeatherModel>));
        }

        [TestMethod]
        public void ShouldReturnBadRequestCountryNameValidationWeatherReport()
        {
            //Arrange
            var weatherController = new WeatherController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var actionResult = weatherController.Get("","");
            var contentResult = (BadRequestErrorMessageResult)actionResult;

            //Assert
            contentResult.Message.ShouldBeEquivalentTo("Country Name must be provided");
            Assert.IsInstanceOfType(contentResult, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void ShouldReturnBadRequestCityValidationWeatherReport()
        {
            //Arrange
            var weatherController = new WeatherController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var actionResult = weatherController.Get("Australia", "");
            var contentResult = (BadRequestErrorMessageResult)actionResult;

            //Assert
            contentResult.Message.ShouldBeEquivalentTo("City Name must be provided");
            Assert.IsInstanceOfType(contentResult, typeof(BadRequestErrorMessageResult));
        }
        [TestMethod]
        public void ShouldReturnNoRecordsFoundGetCitiesByCountry()
        {
            //Arrange
            var weatherController = new WeatherController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var actionResult = weatherController.Get("Singapore","Singapore Airport");
            var contentResult = (NotFoundResult)actionResult;

            //Assert
            Assert.IsInstanceOfType(contentResult, typeof(NotFoundResult));
        }
    }
}
