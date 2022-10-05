using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Contracts
{
    public interface IAlunoRepository
    {
        List<Aluno>Index();
        Aluno Details(int? id);
        Aluno Create(Aluno cliente);
        Aluno Edit(int? id,Aluno cliente);
        int Delete(int id);
    }
}
