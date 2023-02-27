using MediatR;
using Microsoft.AspNetCore.SignalR;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Repositories;
using Prismatic.Infra.Hubs;

namespace Prismatic.Application.Lobbies
{
    public class JoinLobbyRequest : IRequest
    {
        public JoinLobbyRequest(Player player, Guid lobbyId)
        {
            Player = player;
            LobbyId = lobbyId;
        }

        public Guid LobbyId { get; set; }
        public Player Player { get; }
    }

    public class JoinLobbyHandler : IRequestHandler<JoinLobbyRequest>
    {
        private readonly IHubContext<LobbyHub> _lobbyHub;
        private readonly ILobbyRepository _lobbyRepository;

        public JoinLobbyHandler(IHubContext<LobbyHub> lobbyHub, ILobbyRepository lobbyRepository)
        {
            _lobbyHub = lobbyHub;
            _lobbyRepository = lobbyRepository;
        }

        public async Task Handle(JoinLobbyRequest request, CancellationToken ct)
        {
            var lobby = await _lobbyRepository.Get(request.LobbyId) ?? throw new Exception("Lobby não existe");

            var group = _lobbyHub.Clients.Group(request.LobbyId.ToString());

            await group.NotifyPlayerJoined(lobby.Id, request.Player, ct);

            lobby.Players.Add(request.Player);
            await _lobbyRepository.Replace(request.LobbyId, lobby);
        }
    }
}
