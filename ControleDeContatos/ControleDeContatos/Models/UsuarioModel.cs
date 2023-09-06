using ControleDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]

        public String Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login do usuário")]

        public String Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "o e-mail informado não válido")]
        public String Email { get; set; }

        [Required(ErrorMessage ="Selecione um perfil para o usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]

        public string Senha { get; set; }

        public DateTime DataDeCadastro { get; set; }
        public DateTime? DataDeAtualizacao { get; set; }

        public bool SenhaValida(string senha) {
            return Senha == senha;
        }

    }
}
