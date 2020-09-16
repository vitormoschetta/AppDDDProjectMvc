using System;
using System.ComponentModel.DataAnnotations;

namespace AppDDDProject.AppMvc.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Email { get; set; }
    }
}