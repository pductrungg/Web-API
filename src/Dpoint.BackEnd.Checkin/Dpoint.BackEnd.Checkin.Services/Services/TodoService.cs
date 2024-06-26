using AutoMapper;
using Dpoint.BackEnd.Checkin.Common.Commons;
using Dpoint.BackEnd.Checkin.Common.Constants;
using Dpoint.BackEnd.Checkin.Domain.Contexts;
using Dpoint.BackEnd.Checkin.Domain.Entities;
using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Dpoint.BackEnd.Checkin.Services.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Dpoint.BackEnd.Checkin.Services.Services
{
    public class TodoService : BaseService, ITodoService
    {
        private IMapper _mapper;
        private IApplicationDbContext _context; 
 
        public TodoService(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AppActionResultData<List<CheckInOutDto>>> Get()
        {
            var result = new AppActionResultData<List<CheckInOutDto>>();

            var checkInOut = await _context.CheckInOuts.Take(10).ToListAsync();

            var dtoCheckInOut = _mapper.Map<List<CheckInOut>, List<CheckInOutDto>>(checkInOut);

            return BuildMultilingualResult(result, dtoCheckInOut, MessageResponseConstant.SUCCESSFULLY);
        }
    }
}
