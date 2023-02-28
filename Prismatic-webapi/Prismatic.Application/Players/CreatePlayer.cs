using MediatR;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Repositories;

namespace Prismatic.Application.Players
{
    public class CreatePlayerRequest : IRequest<Guid>
    {
        public CreatePlayerRequest(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }

    public class CreatePlayerResponse : IRequestHandler<CreatePlayerRequest, Guid>
    {
        private readonly IPlayerRepository _playerRepository;

        public CreatePlayerResponse(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Guid> Handle(CreatePlayerRequest request, CancellationToken cancellationToken)
        {
            return await _playerRepository.Add(new Player { Username = request.Username, Status = Status.Offline });
        }
    }
}