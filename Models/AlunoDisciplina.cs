using System;
using System.Collections.Generic;


namespace API.Models
{
    public class AlunoDisciplina
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string cpfAluno { get; set; }
        public int DisciplinaId { get; set; }
        public int MediaNota { get; set; }
        public int nota1 { get; set; }
        public int nota2 { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }

        
    }
}