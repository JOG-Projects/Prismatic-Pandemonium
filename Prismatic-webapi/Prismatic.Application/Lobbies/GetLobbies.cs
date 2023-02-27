using MediatR;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Repositories;

namespace Prismatic.Application.Lobbies
{
    public class GetLobbiesRequest : IRequest<List<Lobby>>
    {
    }

    public class GetLobbiesHandler : IRequestHandler<GetLobbiesRequest, List<Lobby>>
    {
        private readonly ILobbyRepository _lobbyRepository;

        public GetLobbiesHandler(ILobbyRepository lobbyRepository)
        {
            _lobbyRepository = lobbyRepository;
        }

        public async Task<List<Lobby>> Handle(GetLobbiesRequest request, CancellationToken cancellationToken)
        {
            return await _lobbyRepository.GetAll();
        }
    }
}
