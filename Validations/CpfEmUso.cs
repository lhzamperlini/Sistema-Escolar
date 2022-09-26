using System.ComponentModel.DataAnnotations;
using System.Linq;
using API.Models;

namespace Sistema_Escolar.Validations
{
    public class CpfEmUso : ValidationAttribute
    {
        // public CpfEmUso(string cpf) { }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = (string)value;

            DataContext context =
                (DataContext)validationContext.GetService(typeof(DataContext));

            Aluno aluno = context.Alunos.FirstOrDefault
                (a => a.Cpf.Equals(cpf));
                
            if (aluno == null)
            {
                //sucesso
                return ValidationResult.Success;
            }
            //erro
            return new ValidationResult("O CPF do aluno já está em uso!");
        }
    }
}