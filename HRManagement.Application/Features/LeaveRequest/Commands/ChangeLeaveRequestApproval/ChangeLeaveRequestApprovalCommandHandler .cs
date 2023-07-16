﻿using AutoMapper;
using HRManagement.Application.Contracts.Email;
using HRManagement.Application.Contracts.Persistance;
using HRManagement.Application.Exceptions;
using HRManagement.Application.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ChangeLeaveRequestApprovalCommandHandler(
             ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            this._emailSender = emailSender;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest is null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            leaveRequest.Approved = request.Approved;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            // if request is approved, get and update the employee's allocations


            // send confirmation email
            var email = new EmailMessage
            {
                To = string.Empty, /* Get email from employee record */
                Body = $"The approval status for your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
                        $"has been updated.",
                Subject = "Leave Request Approval Status Updated"
            };

            await _emailSender.SendEmail(email);

            return Unit.Value;
        }
    }
}
