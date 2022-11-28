using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    //Data Annotations
    public class Boletim
    {
        public Boletim () => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Aluno Aluno {get; set;}
        public string Status {get; set;}
        public int CodigoTurma{get; set;}
        public string AlunoCpf {get; set;}
        public double NotaUm { get; set;}
        public double NotaDois { get; set;}
        public double NotaTres { get; set;}
        public double Media { get; set;}
        public DateTime CriadoEm { get; set; }

    }
}