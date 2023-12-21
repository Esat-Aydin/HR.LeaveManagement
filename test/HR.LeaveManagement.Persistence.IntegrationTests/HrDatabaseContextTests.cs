using System.Data.Common;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using HR.LeaveManagement.Domain;
using Shouldly;

namespace HR.LeaveManagement.Persistence.IntegrationTests;

public class HrDatabaseContextTests
{
    private HrDatabaseContext _hrDatabaseContext;

    public HrDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _hrDatabaseContext = new HrDatabaseContext(dbOptions);
    }

    [Fact]
    public async void Save_SetDateCreatedValue()
    {
        // Arrange
        var LeaveType = new LeaveType()
        {
            Id = 1,
            Name = "IntegrationTest",
            DefaultDays = 10
        };

        // Act
        await _hrDatabaseContext.LeaveTypes.AddAsync(LeaveType);
        await _hrDatabaseContext.SaveChangesAsync();

        // Assert
        LeaveType.DateCreated.ShouldNotBe(DateTime.MinValue);
    }

    [Fact]
    public async void Save_SetDateModifiedValue()
    {
        // Arrange
        var LeaveType = new LeaveType()
        {
            Id = 1,
            Name = "IntegrationTest",
            DefaultDays = 10
        };

        // Act
        await _hrDatabaseContext.LeaveTypes.AddAsync(LeaveType);
        await _hrDatabaseContext.SaveChangesAsync();

        // Assert
        LeaveType.DateModified.ShouldNotBe(DateTime.MinValue);
    }
}