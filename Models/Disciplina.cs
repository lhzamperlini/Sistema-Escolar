using System;


namespace API.Models
{
    public class Disciplina
    {
        public Disciplina () => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfProfessor { get; set; }
        public string Nomeprofessor { get; set; }
        public DateTime CriadoEm { get; set; }
       


        
       


    }
}