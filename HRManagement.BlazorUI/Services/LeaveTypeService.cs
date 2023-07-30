using AutoMapper;
using Blazored.LocalStorage;
using HRManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Models.LeaveTypes;
using HRManagement.BlazorUI.Services.Base;
using CreateLeaveTypeCommand = HRManagement.BlazorUI.Services.Base.CreateLeaveTypeCommand;
using UpdateLeaveTypeCommand = HRManagement.BlazorUI.Services.Base.UpdateLeaveTypeCommand;

namespace HRManagement.BlazorUI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeServices
    {
        private readonly IMapper _mapper;
        public IMapper Mapper { get; }
        public LeaveTypeService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _mapper = mapper;
        }


        public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
        {
            try
            {
                await AddBearerToken();
                var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<Guid>(ex);
            }
           

        }

        public async Task<Response<Guid>> DeleteLeaveType(int id)
        {
            try
            {
                await AddBearerToken();
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            await AddBearerToken();
            var leaveType = await _client.LeaveTypesGETAsync(id);
           return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            await AddBearerToken();
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);

        }

        public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                await AddBearerToken();
                var updateLeaveTypeCommand = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypesPUTAsync(id.ToString(), updateLeaveTypeCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
