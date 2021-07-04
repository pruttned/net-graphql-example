using System.Threading.Tasks;
using GreenDonut;

namespace NetGraphqlExample.BlogService.Graphql
{
    public class Comment
    {
        public int IdAuthor { get; set; }
        public string Text { get; set; } = null!;
        public int Id { get; set; }
        public int IdPost { get; set; }

        public Task<User> AuthorAsync(IUserDataLoader userLoader)
            => userLoader.LoadAsync(IdAuthor);
    }
}
