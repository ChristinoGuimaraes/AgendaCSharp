using ListaTelefonica.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.Map
{    
    public class ContatoMap: ClassMap<Contato>
    {
        public ContatoMap()
        {
            Table("contato");
            Id(p => p.Id).Column("id").GeneratedBy.Identity();
            Map(p => p.Nome).Column("nome").Length(100);
            HasMany(p => p.Telefones).KeyColumn("id_contato").ForeignKeyConstraintName("none");

        }
    }
}
