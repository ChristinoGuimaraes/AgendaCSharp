using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Data
{
    public class Entidade<TipoPk>
    {
        public TipoPk Id { get; set; }
    }
}
