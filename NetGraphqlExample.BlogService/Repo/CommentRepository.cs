using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using NetGraphqlExample.BlogService.Graphql;

namespace NetGraphqlExample.BlogService.Repo
{
    public interface ICommentRepository
    {
        ILookup<int, Comment> GetAllForPosts(IReadOnlyList<int> idPosts);
    }

    public class CommentRepository : ICommentRepository
    {
        private List<Comment> _entities;
        private readonly ILogger<CommentRepository> _logger;

        public CommentRepository(ILogger<CommentRepository> logger)
        {
            var id = 100;
            var generator = new Bogus.Faker<Comment>()
                .RuleFor(u => u.Id, f => id++)
                .RuleFor(u => u.IdPost, f => f.Random.Int(1, 10))
                .RuleFor(u => u.IdAuthor, f => f.Random.Int(1, 10))
                .RuleFor(u => u.Text, f => f.Lorem.Paragraphs())
            ;

            _entities = generator.Generate(30);
            _logger = logger;
        }

        public ILookup<int, Comment> GetAllForPosts(IReadOnlyList<int> idPosts)
        {
            _logger.LogInformation("CommentRepository.GetAllForPosts {0}", string.Join(", ", idPosts));
            return _entities.Where(c => idPosts.Contains(c.IdPost)).ToLookup(c => c.IdPost);
        }
    }
}
