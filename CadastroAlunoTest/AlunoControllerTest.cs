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
            alunoValido = new Aluno()
            {
                Id = 1,
                Nome =  "Nome",
                Media = 8,
                Turma = "Turma 1"
            };
        }

        [Fact]
        public void ChamaAlunos_ExecutaAcao_RetornaOkAction()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Fact(DisplayName = "Index  Chama Repo 1 Vez")]
        public void ModelStateValida_ChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            controller.Index();
            //assert

            _repository.Verify(repo => repo.Index(), Times.Once);
        }
        [Fact(DisplayName = "ALuno Inexistente NotFound")]
        public void AlunoInexistente_RetornaNotFound()
        {

            AlunosController controller = new AlunosController(_repository.Object);
            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);

            var consulta = controller.Details(2);
            Assert.IsType<NotFoundResult>(consulta);
        }
        [Fact(DisplayName = "Aluno Inexistente BadRequest")]
        public void AlunoInexistente_RetornBadRequest()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            var consulta = controller.Details(-1);
            //assert
            Assert.IsType<BadRequestResult>(consulta);
        }
        [Fact(DisplayName = "Details Chama Repo 1 Vez")]
        public void DetailsAluno_ModelStateValida_ChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Details(1));
            controller.Details(1);
            // Assert
            _repository.Verify(repo => repo.Details(1), Times.Once);
        }
        [Fact(DisplayName = "Details Return ViewResult")]
        public void ExecutaAcao_RetornaViewResul()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);
            var result = controller.Details(1);
            Assert.IsType<ViewResult>(result);
        }
        [Fact(DisplayName = "Create Return ViewResult")]
        public void ExecutaAcao_RetornaViewResulSempre()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            var result = controller.Create(alunoValido);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
