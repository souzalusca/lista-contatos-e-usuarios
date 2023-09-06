using ControleDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]

        public String Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login do usuário")]

        public String Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "o e-mail informado não válido")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário")]

        public PerfilEnum? Perfil { get; set; }




    }
}
