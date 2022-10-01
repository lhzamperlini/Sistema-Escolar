using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc; 


namespace API.Controllers
{
    [ApiController]
    [Route("api/disciplina")]
    public class DisciplinaController : ControllerBase
    {
        private readonly DataContext _context;
        public DisciplinaController(DataContext context) => _context = context; //injeção de dependência

        // GET: /api/disciplina/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar(){

            var disciplinas = _context.Disciplinas.ToList();

            for(int i = 0; i < disciplinas.Count; i++){
                
                //busca o professor da disciplina atual e adiciona ao objeto disciplina atual 
                disciplinas[i].professor = _context.Professores.FirstOrDefault(a => a.Cpf == disciplinas[i].CpfProfessor);
            }

            return Ok(disciplinas);

        }

        // POST: /api/disciplina/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Disciplina disciplina)
        {

            Professor professor = _context.Professores.
            FirstOrDefault(a => a.Cpf.Equals(disciplina.CpfProfessor));

           if (professor != null)
            {
                disciplina.professor = professor;
                _context.Disciplinas.Add(disciplina);
                _context.SaveChanges();
               return Created("", disciplina);
            }
            return NotFound();
        }

        // GET: /api/disciplina/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            Disciplina disciplina = _context.Disciplinas.FirstOrDefault(a => a.Id == id); //busca a disciplina pelo id

            if (disciplina == null){
                
                return NotFound();
            }
            else
            {
                return Ok(disciplina);
            }
        }

        // DELETE: /api/disciplina/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Disciplina disciplina = _context.Disciplinas.Find(id);//busca a disciplina pelo id

            if (disciplina != null)
            {
                _context.Disciplinas.Remove(disciplina); //remove a disciplina
                _context.SaveChanges();//salva as alterações
                return Ok(disciplina);
            }
            return NotFound();
        }

        // PATCH: /api/disciplina/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina); //altera o objeto no banco de dados
            _context.SaveChanges(); //salva as alterações no banco de dados
            return Ok(disciplina);
        }
    }
}