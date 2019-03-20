using ListaTelefonica.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Data
{
    public abstract class Reposotory<Entidade, TipoPk>
        where Entidade : Entidade<TipoPk>
    {
        protected Data.IUnitOfWork<Entidade> UnitOfWork;

        public Reposotory(IUnitOfWork<Entidade> unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual IEnumerable<Entidade> GetAll()
        {            
            return UnitOfWork.GetAll();
        }

        public void Save(Entidade entidade)
        {
            UnitOfWork.Save(entidade);
        }

        public void Delete(Entidade entidade)
        {
            UnitOfWork.Delete(entidade);
        }

        public void Delete (TipoPk id)
        {
            var item= UnitOfWork.Get(id);
            if (item != null)
            {
                UnitOfWork.Delete(item);
            }
        }


    }
}
