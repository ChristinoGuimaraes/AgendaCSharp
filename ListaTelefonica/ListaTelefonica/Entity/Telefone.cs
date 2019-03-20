using ListaTelefonica.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Entity
{
    public class Telefone : Entidade<int>
    {
        public int DDD { get; set; }
        public string Numero { get; set; }
        //public Contato Contato { get; set; }
    }
}
