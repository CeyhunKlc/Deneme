using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{ 
    public class DeleteBookCommand
    {   
        private readonly IBookStoreDbContext _dbContext;

        public int BookId { get; set; }
        
        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        { 
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Silinecek Kitap Bulunamadı!");


            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();  
        }
    }
}