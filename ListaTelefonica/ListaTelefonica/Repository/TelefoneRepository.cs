using ListaTelefonica.Data;
using ListaTelefonica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Repository
{
    public class TelefoneRepository : Reposotory<Telefone, int>
    {
        public TelefoneRepository(IUnitOfWork<Telefone> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
