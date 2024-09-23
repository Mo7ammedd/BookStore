using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.DataAcess.Data;

namespace BookStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Product obj)
        {
            var oneFromDb = _db.Products.FirstOrDefault(s => s.Id == obj.Id);
            if (oneFromDb != null)
            {
                if (obj.ImageUrl != null)
                {
                    oneFromDb.ImageUrl = obj.ImageUrl;
                }
                oneFromDb.Title = obj.Title;
                oneFromDb.Description = obj.Description;
                oneFromDb.Author = obj.Author;
                oneFromDb.ISBN = obj.ISBN;
                oneFromDb.ListPrice = obj.ListPrice;
                oneFromDb.Price = obj.Price;
                oneFromDb.Price50 = obj.Price50;
                oneFromDb.Price100 = obj.Price100;
                oneFromDb.CategoryId = obj.CategoryId;
            }
        }
    }
}
