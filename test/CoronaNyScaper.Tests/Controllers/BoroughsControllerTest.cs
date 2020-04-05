using System;
using System.Collections.Generic;
using CoronaNyScaper.Controllers;
using CoronaNyScaper.Model;
using CoronaNyScaper.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CoronaNyScaper.Tests.CoronaNyScaper
{
    public class BoroughsControllerTest
    {

        readonly BoroughsController _controller;
        readonly Mock<IBoroughDataRepository> _repositoryMock;

        readonly DateTime _startDate = DateTime.Parse("2020-03-01");
        readonly DateTime _endDate = DateTime.Parse("2020-03-03");

        readonly List<NyBorough> _data = new List<NyBorough>
            {
                new NyBorough
                {
                    Queens = 1,
                    Bronx = 2,
                    Manhattan = 3,
                    Staten = 5,
                    Brooklyn = 7,
                    LastUpdated = DateTime.Parse("2020-03-03")
                },
                 new NyBorough
                {
                    Queens = 4,
                    Bronx = 4,
                    Manhattan = 1,
                    Staten = 3,
                    Brooklyn = 4,
                    LastUpdated = DateTime.Parse("2020-03-02")
                }
            };

        public BoroughsControllerTest()
        {
            _repositoryMock = new Mock<IBoroughDataRepository>();
            _controller = new BoroughsController(_repositoryMock.Object);
        }

        [Fact]
        public async void Should_Call_Cases_By_Date_Range()
        {
            // arrange
            _repositoryMock.Setup(o => o.CasesByDateRange(_startDate, _endDate)).ReturnsAsync(_data);

            // act
            var result = await _controller.Get(_startDate, _endDate);

            // assert
            var response = result.Should().NotBeNull().And.BeOfType<ActionResult<List<NyBorough>>>().Subject;
            response.Value.Should().NotBeNull().And.BeEquivalentTo(_data);

            _repositoryMock.Verify(o => o.CasesByDateRange(_startDate, _endDate));
        }

        [Fact]
        public async void Should_Call_Deaths_By_Date_Range()
        {
            // arrange
            _repositoryMock.Setup(o => o.DeathsByDateRange(_startDate, _endDate)).ReturnsAsync(_data);

            // act
            var result = await _controller.GetDeaths(_startDate, _endDate);

            // assert
            var response = result.Should().NotBeNull().And.BeOfType<ActionResult<List<NyBorough>>>().Subject;
            response.Value.Should().NotBeNull().And.BeEquivalentTo(_data);

            _repositoryMock.Verify(o => o.DeathsByDateRange(_startDate, _endDate));
        }

        [Fact]
        public async void Should_Call_Hospitalizations_By_Date_Range()
        {
            // arrange
            _repositoryMock.Setup(o => o.HospitalizationsByDateRange(_startDate, _endDate)).ReturnsAsync(_data);

            // act
            var result = await _controller.GetHospitalizations(_startDate, _endDate);

            // assert
            var response = result.Should().NotBeNull().And.BeOfType<ActionResult<List<NyBorough>>>().Subject;
            response.Value.Should().NotBeNull().And.BeEquivalentTo(_data);

            _repositoryMock.Verify(o => o.HospitalizationsByDateRange(_startDate, _endDate));
        }

        [Fact]
        public async void Should_Call_Cases_New_Per_Day()
        {
            // arrange
            _repositoryMock.Setup(o => o.NewCasesPerDay()).ReturnsAsync(_data);

            // act
            var result = await _controller.NewCasesPerDay();

            // assert
            var response = result.Should().NotBeNull().And.BeOfType<ActionResult<List<NyBorough>>>().Subject;
            response.Value.Should().NotBeNull().And.BeEquivalentTo(_data);

            _repositoryMock.Verify(o => o.NewCasesPerDay());
        }

        [Fact]
        public async void Should_Call_Hospitalizations_New_Per_Day()
        {
            // arrange
            _repositoryMock.Setup(o => o.NewHospitalizationsPerDay()).ReturnsAsync(_data);

            // act
            var result = await _controller.NewHospitalizationsPerDay();

            // assert
            var response = result.Should().NotBeNull().And.BeOfType<ActionResult<List<NyBorough>>>().Subject;
            response.Value.Should().NotBeNull().And.BeEquivalentTo(_data);

            _repositoryMock.Verify(o => o.NewHospitalizationsPerDay());
        }

        [Fact]
        public async void Should_Call_Deaths_New_Per_Day()
        {
            // arrange
            _repositoryMock.Setup(o => o.NewDeathsPerDay()).ReturnsAsync(_data);

            // act
            var result = await _controller.NewDeathsPerDay();

            // assert
            var response = result.Should().NotBeNull().And.BeOfType<ActionResult<List<NyBorough>>>().Subject;
            response.Value.Should().NotBeNull().And.BeEquivalentTo(_data);

            _repositoryMock.Verify(o => o.NewDeathsPerDay());
        }
    }
}