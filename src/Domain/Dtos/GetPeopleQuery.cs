namespace Domain.Dtos
{
    using MediatR;

    public class GetPeopleQuery : IRequest<BaseResponse<List<PeopleResponseDto>>>
    {
    }
}
