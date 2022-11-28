using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sistema_Escolar.Validations;

namespace API.Models
{
    public class Professor
    {
        public Professor() => CriadoEm = DateTime.Now;

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(
            11,
            MinimumLength = 11,
            ErrorMessage = "O campo CPF deve conter 11 caracteres!"
        )]
         [CpfEmUso]
        public string Cpf { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}