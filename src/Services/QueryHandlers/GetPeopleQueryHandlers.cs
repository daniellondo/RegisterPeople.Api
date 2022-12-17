namespace Services.QueryHandlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Domain.Dtos;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetPeopleQueryHandlers
    {
        public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, BaseResponse<List<PeopleResponseDto>>>
        {
            private readonly IPeopleContext _context;
            private readonly IMapper _mapper;

            public GetPeopleQueryHandler(IPeopleContext databaseContext, IMapper mapper)
            {
                _context = databaseContext;
                _mapper = mapper;
            }

            public async Task<BaseResponse<List<PeopleResponseDto>>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var people = await _context.People
                                    .Include(x => x.Addresses)
                                    .Include(x => x.PhoneNumbers)
                                    .Include(x => x.Emails)
                                    .Select(x => _mapper.Map<PeopleResponseDto>(x))
                                    .ToListAsync(cancellationToken);

                    return new BaseResponse<List<PeopleResponseDto>>("", people);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<List<PeopleResponseDto>>("Error getting data", null, ex);
                }

            }
        }
    }
}
