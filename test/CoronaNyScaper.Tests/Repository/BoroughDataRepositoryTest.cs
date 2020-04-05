using System;
using System.Collections.Generic;
using CoronaNyScaper.Data;
using CoronaNyScaper.Model;
using CoronaNyScaper.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CoronaNyScaper.Tests.Repository
{
    public class BoroughDataRepositoryTest : IDisposable
    {
        readonly BoroughDataRepository _repository;
        readonly MetricDatabaseContext _databaseContext;
        readonly List<NyBoroughEntity> _nyBoroughEntities;
        readonly List<NyBoroughDeathsEntity> _nyBoroughDeathsEntities;

        readonly List<NyBoroughHospitalizationsEntity> _nyBoroughHospitalizationsEntities;

        readonly List<NyBorough> _expectedResult;

        readonly List<NyBorough> _expectedNewCases;

        readonly DateTime _outOfRangeStartDate = DateTime.Parse("2020-04-01");
        readonly DateTime _outOfRangeEndDate = DateTime.Parse("2020-04-03");

        readonly DateTime _inRangeStartDate = DateTime.Parse("2020-03-01");
        readonly DateTime _inRangeEndDate = DateTime.Parse("2020-03-03");

        public BoroughDataRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<MetricDatabaseContext>()
            .UseInMemoryDatabase("CoronaDb").Options;

            _databaseContext = new MetricDatabaseContext(options);

            _repository = new BoroughDataRepository(_databaseContext);

            using var _testDatabaseContext = new MetricDatabaseContext(options);

            _expectedResult = new List<NyBorough>
            {
                new NyBorough
                {
                    Queens = 1,
                    Brooklyn = 2,
                    Manhattan = 3,
                    Staten = 4,
                    Bronx = 5,
                    LastUpdated = DateTime.Parse("2020-03-01T00:00:00")
                },
                new NyBorough
                {
                    Queens = 3,
                    Brooklyn = 4,
                    Manhattan = 5,
                    Staten = 8,
                    Bronx = 9,
                    LastUpdated = DateTime.Parse("2020-03-01T05:00:00")
                },
                new NyBorough
                {
                    Queens = 10,
                    Brooklyn = 11,
                    Manhattan = 12,
                    Staten = 13,
                    Bronx = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T01:00:00")
                }
            };

            _expectedNewCases = new List<NyBorough>
            {
                new NyBorough
                {
                    Queens = 7,
                    Brooklyn = 7,
                    Manhattan = 7,
                    Staten = 5,
                    Bronx = 7,
                    LastUpdated = DateTime.Parse("2020-03-02T00:00:00")
                }
            };

            _nyBoroughEntities = new List<NyBoroughEntity>
            {
                new NyBoroughEntity
                {
                    Queens = 1,
                    Brooklyn = 2,
                    Manhattan = 3,
                    Staten = 4,
                    Bronx = 5,
                    LastUpdated = DateTime.Parse("2020-03-01T00:00:00")
                },
                new NyBoroughEntity
                {
                    Queens = 1,
                    Brooklyn = 2,
                    Manhattan = 3,
                    Staten = 4,
                    Bronx = 5,
                    LastUpdated = DateTime.Parse("2020-03-01T01:00:00")
                },
                new NyBoroughEntity
                {
                    Queens = 3,
                    Brooklyn = 4,
                    Manhattan = 5,
                    Staten = 8,
                    Bronx = 9,
                    LastUpdated = DateTime.Parse("2020-03-01T05:00:00")
                },
                new NyBoroughEntity
                {
                    Queens = 3,
                    Brooklyn = 4,
                    Manhattan = 5,
                    Staten = 8,
                    Bronx = 9,
                    LastUpdated = DateTime.Parse("2020-03-02T06:00:00")
                },
                new NyBoroughEntity
                {
                    Queens = 10,
                    Brooklyn = 11,
                    Manhattan = 12,
                    Staten = 13,
                    Bronx = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T01:00:00")
                },
                new NyBoroughEntity
                {
                    Queens = 10,
                    Brooklyn = 11,
                    Manhattan = 12,
                    Staten = 13,
                    Bronx = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T02:00:00")
                }
            };

            _nyBoroughHospitalizationsEntities = new List<NyBoroughHospitalizationsEntity>
            {
                new NyBoroughHospitalizationsEntity
                {
                    Queens = 1,
                    Brooklyn = 2,
                    Manhattan = 3,
                    Staten = 4,
                    Bronx = 5,
                    LastUpdated = DateTime.Parse("2020-03-01T00:00:00")
                },
                new NyBoroughHospitalizationsEntity
                {
                    Queens = 1,
                    Brooklyn = 2,
                    Manhattan = 3,
                    Staten = 4,
                    Bronx = 5,
                    LastUpdated = DateTime.Parse("2020-03-01T01:00:00")
                },
                new NyBoroughHospitalizationsEntity
                {
                    Queens = 3,
                    Brooklyn = 4,
                    Manhattan = 5,
                    Staten = 8,
                    Bronx = 9,
                    LastUpdated = DateTime.Parse("2020-03-01T05:00:00")
                },
                new NyBoroughHospitalizationsEntity
                {
                    Queens = 3,
                    Brooklyn = 4,
                    Manhattan = 5,
                    Staten = 8,
                    Bronx = 9,
                    LastUpdated = DateTime.Parse("2020-03-02T06:00:00")
                },
                new NyBoroughHospitalizationsEntity
                {
                    Queens = 10,
                    Brooklyn = 11,
                    Manhattan = 12,
                    Staten = 13,
                    Bronx = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T01:00:00")
                },
                new NyBoroughHospitalizationsEntity
                {
                    Queens = 10,
                    Brooklyn = 11,
                    Manhattan = 12,
                    Staten = 13,
                    Bronx = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T02:00:00")
                }
            };

            _nyBoroughDeathsEntities = new List<NyBoroughDeathsEntity>
            {
                new NyBoroughDeathsEntity
                {
                    Queens = 1,
                    Brooklyn = 2,
                    Manhattan = 3,
                    Staten = 4,
                    Bronx = 5,
                    LastUpdated = DateTime.Parse("2020-03-01T00:00:00")
                },
                new NyBoroughDeathsEntity
                {
                    Queens = 1,
                    Brooklyn = 2,
                    Manhattan = 3,
                    Staten = 4,
                    Bronx = 5,
                    LastUpdated = DateTime.Parse("2020-03-01T01:00:00")
                },
                new NyBoroughDeathsEntity
                {
                    Queens = 3,
                    Brooklyn = 4,
                    Manhattan = 5,
                    Staten = 8,
                    Bronx = 9,
                    LastUpdated = DateTime.Parse("2020-03-01T05:00:00")
                },
                new NyBoroughDeathsEntity
                {
                    Queens = 3,
                    Brooklyn = 4,
                    Manhattan = 5,
                    Staten = 8,
                    Bronx = 9,
                    LastUpdated = DateTime.Parse("2020-03-02T06:00:00")
                },
                new NyBoroughDeathsEntity
                {
                    Queens = 10,
                    Brooklyn = 11,
                    Manhattan = 12,
                    Staten = 13,
                    Bronx = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T01:00:00")
                },
                new NyBoroughDeathsEntity
                {
                    Queens = 10,
                    Brooklyn = 11,
                    Manhattan = 12,
                    Staten = 13,
                    Bronx = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T02:00:00")
                }
            };


            _testDatabaseContext.NyBoroughs.AddRange(_nyBoroughEntities);
            _testDatabaseContext.NyBoroughDeaths.AddRange(_nyBoroughDeathsEntities);
            _testDatabaseContext.NyBoroughsHospitalizations.AddRange(_nyBoroughHospitalizationsEntities);
            _testDatabaseContext.SaveChanges();

        }

        [Fact]
        public async void Should_Not_Find_Cases_By_Date_Range()
        {
            // act
            var result = await _repository.CasesByDateRange(_outOfRangeStartDate, _outOfRangeEndDate);

            // assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async void Should_Find_Cases_By_Date_Range()
        {
            // act
            var result = await _repository.CasesByDateRange(_inRangeStartDate, _inRangeEndDate);

            // assert
            result.Should().NotBeEmpty().And.BeEquivalentTo(_expectedResult);
        }

        [Fact]
        public async void Should_Find_Cases_New_Per_Day()
        {
            // act
            var result = await _repository.NewCasesPerDay();

            // assert
            var response = result.Should().NotBeEmpty().And.BeEquivalentTo(_expectedNewCases);
        }

        [Fact]
        public async void Should_Not_Find_Deaths_By_Date_Range()
        {
            // act
            var result = await _repository.DeathsByDateRange(_outOfRangeStartDate, _outOfRangeEndDate);

            // assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async void Should_Find_Deaths_By_Date_Range()
        {
            // act
            var result = await _repository.DeathsByDateRange(_inRangeStartDate, _inRangeEndDate);

            // assert
            result.Should().NotBeEmpty().And.BeEquivalentTo(_expectedResult);
        }

        [Fact]
        public async void Should_Find_Deaths_New_Per_Day()
        {
            // act
            var result = await _repository.NewDeathsPerDay();

            // assert
            var response = result.Should().NotBeEmpty().And.BeEquivalentTo(_expectedNewCases);
        }

        [Fact]
        public async void Should_Not_Find_Hospitalizations_By_Date_Range()
        {
            // act
            var result = await _repository.HospitalizationsByDateRange(_outOfRangeStartDate, _outOfRangeEndDate);

            // assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async void Should_Find_Hospitalizations_By_Date_Range()
        {
            // act
            var result = await _repository.HospitalizationsByDateRange(_inRangeStartDate, _inRangeEndDate);

            // assert
            result.Should().NotBeEmpty().And.BeEquivalentTo(_expectedResult);
        }

        [Fact]
        public async void Should_Find_Hospitalizations_New_Per_Day()
        {
            // act
            var result = await _repository.NewHospitalizationsPerDay();

            // assert
            var response = result.Should().NotBeEmpty().And.BeEquivalentTo(_expectedNewCases);
        }

        public void Dispose()
        {
            _databaseContext.Database.EnsureDeleted();
            _databaseContext.Dispose();
        }
    }
}