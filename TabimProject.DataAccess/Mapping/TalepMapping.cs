
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProject.Model;

namespace TabimProject.DataAccess.Mapping
{
    class TalepMapping: EntityTypeConfiguration<Talep>
    {
        public TalepMapping()
        {
            HasRequired(a => a.User)
               .WithMany(a => a.Taleps)
               .HasForeignKey(a => a.UserID);

            Property(a => a.Ad)
                .HasMaxLength(100)
                .IsRequired();

            Property(a => a.Soyad)
               .HasMaxLength(100)
               .IsRequired();

            Property(a => a.Dosya)
               .HasMaxLength(100)
               .IsRequired();

        }
    }
}
