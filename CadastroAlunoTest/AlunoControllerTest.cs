using CadastroAluno.Contracts;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using CadastroAluno.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunoTest
{
    public class AlunoControllerTest
    {
        Mock<IAlunoRepository> _repository;
        Aluno alunoValido;

        public AlunoControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public  void GetClientes_ExecutaAcao_RetornaOkAction()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            var result =  controller.Index();
            Assert.IsType<ViewResult>(result) ;
        }
        [Fact]
        public  void CreateAluno_ModelStateValida_ChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            
            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            controller.Create(alunoValido);
            _repository.Verify(repo => repo.Create(alunoValido), Times.Once);
        }
        //[Fact]
        //public async void GetCliente_ExecutaAcao_RetornaCliente()
        //{
        //    ClientesController controller = new ClientesController(_repository.Object);
        //    var cliente = new Cliente("x", DateTime.Now, "mail");
        //    _repository.Setup(repo => repo.GetClienteById(1)).Returns(Task.FromResult(cliente));
        //    var consulta = await controller.GetCliente(1);
        //    Assert.IsType<List<Cliente>>((consulta.Result as OkObjectResult).Value);
        //    //Assert.Equal(2, lista.Count);


        //}
    }
}
