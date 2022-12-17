namespace Services.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Domain.Dtos;
    using Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class RegisterPersonCommandHandlers
    {
        public class RegisterPersonCommandHandler : IRequestHandler<RegisterPersonCommand, BaseResponse<bool>>
        {
            private readonly IPeopleContext _context;
            private readonly IMapper _mapper;
            public RegisterPersonCommandHandler(IPeopleContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BaseResponse<bool>> Handle(RegisterPersonCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var person = _mapper.Map<People>(request);
                    _context.People.Add(person);
                    await _context.SaveChangesAsync(cancellationToken);
                    return new BaseResponse<bool>("Added successfully!", true);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<bool>(ex.Message + " " + ex.StackTrace, false, StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}
