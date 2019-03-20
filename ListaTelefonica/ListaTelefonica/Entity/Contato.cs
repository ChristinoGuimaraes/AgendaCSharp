using ListaTelefonica.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Entity
{
    public class Contato : Entidade<int>
    {
        
        public string Nome { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }

    }
}
