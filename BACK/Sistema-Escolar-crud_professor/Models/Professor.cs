using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string Cpf { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}