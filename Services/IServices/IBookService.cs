using WebApi.Models;

namespace WebApi.Services.IServices
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        bool Delete(int id);
        void Create(Book book);
        void Update(int id, Book book);
    }
}
