using System;
using System.Collections.Generic;
using CoronaNyScaper.Controllers;
using CoronaNyScaper.Model;
using CoronaNyScaper.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CoronaNyScaper.Tests.Controllers
{
    public class CountiesControllerTest
    {
        readonly CountiesController _controller;

        readonly Mock<ICountyDataRepository> _repositoryMock;

        readonly List<NyCounty> _data = new List<NyCounty>
            {
                new NyCounty
                {
                    State = 1,
                    Nyc = 2,
                    Suffolk = 5,
                    Nassau = 6,
                    LastUpdated = DateTime.Parse("2020-03-03")
                },
                new NyCounty
                {
                    State = 2,
                    Nyc = 3,
                    Suffolk = 6,
                    Nassau = 8,
                    LastUpdated = DateTime.Parse("2020-03-01")
                }
            };
        public CountiesControllerTest()
        {
            _repositoryMock = new Mock<ICountyDataRepository>();
            _controller = new CountiesController(_repositoryMock.Object);
        }

        [Fact]
        public async void Should_Call_Get_Counties_By_Date_Range()
        {
            // arrange
            var startDate = DateTime.Parse("2020-03-01");
            var endDate = DateTime.Parse("2020-03-03");

            _repositoryMock.Setup(o => o.GetByDateRange(startDate, endDate)).ReturnsAsync(_data);

            // act
            var result = await _controller.Get(startDate, endDate);

            // assert
            var response = result.Should().NotBeNull().And.BeOfType<ActionResult<List<NyCounty>>>().Subject;
            response.Value.Should().NotBeNull().And.BeEquivalentTo(_data);

            _repositoryMock.Verify(o => o.GetByDateRange(startDate, endDate));
        }

        [Fact]
        public async void Should_Call_Get_Counties_New_Per_Day()
        {
            // arrange
            _repositoryMock.Setup(o => o.NewPerDay()).ReturnsAsync(_data);
            
            // act
            var result = await _controller.GetNewPerDay();

            // assert
            var response = result.Should().NotBeNull().And.BeOfType<ActionResult<List<NyCounty>>>().Subject;
            response.Value.Should().NotBeNull().And.BeEquivalentTo(_data);

            _repositoryMock.Verify(o => o.NewPerDay());
        }
    }
}