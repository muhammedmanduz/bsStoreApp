using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
        }
        //lazy loading:nesne ancak kullanıldıgı anda ilgili ifade newlenecek aksi durumda newleme işlemi yapılmaz
        public IBookRepository Book=>_bookRepository.Value;

        //public IBookRepository Book =>  new BookRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
