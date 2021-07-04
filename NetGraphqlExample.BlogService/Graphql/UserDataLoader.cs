using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using NetGraphqlExample.BlogService.Repo;

namespace NetGraphqlExample.BlogService.Graphql
{
    public interface IUserDataLoader : IDataLoader<int, User>
    {
    }
    
    public class UserDataLoader : BatchDataLoader<int, User>, IUserDataLoader
    {
        private readonly IUserRepository _userRepository;

        public UserDataLoader(
            IUserRepository userRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions<int>? options = null)
            : base(batchScheduler, options)
        {
            _userRepository = userRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, User>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
            => (await _userRepository.GetAllByIdAsync(keys)).ToDictionary(u => u.Id);
    }
}
