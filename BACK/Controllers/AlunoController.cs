using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;
        public AlunoController(DataContext context) =>
            _context = context;

        // GET: /api/aluno/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Alunos.ToList());

        // POST: /api/aluno/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return Created("", aluno);
        }

        // GET: /api/aluno/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{cpf}")]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            Aluno aluno = _context.Alunos.
                FirstOrDefault(a => a.Cpf.Equals(cpf));
            return aluno != null ? Ok(aluno) : NotFound();
        }

        [HttpGet]
        [Route("buscarid/{id}")]
        public IActionResult BuscarId([FromRoute] int id)
        {
            Aluno aluno = _context.Alunos.
                FirstOrDefault(a => a.Id.Equals(id));
            return aluno != null ? Ok(aluno) : NotFound();
        }

        // DELETE: /api/aluno/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Aluno aluno = _context.Alunos.Find(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                _context.SaveChanges();
                return Ok(aluno);
            }
            return NotFound();
        }

        // PATCH: /api/aluno/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Aluno aluno)
        {
            try
            {
                _context.Alunos.Update(aluno);
                _context.SaveChanges();
                return Ok(aluno);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}