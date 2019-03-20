using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTelefonica.Data;
using FluentNHibernate.Data;
using ListaTelefonica.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadeGenericaController<RepositoryBase, EntidadeBase, TipoPk> : ControllerBase        
        where EntidadeBase : Entidade<TipoPk>
        where RepositoryBase : Reposotory<EntidadeBase, TipoPk>
        
    {
        public RepositoryBase Repositorio { get; set; }

        public EntidadeGenericaController(RepositoryBase repositorio)
        {
            Repositorio = repositorio;
        }


        [HttpGet]
        public EntidadeBase[] Get()
        {
            return Repositorio.GetAll().ToArray(); ;
        }


        [HttpGet("{id}")]
        public EntidadeBase Get(TipoPk id)
        {            
            return Repositorio.GetAll().Where(a => id.Equals(a.Id)).FirstOrDefault();         
        }

        [HttpPost]
        public void Post([FromBody]EntidadeBase entidade)
        {
            Repositorio.Save(entidade );
        }

        [HttpDelete]
        public void Delete(TipoPk id)
        {
            Repositorio.Delete(id);
        }

    }
}