using AutoMapper;
using HRManagement.Application.Contracts.Persistance;
using HRManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRManagement.Application.MappingProfiles;
using HRManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.UnitTests.Features.LeaveTypes.Commands
{
    public class CreateleaveTypeCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockCategoryRepository;
        private Mock<ILeaveTypeRepository> _mockRepo;

        public CreateleaveTypeCommandTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateLeaveTypeHandler(_mapper, _mockRepo.Object);

            await handler.Handle(new CreateLeaveTypeCommand() { Name = "Test" }, CancellationToken.None);

            var leaveTypes = await _mockCategoryRepository.Object.GetAsync();
            leaveTypes.Count.ShouldBe(4);
        }
    }
}
