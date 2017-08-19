using System.Collections.Generic;
using System.Linq;
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
    public class CitiesControllerTest
    {
        [TestMethod]
        public void ShouldReturnSuccessGetCitiesByCountry()
        {
            //Arrange
            var citiesController = new CitiesController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var actionResult = citiesController.Get("Australia");
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<CityModel>>;


            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(contentResult, typeof(OkNegotiatedContentResult<IEnumerable<CityModel>>));
        }

        [TestMethod]
        public void ShouldReturnBadRequestWithValidationGetCitiesByCountry()
        {
            //Arrange
            var citiesController = new CitiesController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var actionResult = citiesController.Get("");
            var contentResult = (BadRequestErrorMessageResult)actionResult;

            //Assert
            contentResult.Message.ShouldBeEquivalentTo("Country Name must be provided");
            Assert.IsInstanceOfType(contentResult, typeof(BadRequestErrorMessageResult));

        }

        [TestMethod]
        public void ShouldReturnNoRecordsFoundGetCitiesByCountry()
        {
            //Arrange
            var citiesController = new CitiesController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var actionResult = citiesController.Get("Singapore");
            //var contentResult = (NotFoundResult)actionResult;
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<CityModel>>;

            //Assert
            Assert.IsInstanceOfType(contentResult, typeof(OkNegotiatedContentResult<IEnumerable<CityModel>>));
            contentResult?.Content.Count().Should().Be(0);
        }
    }
}
