using WebApi.Data;
using WebApi.Models;
using WebApi.Services.IServices;

namespace WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _db;

        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Create(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book == null)
            {
                return false;
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _db.Books.Find(id);
        }

        public void Update(int id, Book book)
        {
            var bookDb = GetById(id);

            bookDb.Description = book.Description;
            bookDb.Name = book.Name;

            _db.Books.Update(bookDb);
            _db.SaveChanges();
        }
    }
}
