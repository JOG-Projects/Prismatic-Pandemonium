using MediatR;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Repositories;

namespace Prismatic.Application.Lobbies
{
    public class CreateLobbyRequest : IRequest<Guid>
    {
        public CreateLobbyRequest(Guid ownerId)
        {
            OwnerId = ownerId;
        }

        public Guid OwnerId { get; }
    }

    public class CreateLobbyHandler : IRequestHandler<CreateLobbyRequest, Guid>
    {
        private readonly ILobbyRepository _lobbyRepository;
        private readonly IPlayerRepository _playerRepository;

        public CreateLobbyHandler(ILobbyRepository lobbyRepository, IPlayerRepository playerRepository)
        {
            _lobbyRepository = lobbyRepository;
            _playerRepository = playerRepository;
        }

        public async Task<Guid> Handle(CreateLobbyRequest request, CancellationToken ct)
        {
            var owner = await _playerRepository.Get(request.OwnerId) ?? throw new Exception("Jogador não existe na base");

            var lobby = new Lobby { OwnerId = request.OwnerId };
            lobby.Players.Add(owner);

            await _lobbyRepository.Add(lobby);
            await _playerRepository.SetCurrentLobby(request.OwnerId, lobby);

            return lobby.Id;
        }
    }
}
