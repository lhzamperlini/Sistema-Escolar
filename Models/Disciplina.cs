using System;


namespace API.Models
{
    public class Disciplina
    {
        public Disciplina () => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfProfessor { get; set; }
        public Professor professor { get; set; }
        public DateTime CriadoEm { get; set; }
       


        public Disciplina(Professor professor, string CpfProfessor)
        {
            this.professor = professor;
            this.CpfProfessor = CpfProfessor;
        }
       


    }
}