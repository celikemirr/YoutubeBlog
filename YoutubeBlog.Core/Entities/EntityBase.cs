using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlog.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        //Daha benzersiz idler oluşturmak int yerine Guid kullanıyoruz
        // Interface oluşturuyoruz ki bu projede çalışacak olan bir sonraki kişiyi class oluşturmak için zorunlu bırakmalıyız ki projemizin yapısı bozulmasın
        // sınıfı soyut oluşturuyoruz çünkü her değiştirdimiz şeyin veritabanına yansımasını istemiyoruz
        public virtual Guid Id { get; set; } = Guid.NewGuid(); //int seçince 1 er 1 er artıyor fakat guid de bu sorun olabileceği için new guide kullanıyoruz
        public virtual string CreatedBy { get; set; } = "Undefined";
        public virtual string? ModifiendBy { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiendDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}
