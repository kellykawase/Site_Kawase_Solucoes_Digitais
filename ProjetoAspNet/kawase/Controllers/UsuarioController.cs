using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kawase.Models;
using Microsoft.AspNetCore.Http;

namespace Kawase.Controllers
{
    public class UsuarioController: Controller
    {
    public IActionResult Listar()
        {
           
            UsuarioRepository ur = new UsuarioRepository();
            List<Usuario> usuarios = ur.Query();
            return View(usuarios);
        }
        
        public IActionResult Editar(int Id)
    {
                    
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuario =  ur.BuscarPorId(Id); 
            return View(usuario);
    }

        [HttpPost]
        public IActionResult Editar(Usuario u)
    {         
            UsuarioRepository ur = new UsuarioRepository();
            ur.Atualizar(u);
            ViewBag.Mensagem = "Usuario atualizado com sucesso!";
            return RedirectToAction("Listar");
    }
                public IActionResult Login()
        {
            return Redirect("../Cliente/Listar");
        }
       
    }
}