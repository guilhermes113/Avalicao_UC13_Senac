using CadastroAluno.Contracts;
using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly CadastroAlunoContext _context;

        public AlunoRepository(CadastroAlunoContext context)
        {
            _context = context;
        }
        public  List<Aluno> Index()
        {
            return  _context.Aluno.ToList();
        }
        public  Aluno Details(int? id)
        {
            return  _context.Aluno.Find(id);
        }
        public  Aluno Create(Aluno aluno)
        {
             _context.Aluno.Add(aluno);
             _context.SaveChanges();
            return aluno;

        }
        public  Aluno Edit(int? id,Aluno alunoAlterado)
        {
            _context.Entry(alunoAlterado).State = EntityState.Modified;
            //_context.Clientes.Update(cliente);
             _context.SaveChanges();
            return alunoAlterado;
        }
        public int Delete(int id)
        {
            var alunoRemovido =  _context.Aluno.FirstOrDefault(a => a.Id == id);
            //_context.Entry(id).State = EntityState.Deleted;
            _context.Aluno.Remove(alunoRemovido);
            return  _context.SaveChanges();
        }
    }
}
