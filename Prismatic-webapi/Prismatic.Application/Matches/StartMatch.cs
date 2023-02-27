using MediatR;

namespace Prismatic.Application.Matches
{
    public class StartMatchRequest : IRequest
    {

    }

    public class StartMatchResponse : IRequestHandler<StartMatchRequest>
    {
        public StartMatchResponse()
        {

        }

        public Task Handle(StartMatchRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}