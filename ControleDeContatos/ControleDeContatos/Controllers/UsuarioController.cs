using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {

            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();


            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();

        }
        public IActionResult Editar(int id) {

            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);

            
            return View(usuario);
        }
        public IActionResult ApagarConfirmacao(int id) {

            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);

        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";

                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar seu contato!";

                }
                return RedirectToAction("Index");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos apagar o usuario, tente novamente. Detalhe do erro: {erro.Message}";
                return View("Index");

            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario criado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos criar seu usuario, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {

                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    }; 

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos atualizar seu usuario, tenta novamente, detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}


