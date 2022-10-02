using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/professor")]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;
        public ProfessorController(DataContext context) =>
            _context = context;

        // POST: /api/professor/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Professor professor)
        {
            
            _context.Professores.Add(professor);
            _context.SaveChanges();
            return Created("", professor);
        }

        // GET: /api/professor/listar
        [HttpGet]
        [Route("listar")]
<<<<<<< HEAD
        public IActionResult Listar() => Ok(_context.Professores.ToList());
=======
        public IActionResult Listar() => Ok( _context.Professores.ToList());
>>>>>>> Nova_Branch
       
        // GET: /api/professor/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{cpf}")]
        public IActionResult Buscar([FromRoute] string cpf)
        {
<<<<<<< HEAD
            Professor professor = _context.Professores.
                FirstOrDefault(a => a.Cpf.Equals(cpf));
=======
            Professor professor = _context.Professores.FirstOrDefault(a => a.Cpf.Equals(cpf));

>>>>>>> Nova_Branch
            return professor != null ? Ok(professor) : NotFound();
        }

        // DELETE: /api/professor/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Professor professor = _context.Professores.Find(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
                _context.SaveChanges();
                return Ok(professor);
            }
            return NotFound();
        }

        // PATCH: /api/professor/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Professor professor)
        {
            try
            {
                _context.Professores.Update(professor);
                _context.SaveChanges();
                return Ok(professor);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}