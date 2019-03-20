using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Data
{
    public interface IUnitOfWork <Entidade>
    {
        void Save(Entidade entidade);
        void Delete(Entidade entidade);
        Entidade Get(object id);
        IEnumerable<Entidade> GetAll();

    }
}
