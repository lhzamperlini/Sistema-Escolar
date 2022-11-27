using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            Turma turmaExistente = _context.Turmas.FirstOrDefault(a => a.CodigoTurma == turma.CodigoTurma);
            if(turmaExistente == null){
                if(professor !=null){
                    turma.Professor = professor;
                    _context.Turmas.Add(turma);
                    _context.SaveChanges();
                    return Created("", turma);
                }
                return NotFound("Nenhum professor cadastrado no sistema com esse Cpf");
            }
            return BadRequest("Uma turma com esse mesmo código já está cadastrada, por favor coloque outro codigo");

        }

        // GET: /api/turma/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<Turma> turmas = 
                _context.Turmas.Include(p => p.Professor).ToList();

            if(turmas.Count == 0) return NotFound();

            return Ok(turmas);
        } 
       
        // GET: /api/turma/buscar/{CodigoTurma}
        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            Turma turma = _context.Turmas.
                FirstOrDefault(a => a.Id.Equals(id));
            return turma != null ? Ok(turma) : NotFound();
        }

        // DELETE: /api/turma/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Turma turma = _context.Turmas.Find(id);
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