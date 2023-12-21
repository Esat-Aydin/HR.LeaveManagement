using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetMockLeaveTypes()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    Name = "Annual",
                    DateCreated = DateTime.Now,
                    DefaultDays = 10
                },
                new LeaveType
                {
                    Id = 2,
                    Name = "Sick",
                    DateCreated = DateTime.Now,
                    DefaultDays = 10
                },
                new LeaveType
                {
                    Id = 3,
                    Name = "Maternity",
                    DateCreated = DateTime.Now,
                    DefaultDays = 10
                },
                new LeaveType
                {
                    Id = 4,
                    Name = "Paternity",
                    DateCreated = DateTime.Now,
                    DefaultDays = 10
                },
                new LeaveType
                {
                    Id = 5,
                    Name = "Unpaid",
                    DateCreated = DateTime.Now,
                    DefaultDays = 10
                }
            };
            // Mock of the real repository
            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(repo => repo.GetAsync()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<LeaveType>())).Returns(
                (LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return Task.CompletedTask;
                });

            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<LeaveType>())).Returns(
                (LeaveType leaveType) =>
                {
                    var index = leaveTypes.FindIndex(x => x.Id == leaveType.Id);
                    if (index >= 0)
                    {
                        leaveTypes[index] = leaveType;
                    }

                    return Task.CompletedTask;
                });
            
            mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<LeaveType>())).Returns(
                (LeaveType leaveType) =>
                {
                    leaveTypes.Remove(leaveType);
                    return Task.CompletedTask;
                });
            
            mockRepo.Setup(r => r.IsLeaveTypeUnique(It.IsAny<string>()))
                .ReturnsAsync((string name) => { 
                    return !leaveTypes.Any(q => q.Name == name);
                });
            
            return mockRepo;
        }

    }
}