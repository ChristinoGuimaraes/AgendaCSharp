using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTelefonica.Entity;
using ListaTelefonica.Repository;
using ListaTelefonica.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.Controllers
{
    
    public class ContatoController : EntidadeGenericaController<ContatoRepository, Contato, int>
    {
        public ContatoController(ContatoRepository repositorio) : base(repositorio)
        {
        }
    }
}