using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;


namespace API.Controllers
{
    
    public class AlunoDisciplinaController : ControllerBase
    {
        private readonly DataContext _context;
        public AlunoDisciplinaController(DataContext context) => _context = context; 


        //Cria e salvar nota da disciplina do aluno
        public void AdicionaNotaAluno(Aluno aluno, Disciplina disciplina, int nota1, int nota2)
        {
            var alunoDisciplina = new AlunoDisciplina();

            alunoDisciplina.Aluno = aluno;
            alunoDisciplina.AlunoId = aluno.Id;
            alunoDisciplina.Disciplina = disciplina;
            alunoDisciplina.DisciplinaId = disciplina.Id;
            alunoDisciplina.nota1 = nota1;
            alunoDisciplina.nota2 = nota2;

            _context.AlunoDisciplinas.Add(alunoDisciplina);
            _context.SaveChanges();

        }

         //calcula a média das notas do aluno e a salva no banco
        public void calcularNotaAluno(Aluno aluno, Disciplina disciplina)
        {
            AlunoDisciplina alunoDisciplina = _context.AlunoDisciplinas.FirstOrDefault(a => a.AlunoId == aluno.Id && a.DisciplinaId == disciplina.Id);

            if (alunoDisciplina != null)
            {
                alunoDisciplina.MediaNota = (alunoDisciplina.nota1 + alunoDisciplina.nota2) / 2;
                _context.AlunoDisciplinas.Update(alunoDisciplina);
                _context.SaveChanges();

            }else{

                AdicionaNotaAluno(aluno, disciplina, 0, 0); //cria uma aluno para a disciplina com notas zeradas

            }

        }

        //busca as notas do aluno da disciplina informada
        public int buscarNotasAluno(Aluno aluno, Disciplina disciplina){
           
        AlunoDisciplina alunoDisciplina = _context.AlunoDisciplinas.FirstOrDefault(a => a.AlunoId == aluno.Id && a.DisciplinaId == disciplina.Id);
           
            return alunoDisciplina.MediaNota;
        }



        //atualliza as notas do aluno da disciplina informada
        public void atualizarNotas(Aluno aluno, Disciplina disciplina, int nota1, int nota2)
        {
            AlunoDisciplina alunoDisciplina = _context.AlunoDisciplinas.FirstOrDefault(a => a.AlunoId == aluno.Id && a.DisciplinaId == disciplina.Id);

            if (alunoDisciplina != null)
            {
                alunoDisciplina.nota1 = nota1;
                alunoDisciplina.nota2 = nota2;
                _context.AlunoDisciplinas.Update(alunoDisciplina);
                _context.SaveChanges();

            }
        }




       

       //buscas a lista disciplinas pela turma
        public List<Disciplina> buscar(int CodigoTurma){

            var turmas = _context.Turmas.ToList().Where(a => a.CodigoTurma == CodigoTurma);

            List<Disciplina> disciplinasTurma = new List<Disciplina>(); 

             for(int i =0; i < turmas.Count(); i++){

            disciplinasTurma.Add(_context.Disciplinas.FirstOrDefault(a => a.Id == turmas.ElementAt(i).DisciplinaId)); //adiciona a disciplina da turma atual na lista de disciplinas do aluno
           }

          return disciplinasTurma;
        }

        //Limpar Tabela Disciplinas
        public void LimparTabelaDisciplinas()
        {
            var disciplinas = _context.Disciplinas.ToList();
            _context.Disciplinas.RemoveRange(disciplinas); //remove todas as disciplinas
            _context.SaveChanges();
        }

        //Limpar Tabela Alunos
        public void LimparTabelaAlunos()
        {
            var alunos = _context.Alunos.ToList();
            _context.Alunos.RemoveRange(alunos); //remove todas as disciplinas
            _context.SaveChanges();
        }

        //Limpar Tabela Turmas
        public void LimparTabelaTurmas()
        {
            var turmas = _context.Turmas.ToList();
            _context.Turmas.RemoveRange(turmas); //remove todas as disciplinas
            _context.SaveChanges();
        }

        //limpar tabela Professor
        public void LimparTabelaProfessor()
        {
            var professores = _context.Professores.ToList();
            _context.Professores.RemoveRange(professores); //remove todas as disciplinas
            _context.SaveChanges();
        }

        //limpar tabela AlunoDisciplina
        public void LimparTabelaAlunoDisciplina()
        {
            var alunoDisciplinas = _context.AlunoDisciplinas.ToList();
            _context.AlunoDisciplinas.RemoveRange(alunoDisciplinas); //remove todas as disciplinas
            _context.SaveChanges();
        }

        public void LimparTabelas()
        {
            LimparTabelaDisciplinas();
            LimparTabelaAlunos();
            LimparTabelaTurmas();
            LimparTabelaProfessor();
            LimparTabelaAlunoDisciplina();
        }




        ////busca todas as disciplinas do aluno pelo cpf
        public List<Disciplina> Buscar(string cpfAluno){

            
            var aluno = _context.Alunos.FirstOrDefault(a => a.Cpf == cpfAluno); //busca um aluno pelo cpf

            var turmas = _context.Turmas.ToList().Where(a => a.CodigoTurma == aluno.CodigoTurma); //busca todas as turmas do aluno
          
            List<Disciplina> disciplinasAluno = new List<Disciplina>(); //lista de disciplinas do aluno
               

           for(int i =0; i < turmas.Count(); i++){

            disciplinasAluno.Add(_context.Disciplinas.FirstOrDefault(a => a.Id == turmas.ElementAt(i).DisciplinaId)); //adiciona a disciplina da turma atual na lista de disciplinas do aluno
           }

            return disciplinasAluno;
        }


    }

}