using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using NetGraphqlExample.BlogService.Graphql;

namespace NetGraphqlExample.BlogService.Repo
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IReadOnlyList<User>> GetAllByIdAsync(IReadOnlyList<int> ids);
    }

    public class UserRepository : IUserRepository
    {
        private const string BaseUrl = "http://localhost:5002/user";

        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }

        public Task<IReadOnlyList<User>> GetAllByIdAsync(IReadOnlyList<int> ids)
        {
            _logger.LogInformation("UserRepository.GetAllById {0}", string.Join(", ", ids));
            return BaseUrl.PostJsonAsync(ids).ReceiveJson<IReadOnlyList<User>>();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            _logger.LogInformation("UserRepository.GetById {0}", id);
            return (await BaseUrl.PostJsonAsync(new[] { id }).ReceiveJson<IReadOnlyList<User>>()).First();
        }
    }
}
