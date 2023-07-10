using AutoMapper;
using HRManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRmanagementDomain;
using HRManagement.Application.Exceptions;

namespace HRManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeCommandVlidator(_leaveTypeRepository);
            var validatonResult = await validator.ValidateAsync(request);

            if (validatonResult.Errors.Any())
            {
                throw new BadRequestException("Invalid LeaveType", validatonResult);
            }
            var leaveTypeToCreate = _mapper.Map<HRmanagementDomain.LeaveType>(request);

            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            return leaveTypeToCreate.Id;
        }
    }
}
