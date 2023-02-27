using Microsoft.AspNetCore.SignalR;
using Prismatic.Domain.Entities;

namespace Prismatic.Infra.Hubs
{
    public static class LobbyHubExtensions
    {
        public static async Task NotifyPlayerJoined(this IClientProxy group, Guid lobbyId, Player player, CancellationToken ct) 
        {
            await group.SendCoreAsync("PLAYER_JOINED", new object[] { player }, ct);
        }
    }
}