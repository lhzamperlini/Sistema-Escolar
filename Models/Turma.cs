using System;
using System.ComponentModel;
using Sistema_Escolar.Validations;

namespace API.Models
{
    public class Turma
    {
        public Turma () => CriadoEm = DateTime.Now;

        public int Id { get; set; }
        public int CodigoTurma{get; set;}
        public string ProfessorCpf{get;set;}
        public virtual Professor Professor { get; set; }
        public string disciplina {get; set;}
        public TimeSpan horario {get; set;}
        public double valor{get; set;}
        public DateTime CriadoEm { get; set; }
    }
}