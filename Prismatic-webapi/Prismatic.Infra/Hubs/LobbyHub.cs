using Microsoft.AspNetCore.SignalR;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Repositories;

namespace Prismatic.Infra.Hubs
{
    public class LobbyHub : Hub
    {
        private readonly IPlayerRepository _playerRepository;

        public LobbyHub(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public override async Task OnConnectedAsync()
        {
            var username = Context.User!.Identity!.Name ??
                throw new Exception("Connection without username received");

            await _playerRepository.ChangeStatus(username, Context.ConnectionId);

            var player = await _playerRepository.GetByUsername(username);
            var lobby = player.CurrentLobby ?? 
                throw new Exception($"Player: {player.Username} tentou conectar sem um lobbyId");

            await JoinLobby(lobby, player);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var username = Context.User!.Identity!.Name ??
                throw new Exception("Connection without username received");

            await _playerRepository.ChangeStatus(username);

            await base.OnDisconnectedAsync(exception);
        }

        private async Task JoinLobby(Guid lobbyId, Player player)
        {
            var groupName = lobbyId.ToString();

            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            var group = Clients.Group(groupName);

            await group.NotifyPlayerJoined(lobbyId, player, default);
        }
    }
}