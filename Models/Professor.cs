using System;

using System.ComponentModel;
using Sistema_Escolar.Validations;


namespace API.Models
{
    public class Professor
    {
        public Professor () => CriadoEm = DateTime.Now;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email {get; set; }
        public string Telefone { get; set; }
        public DateTime CriadoEm { get; set; }


    }
}