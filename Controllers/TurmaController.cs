using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/turma")]
    public class TurmaController : ControllerBase
    {
        private readonly DataContext _context;
        public TurmaController(DataContext context) =>
            _context = context;

        //  POST: /api/turma/cadastrar
        //  [HttpPost]
        //  [Route("cadastrar")]
        //  public IActionResult Cadastrar([FromBody] Turma turma)
        //  {
        //    Professor professor = _context.Professores.
        //    FirstOrDefault(a => a.Cpf.Equals(turma.ProfessorCpf));
        //    if (professor != null)
        //    {
        //        turma.Professor = professor;
        //        _context.Turmas.Add(turma);
        //        _context.SaveChanges();
        //       return Created("", turma);
        //    }
        //    return NotFound();
        // }

        // POST: /api/turma/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Turma turma)
        {
            Disciplina discipliana = _context.Disciplinas.
            FirstOrDefault(a => a.Id == turma.DisciplinaId);

            if (discipliana != null)
            {
                turma.Disciplina = discipliana;
                turma.DisciplinaId = discipliana.Id;

                _context.Turmas.Add(turma);
                _context.SaveChanges();
                return Created("", turma);
            }
            return NotFound();

        }
        

        // GET: /api/turma/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar(){

            var turmas = _context.Turmas.ToList();
  
         //para mostrar a disciplina junto e o profesor que esta junto com disciplina
         for(int i = 0; i < turmas.Count; i++){

         turmas[i].Disciplina = _context.Disciplinas.FirstOrDefault(a => a.Id.Equals(turmas[i].DisciplinaId));
         turmas[i].Disciplina.Nomeprofessor = _context.Professores.FirstOrDefault(a => a.Cpf.Equals(turmas[i].Disciplina.CpfProfessor)).Nome;
         turmas[i].Disciplina.CpfProfessor = _context.Professores.FirstOrDefault(a => a.Cpf.Equals(turmas[i].Disciplina.CpfProfessor)).Cpf;

        }

            return Ok(turmas);
        }

        
       
        // GET: /api/turma/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{CodigoTurma}")]
        public IActionResult Buscar([FromRoute] int CodigoTurma)
        {

            Turma turma = _context.Turmas.
                FirstOrDefault(a => a.CodigoTurma.Equals(CodigoTurma));

           try{

             turma.Disciplina = _context.Disciplinas.FirstOrDefault(a => a.Id.Equals(turma.DisciplinaId));
             turma.Disciplina.Nomeprofessor = _context.Professores.FirstOrDefault(a => a.Cpf.Equals(turma.Disciplina.CpfProfessor)).Nome;
             turma.Disciplina.CpfProfessor = _context.Professores.FirstOrDefault(a => a.Cpf.Equals(turma.Disciplina.CpfProfessor)).Cpf;

           }catch(Exception ){


               return NotFound("CODIGO TURMA NAO ENCONTRADO");

           }   

            return turma != null ? Ok(turma) : NotFound();
        }

        // DELETE: /api/turma/deletar/{id}
        [HttpDelete]
        [Route("deletar/{IdTurma}")]
        public IActionResult Deletar([FromRoute] int IdTurma)
        {
            Turma turma = _context.Turmas.Find(IdTurma);
            if (turma != null)
            {
                _context.Turmas.Remove(turma);
                _context.SaveChanges();
                return Ok(turma);
            }
            return NotFound();
        }

        // PATCH: /api/turma/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Turma turma)
        {
            try
            {
                _context.Turmas.Update(turma);
                _context.SaveChanges();
                return Ok(turma);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}