using System;
using System.ComponentModel.DataAnnotations;
using Sistema_Escolar.Validations;

namespace API.Models
{
    //Data Annotations
    public class Aluno
    {
        public Aluno () => CriadoEm = DateTime.Now;
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }

        
        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(
            11,
            MinimumLength = 11,
            ErrorMessage = "O campo CPF deve conter 11 caracteres!"
        )]
        // [CpfEmUso]
        public string Cpf { get; set; }

        public string Rgm { get; set; }

        [EmailAddress(
            ErrorMessage = "E-mail inválido!"
        )]
        public string Email { get; set; }
        public string telefone {get; set;}

        public DateTime Nascimento { get; set; }

        public DateTime CriadoEm { get; set; }

        public int CodigoTurma{get; set;} //Código da turma


    }
}