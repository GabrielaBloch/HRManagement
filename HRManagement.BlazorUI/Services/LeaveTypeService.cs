using AutoMapper;
using HRManagement.BlazorUI.Contracts;
using HRManagement.BlazorUI.Models.LeaveTypes;
using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeServices
    {
        private readonly IMapper _mapper;
        public LeaveTypeService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
        {
            try
            {
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
           var leaveType = await _client.LeaveTypesGETAsync(id);
           return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);

        }

        public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                
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
