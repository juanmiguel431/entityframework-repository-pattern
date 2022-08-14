using Queries.Core;
using Queries.Core.Repositories;
using Queries.Persistence.Repositories;

namespace Queries.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;
        private ICourseRepository _courses;
        private IAuthorRepository _authors;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
        }

        public ICourseRepository Courses => _courses ?? (_courses = new CourseRepository(_context));
        public IAuthorRepository Authors => _authors ?? (_authors = new AuthorRepository(_context));

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}