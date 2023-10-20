using System.Linq.Expressions;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        //Nesnelerimizi kontrol etmemizi sağlayan ekleme çıkarma yaptığımız yardımcı sınıflar

        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        //Yapılan işlemde dönecek verinin 1 den fazla olabilmesi için allasync kullanırız
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        //Yapılan işlemde dönecek verinin 1 tane olabilmesi için T nesnesini async olarak döndürüyoruz
        Task<T> GetByGuidAsync(Guid id);
        //bu metotla beraber aradığımız id ye karşılık gelen nesneyi bulmamıza yarayacak
        Task<T> UpdateAsync(T entity);
        //Tek bir değeri güncelleyebilmek için updateasync kullanıyoruz
        Task<T> DeleteAsync(T entity);
        //bulunan article ı true dan false a çekmek için gereken metod
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        //değeri verip içerisindeki işlemleri any ye göre yaptırmak için bu metod kullanılır
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        //article içinde bulunan nesnelerin sayısını bize döndürür




    }
}
