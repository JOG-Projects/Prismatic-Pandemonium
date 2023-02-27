using MediatR;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Repositories;

namespace Prismatic.Application.Lobbies
{
    public class CreateLobbyRequest : IRequest<Guid>
    {
        public CreateLobbyRequest(Player owner)
        {
            Owner = owner;
        }

        public Player Owner { get; }
    }

    public class CreateLobbyResponse : IRequestHandler<CreateLobbyRequest, Guid>
    {
        private readonly ILobbyRepository _lobbyRepository;

        public CreateLobbyResponse(ILobbyRepository repository)
        {
            _lobbyRepository = repository;
        }

        public async Task<Guid> Handle(CreateLobbyRequest request, CancellationToken cancellationToken)
        {
            var lobby = new Lobby { Players = new List<Player> { request.Owner } };
            return await _lobbyRepository.Add(lobby);
        }
    }
}
