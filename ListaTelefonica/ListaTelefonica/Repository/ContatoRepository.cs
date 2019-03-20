using ListaTelefonica.Data;
using ListaTelefonica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Repository
{
    public class ContatoRepository : Reposotory<Contato, int>
    {
        public ContatoRepository(IUnitOfWork<Contato> unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}
