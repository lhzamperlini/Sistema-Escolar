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

        // POST: /api/turma/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Turma turma)
        {
            Professor professor = _context.Professores.
            FirstOrDefault(a => a.Cpf.Equals(turma.ProfessorCpf));
            if(professor !=null){
                turma.Professor = professor;
                _context.Turmas.Add(turma);
                _context.SaveChanges();
                return Created("", turma);
            }
            return NotFound();

        }

        // GET: /api/turma/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Turmas.ToList());
       
        // GET: /api/turma/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{CodigoTurma}")]
        public IActionResult Buscar([FromRoute] int CodigoTurma)
        {
            Turma turma = _context.Turmas.
                FirstOrDefault(a => a.CodigoTurma.Equals(CodigoTurma));
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