using ListaTelefonica.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Map
{

    public class TelefoneMap : ClassMap<Telefone>
    {
        public TelefoneMap()
        {
            Table("telefone");
            Id(p => p.Id).Column("id").GeneratedBy.Identity();
            Map(p => p.DDD).Column("ddd");
            Map(p => p.Numero).Column("numero").Length(15);
            /*References(p => p.Contato).Column("id_contato")
                .ForeignKey("fk_tefone_contato")
                .Not.Nullable()
                .Cascade.Delete();*/

        }
    }
}
