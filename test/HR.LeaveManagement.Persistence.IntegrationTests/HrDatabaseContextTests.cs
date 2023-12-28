using System.Data.Common;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using HR.LeaveManagement.Domain;
using Shouldly;
using HR.LeaveManagement.Application.Contracts.Identity;

namespace HR.LeaveManagement.Persistence.IntegrationTests;

public class HrDatabaseContextTests
{
    private HrDatabaseContext _hrDatabaseContext;
    private IUserService _userService;

    public HrDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _hrDatabaseContext = new HrDatabaseContext(dbOptions, _userService);
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