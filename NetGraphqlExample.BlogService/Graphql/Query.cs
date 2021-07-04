using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using NetGraphqlExample.BlogService.Repo;

namespace NetGraphqlExample.BlogService.Graphql
{
    public class Query
    {

        public string Hello() => "Hello world";
        // public string Hello(string name) => $"Hello {name}";

        // public SimplePost SimplePost() => new SimplePost
        // {
        //     Author = new SimplePost.User
        //     {
        //         Name = "John Doe"
        //     },
        //     Title = "Answer to the Ultimate Question of Life, the Universe, and Everything",
        //     Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus et turpis erat.",
        //     Comments = new List<SimplePost.Comment>
        //         {
        //             new SimplePost.Comment()
        //             {
        //                 Author = new SimplePost.User
        //                 {
        //                     Name = "Jane Doe"
        //                 },
        //                 Text = "Strange.."
        //             },
        //             new SimplePost.Comment()
        //             {
        //                 Author = new SimplePost.User
        //                 {
        //                     Name = "Richard Roe"
        //                 },
        //                 Text = "I thought that it was 42"
        //             }
        //         }
        // };

        //public Post GetPost(int id, [Service] IPostRepository postRepository) => postRepository.GetById(id);
        public Task<Post> GetPostAsync(int id, IResolverContext context, [Service] IPostRepository postRepository)
            => context.BatchDataLoader<int, Post>(
                (ids, cancellationToken) => Task.FromResult((IReadOnlyDictionary<int, Post>)postRepository.GetAllById(ids).ToDictionary(p => p.Id)))
                .LoadAsync(id, new System.Threading.CancellationToken());

        public IReadOnlyList<Post> GetPosts([Service] IPostRepository postRepository) => postRepository.GetAll();
    }
}
