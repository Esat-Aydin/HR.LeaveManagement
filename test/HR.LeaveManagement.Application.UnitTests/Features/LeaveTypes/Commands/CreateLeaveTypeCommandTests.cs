using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository>? _mockRepo;

        public CreateLeaveTypeCommandTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypes();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidLeaveType()
        {
            if (_mapper == null || _mockRepo == null)
            {
                // Handle the null reference case here
                throw new NullReferenceException();
            }
            
            var handler = new CreateLeaveTypeCommandHandler(_mapper, _mockRepo.Object);

            await handler.Handle(new CreateLeaveTypeCommand() { Name = "Test1", DefaultDays = 1
            }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAsync();
            leaveTypes.Count.ShouldBe(6);
        }
    }
}