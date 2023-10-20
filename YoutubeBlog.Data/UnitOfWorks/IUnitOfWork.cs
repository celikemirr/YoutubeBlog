using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;
using YoutubeBlog.Data.Repositories.Abstractions;

namespace YoutubeBlog.Data.UnitOfWorks
{
    //bunu kullanmakta ki amacımız bir veriyi güncelleme üzerinden gidelim
    //önce guid ile metodu çağırıcaz sonra update methodu ile güncelliyicez
    //bunun için birden fazla method gerekicek ve bu methodlardan biri bile hatalı olursa
    //unitofwork u kullanıp hata döndürüp bu durumun projemize yansımamasını belirticez
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class,IEntityBase,new();

        Task<int> SaveAsync();
        int save();
    }
    //birden fazla sonuçla karşılaşacağımız için şekillenen sonuca göre çağırmak istediğimiz entity i t de belirtiriz
}
