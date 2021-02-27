using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kawase.Models;

namespace Kawase.Controllers
{
    public class ClienteController: Controller
    {
        public IActionResult Contato()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contato(Cliente c)
        {
            ClienteRepository cr = new ClienteRepository();
            cr.Insert(c);
            ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
            return View();
        }

        public IActionResult Remover(int Id)
        {
              ClienteRepository cr = new ClienteRepository();
              cr.Remover(Id);
              return RedirectToAction("Listar");
        }

        public IActionResult Listar()
        {
            ClienteRepository cr = new ClienteRepository();
            List<Cliente> clientes = cr.Query();
            return View(clientes);
        }
    }
}