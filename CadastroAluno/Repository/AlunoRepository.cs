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
        public async Task<List<Aluno>> Index()
        {
            return await _context.Aluno.ToListAsync();
        }
        public async Task<Aluno> Details(int id)
        {
            return await _context.Aluno.FindAsync(id);
        }
        public async Task<Aluno> Create(Aluno aluno)
        {
            await _context.Aluno.AddAsync(aluno);
            await _context.SaveChangesAsync();
            return aluno;

        }
        public async Task<Aluno> Edit(int id,Aluno alunoAlterado)
        {
            _context.Entry(alunoAlterado).State = EntityState.Modified;
            //_context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return alunoAlterado;
        }
        public async Task Delete(int id)
        {
            var alunoRemovido = await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);
            //_context.Entry(id).State = EntityState.Deleted;
            _context.Aluno.Remove(alunoRemovido);
            await _context.SaveChangesAsync();
        }
    }
}
