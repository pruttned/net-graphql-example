using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using NetGraphqlExample.BlogService.Graphql;

namespace NetGraphqlExample.BlogService.Repo
{
    public interface IPostRepository
    {
        Post GetById(int id);
        IReadOnlyList<Post> GetAllById(IReadOnlyList<int> ids);
        IReadOnlyList<Post> GetAll();
    }

    public class PostRepository : IPostRepository
    {
        private List<Post> _entities;
        private readonly ILogger<PostRepository> _logger;

        public PostRepository(ILogger<PostRepository> logger)
        {
            var id = 1;
            var generator = new Bogus.Faker<Post>()
                .RuleFor(u => u.Id, f => id++)
                .RuleFor(u => u.IdAuthor, f => f.Random.Int(1, 10))
                .RuleFor(u => u.Title, f => f.Lorem.Slug())
                .RuleFor(u => u.Text, f => f.Lorem.Paragraphs())
            ;

            _entities = generator.Generate(10);
            _logger = logger;
        }

        public IReadOnlyList<Post> GetAllById(IReadOnlyList<int> ids)
        {
            _logger.LogInformation("PostRepository.GetAllById {0}", string.Join(", ", ids));
            return _entities.Where(u => ids.Contains(u.Id)).ToList();
        }

        public IReadOnlyList<Post> GetAll()
        {
            _logger.LogInformation("PostRepository.GetAll");
            return _entities.ToList();
        }

        public Post GetById(int id)
        {
            _logger.LogInformation("PostRepository.GetById {0}", id);
            return _entities.Single(u => u.Id == id);
        }
    }
}
