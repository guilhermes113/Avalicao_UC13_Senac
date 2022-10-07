using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroAluno.Data;
using CadastroAluno.Models;
using CadastroAluno.Contracts;

namespace CadastroAluno.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepository _context;

        public AlunosController(IAlunoRepository context)
        {
            _context = context;
        }

        // GET: Alunos
        public  IActionResult Index()
        {
            return View( _context.Index());
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            var aluno = _context.Details(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }
        // GET: Alunos/Details/5
        public  IActionResult Create(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno =  _context.Details(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                 
                _context.Create(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _context.Details(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Edit(id, aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public  IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _context.Details(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var aluno =  _context.Details(id);
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private IActionResult AlunoExists(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
