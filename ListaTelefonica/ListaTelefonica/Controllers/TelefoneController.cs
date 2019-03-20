using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTelefonica.Entity;
using ListaTelefonica.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.Controllers
{    
    public class TelefoneController : EntidadeGenericaController<TelefoneRepository, Telefone, int>
    {
        public TelefoneController(TelefoneRepository repositorio) : base(repositorio)
        {
        }
    }
}