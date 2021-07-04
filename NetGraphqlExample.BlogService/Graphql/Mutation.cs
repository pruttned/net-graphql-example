using System.Threading.Tasks;
using HotChocolate;
using NetGraphqlExample.BlogService.Repo;

namespace NetGraphqlExample.BlogService.Graphql
{
    public class Mutation
    {
        public Task<Comment> AddComment([Service] ICommentRepository commentRepository, int idPost, string text) 
            => Task.FromResult(commentRepository.AddCommnet(idPost, 1, text));
    }
}
