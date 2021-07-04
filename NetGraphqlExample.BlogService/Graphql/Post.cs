using System.Collections.Generic;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate;
using NetGraphqlExample.BlogService.Repo;

namespace NetGraphqlExample.BlogService.Graphql
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int IdAuthor { get; set; }

        // public User Author()
        //     => new User
        //     {
        //         Id = 1,
        //         Name = "John Doe",
        //         Email = "JohnDoe@email.com",
        //         Address = new Address
        //         {
        //             City = "The City",
        //             Street = "Nice street",
        //         }
        //     };

        // public Task<User> AuthorAsync([Service] IUserRepository users)
        //     => users.GetByIdAsync(IdAuthor);

        public Task<User> AuthorAsync(IUserDataLoader userLoader)
            => userLoader.LoadAsync(IdAuthor);

        public Task<Comment[]> CommentsAsync(ICommentDataLoader commentDataLoader)
            => commentDataLoader.LoadAsync(Id);
    }
}
