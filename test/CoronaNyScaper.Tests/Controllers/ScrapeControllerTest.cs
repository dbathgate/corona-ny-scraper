using CoronaNyScaper.Context;
using CoronaNyScaper.Controllers;
using CoronaNyScaper.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CoronaNyScaper.Tests.Controllers
{
    public class ScrapeControllerTest
    {
        private readonly ScrapeController _controller;
        private readonly Mock<INyDataRepository> _repositoryMock;
        private readonly Mock<MetricDatabaseContext> _databaseContextMock;
        private readonly Mock<ILogger<ScrapeController>> _loggerMock;

        public ScrapeControllerTest()
        {
            _repositoryMock = new Mock<INyDataRepository>();
            _databaseContextMock = new Mock<MetricDatabaseContext>();
            _loggerMock = new Mock<ILogger<ScrapeController>>();
            _controller = new ScrapeController(_repositoryMock.Object, _databaseContextMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void Should_Scrape_Data_And_Persist()
        {
            var result = _controller.Scrape();

            result.Should().NotBeNull().And.BeOfType<OkResult>();
            
            _repositoryMock.Verify(o => o.Get());
            _databaseContextMock.Verify(o => o.Add(null));
            _databaseContextMock.Verify(o => o.SaveChanges());
        }
    }
}