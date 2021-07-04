using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using NetGraphqlExample.BlogService.Repo;

namespace NetGraphqlExample.BlogService.Graphql
{
    public interface ICommentDataLoader : IDataLoader<int, Comment[]>
    {
    }

    public class CommentDataLoader : GroupedDataLoader<int, Comment>, ICommentDataLoader
    {
        private readonly ICommentRepository _commentRepository;

        public CommentDataLoader(
            ICommentRepository CommentRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions<int>? options = null)
            : base(batchScheduler, options)
        {
            _commentRepository = CommentRepository;
        }

        protected override Task<ILookup<int, Comment>> LoadGroupedBatchAsync(IReadOnlyList<int> idPosts, CancellationToken cancellationToken)
            => Task.FromResult(_commentRepository.GetAllForPosts(idPosts));
    }
}
