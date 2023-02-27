using MediatR;

namespace Prismatic.Application.Matches
{
    public class StartMatchRequest : IRequest<StartMatchResponse>
    {

    }

    public class StartMatchResponse : IRequestHandler<StartMatchRequest, StartMatchResponse>
    {
        public StartMatchResponse()
        {

        }

        public Task<StartMatchResponse> Handle(StartMatchRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}