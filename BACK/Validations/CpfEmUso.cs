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

            Professor professor = context.Professores.FirstOrDefault
                (a => a.Cpf.Equals(cpf));
                
            if (professor == null)
            {
                //sucesso
                return ValidationResult.Success;
            }
            //erro
            return new ValidationResult("O CPF do Professor já está em uso!");
        }
    }
}