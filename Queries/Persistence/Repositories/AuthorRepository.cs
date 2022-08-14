using Queries.Core.Domain;
using Queries.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace Queries.Persistence.Repositories
{
    public class AuthorRepository : Repository<PlutoContext, Author>, IAuthorRepository
    {
        public AuthorRepository(PlutoContext context) : base(context)
        {
        }

        public Author GetAuthorWithCourses(int id)
        {
            return Context.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == id);
        }
    }
}