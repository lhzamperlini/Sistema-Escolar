using System;
using System.ComponentModel;
using Sistema_Escolar.Validations;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> Nova_Branch

namespace API.Models
{
    public class Turma
    {
        public Turma () => CriadoEm = DateTime.Now;

        public int Id { get; set; }
<<<<<<< HEAD

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email {get; set; }

        public string Cpf { get; set; }
        public DateTime CriadoEm { get; set; }
=======
        public int CodigoTurma{get; set;} //Código da turma
        public int DisciplinaId {get; set;} //Relacionamento com a tabela Disciplina
        public Disciplina Disciplina {get; set;} //Relacionamento com a tabela Disciplina
        public string periodo {get; set;}
        public string horario {get; set;} //horario da aula
        public string sala {get; set;}
        public DateTime CriadoEm { get; set; }

        
>>>>>>> Nova_Branch
    }
}