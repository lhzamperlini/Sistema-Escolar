using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/boletim")]
    public class BoletimController : ControllerBase
    {
        private readonly DataContext _context;
        public BoletimController(DataContext context) =>
            _context = context;

        // POST: /api/boletim/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Boletim boletim)
        {
            Aluno aluno = _context.Alunos.
            FirstOrDefault(a => a.Cpf.Equals(boletim.AlunoCpf));
            Turma turma = _context.Turmas.FirstOrDefault(a => a.CodigoTurma == boletim.CodigoTurma);
            if(aluno !=null && turma != null){
                if( aluno.Media > 60)
                {
                    boletim.Status = "Aprovado";
                }
                else
                {
                    boletim.Status = "Reprovado";
                }
                boletim.Aluno = aluno;
                boletim.Turma = turma;
                _context.Boletins.Add(boletim);
                _context.SaveChanges();
                return Created("", boletim);
            }
            return NotFound();

        }

        // GET: /api/boletim/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Boletins.ToList());

        // GET: /api/boletim/buscar/{codigoTurma}
        [HttpGet]
        [Route("buscar/{codigoTurma}")]
        public IActionResult Buscar([FromRoute] int codigoTurma)
        {
            if (_context.Boletins.ToList().Where(a => a.CodigoTurma == codigoTurma) != null){
                return Ok(_context.Boletins.ToList().Where(a => a.CodigoTurma == codigoTurma));
            }
            return NotFound();
        }

        // GET: /api/boletim/buscar/{id}
        [HttpGet]
        [Route("buscar-id/{id}")]
        public IActionResult BuscarPorId([FromRoute] int id)
        {
            Boletim boletim = _context.Boletins.
                FirstOrDefault(a => a.Id.Equals(id));
            return boletim != null ? Ok(boletim) : NotFound();
        }

        // DELETE: /api/boletim/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Boletim boletim = _context.Boletins.Find(id);
            if (boletim != null)
            {
                _context.Boletins.Remove(boletim);
                _context.SaveChanges();
                return Ok(boletim);
            }
            return NotFound();
        }

        // PATCH: /api/boletim/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Boletim boletim)
        {
            try
            {
                _context.Boletins.Update(boletim);
                _context.SaveChanges();
                return Ok(boletim);
            }
            catch
            {
                return NotFound();
            }
        }
    }
    
}