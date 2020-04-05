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

    public class CountyDataRepositoryTest : IDisposable
    {
        readonly CountyDataRepository _repository;
        
        readonly MetricDatabaseContext _databaseContext;

        readonly List<NyCountyEntity> _countiesData;

        readonly List<NyCounty> _expectedResult;

        readonly List<NyCounty> _expectedNewCasesResult;

        readonly DateTime _outOfRangeStartDate = DateTime.Parse("2020-04-01");
        readonly DateTime _outOfRangeEndDate = DateTime.Parse("2020-04-03");

        readonly DateTime _inRangeStartDate = DateTime.Parse("2020-03-01");
        readonly DateTime _inRangeEndDate = DateTime.Parse("2020-03-03");

        public CountyDataRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<MetricDatabaseContext>()
            .UseInMemoryDatabase("CoronaDb").Options;

            _databaseContext = new MetricDatabaseContext(options);
            _repository = new CountyDataRepository(_databaseContext);

            using var testDatabaseContext = new MetricDatabaseContext(options);

            _expectedResult = new List<NyCounty>
            {
                new NyCounty
                {
                    State = 1,
                    Nyc = 2,
                    Nassau = 3,
                    Suffolk = 4,
                    LastUpdated = DateTime.Parse("2020-03-01T00:00:00")
                },
                new NyCounty
                {
                    State = 2,
                    Nyc = 3,
                    Nassau = 4,
                    Suffolk = 6,
                    LastUpdated = DateTime.Parse("2020-03-01T05:00:00")
                },
                new NyCounty
                {
                    State = 10,
                    Nyc = 13,
                    Nassau = 14,
                    Suffolk = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T01:00:00")
                }
            };

            _expectedNewCasesResult = new List<NyCounty>
            {
                new NyCounty
                {
                    State = 8,
                    Nyc = 10,
                    Nassau = 10,
                    Suffolk = 10,
                    LastUpdated = DateTime.Parse("2020-03-02T00:00:00")
                },
            };

            _countiesData = new List<NyCountyEntity>
            {
                new NyCountyEntity
                {
                    State = 1,
                    Nyc = 2,
                    Nassau = 3,
                    Suffolk = 4,
                    LastUpdated = DateTime.Parse("2020-03-01T00:00:00")
                },
                new NyCountyEntity
                {
                    State = 1,
                    Nyc = 2,
                    Nassau = 3,
                    Suffolk = 4,
                    LastUpdated = DateTime.Parse("2020-03-01T01:00:00")
                },
                new NyCountyEntity
                {
                    State = 2,
                    Nyc = 3,
                    Nassau = 4,
                    Suffolk = 6,
                    LastUpdated = DateTime.Parse("2020-03-01T05:00:00")
                },
                new NyCountyEntity
                {
                    State = 2,
                    Nyc = 3,
                    Nassau = 4,
                    Suffolk = 6,
                    LastUpdated = DateTime.Parse("2020-03-01T07:00:00")
                },
                new NyCountyEntity
                {
                    State = 10,
                    Nyc = 13,
                    Nassau = 14,
                    Suffolk = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T01:00:00")
                },
                new NyCountyEntity
                {
                    State = 10,
                    Nyc = 13,
                    Nassau = 14,
                    Suffolk = 16,
                    LastUpdated = DateTime.Parse("2020-03-02T05:00:00")
                },
            };

            testDatabaseContext.NyCounties.AddRange(_countiesData);
            testDatabaseContext.SaveChanges();
        }

        [Fact]
        public async void Should_Not_Found_Cases_By_Range()
        {
            // act
            var result = await _repository.GetByDateRange(_outOfRangeStartDate, _outOfRangeEndDate);

            // assert
            result.Should().BeEmpty();
        }       

        [Fact]
        public async void Should_Find_Cases_By_Range()
        {
            // act
            var result = await _repository.GetByDateRange(_inRangeStartDate, _inRangeEndDate);

            // assert
            result.Should().NotBeEmpty().And.BeEquivalentTo(_expectedResult);
        }

        [Fact]
        public async void Should_Find_New_Cases()
        {
            // act
            var result = await _repository.NewPerDay();

            // assert
            result.Should().NotBeEmpty().And.BeEquivalentTo(_expectedNewCasesResult);
        }

        public void Dispose()
        {
            _databaseContext.Database.EnsureDeleted();
            _databaseContext.Dispose();
        }
    }
}