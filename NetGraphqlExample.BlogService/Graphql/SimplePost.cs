using System.Collections.Generic;

namespace NetGraphqlExample.BlogService.Graphql
{
    public class SimplePost
    {
        public class User
        {
            public string Name { get; set; } = null!;
        }

        public class Comment
        {
            public string Text { get; set; } = null!;
            public User Author { get; set; } = null!;
        }

        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public User Author { get; set; } = null!;
        public List<Comment> Comments { get; set; } = null!;
    }
}
