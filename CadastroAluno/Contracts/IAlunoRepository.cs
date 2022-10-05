using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Contracts
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> Index();
        Task<Aluno> Details(int id);
        Task<Aluno> Create(Aluno cliente);
        Task<Aluno> Edit(int id,Aluno cliente);
        Task Delete(int id);
    }
}
