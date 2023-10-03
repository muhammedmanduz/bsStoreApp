using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        //DI
        private readonly IRepositoryManager _manager;

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Book CreateOneBook(Book book)
        {
            if (book is null)
                throw new ArgumentNullException(nameof(book));//hata fırlat : mumkundur.


            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            //check Entity :var mı yok mu
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity != null)//yok ise
                throw new Exception($"Book With id:{id} could not find.");//hata fırlat

            _manager.Book.DeleteOneBook(entity);//varsa sil
            _manager.Save();

        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
          return _manager.Book.GetAllBooks(trackChanges);//izleme ifadesi
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            return _manager.Book.GetOneBookById(id, trackChanges);
        }

        public void UpdateOneBook(int id, Book book,bool trackChanges)
        {
            //check: varlık var mı?
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null) //yoksa
              throw new Exception($"Book with id:{id} could not found");//hata  fırlat

            //check param
            if(book is null)
                throw new ArgumentNullException(nameof(book));//bos ise hata firlat

            entity.Title = book.Title;
            entity.Price = book.Price;
            
            _manager.Book.Update(entity);//varsa update yap
            _manager.Save();
        }
    }
}
