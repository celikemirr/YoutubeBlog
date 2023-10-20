using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Repositories.Abstractions;

namespace YoutubeBlog.Data.Repositories.Concretes
{
    //yenilenebilir bir entitybase olsun ki T ye nesneleri yollayabilelim
    //IEntityBase den türememiş hiçbir sınıf burayı kullanamaması için yapıyoruz
    //IRepository e giden entity değerlerin soyut halini oluşturabilmesi için t almıştır
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;

        //Veritabanı nesneleriyle olan ilişkimizi kontrol edeceğimiz için
        //context sınıfımızı burada çağırıyoruz
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //buradaki t nesnesi bizim entity katmanındaki sınıflarımızı belirtiyor
        //hangi sınıfımızı yollarsak onun işlemlerini gerçekleştirmiş oluruz
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        //burada table ı  set etmeseydik her seferinde bu metot içinde bu table ı yazmamız gerekirdi

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }
        //burada bir fonksiyon yazmak istiyoruz ve entity değeri verip bool dönmesini istiyoruz
        //bunu yazmaktaki nedenemiz istenilen article de isdeleted i false olanları getirmemek istememizdir
        //Birden fazla obje dönebileceği için includeproperties ismini veriyoruz
        //entityframeworkcore da bulunan include metodu bulunuyor bu metot ile birbiriyle bağlı olan entitylerimizi döndürebiliriz
        //ve article a image ı ve category i include etmiş olucaz

        //list kullanılmasının sebebi gelen sınıfta birden fazla değer olabilir bundan dolayı
        //ve bu gelen değerlerin hepsinin dönmesini istiyoruz


        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.SingleAsync();
        }
        //getasync metodunda predicate i null belirlemiyoruz çünkü her koşulda dönen 1 adet nesne olmak zorundadır

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));

            return entity;
        }
        //update metodu normalde async çalışmaz fakat biz yapıyı bozmamak amacıyla bu şekilde async çalıştırabiliyoruz

        public async Task<T> DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));

            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
        //Task == Void
    }
}
