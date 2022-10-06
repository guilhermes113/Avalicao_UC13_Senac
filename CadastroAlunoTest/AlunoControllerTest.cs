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
        Aluno alunoValido2;

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
            alunoValido2 = new Aluno()
            {
                Id = -2,
                Nome =  "",
                Media = 11,
                Turma = ""
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

            var consulta = controller.Create(2);
            Assert.IsType<NotFoundResult>(consulta);
        }
        [Fact(DisplayName = "Aluno Inexistente BadRequest")]
        public void AlunoInexistente_RetornBadRequest()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            var consulta = controller.Create(-1);
            //assert
            Assert.IsType<BadRequestResult>(consulta);
        }
        [Fact(DisplayName = "Details Chama Repo 1 Vez")]
        public void DetailsAluno_ModelStateValida_ChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Details(1));
            controller.Create(1);
            // Assert
            _repository.Verify(repo => repo.Details(1), Times.Once);
        }
        [Fact(DisplayName = "Details Return ViewResult")]
        public void ExecutaAcao_RetornaViewResul()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);
            var result = controller.Create(1);
            Assert.IsType<ViewResult>(result);
        }
        [Fact(DisplayName = "Create Return ViewResult")]
        public void ExecutaAcao_RetornaViewResultSempre()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            var result = controller.Create(alunoValido);
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact(DisplayName = "[HttpPost] Create() ou RedirectToAction ")]
        public void ValidaDados_RetornaResposta()
        {   ////Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            //Action
            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            var result = controller.Create(alunoValido);
            // Assert
            _repository.Verify(repo => repo.Create(alunoValido), Times.Once);
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact(DisplayName = " RedirectToAction ")]
        public void ValidaDados_RetornaResposta_NEgativo()
        {   ////Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            //Action
            _repository.Setup(repo => repo.Create(alunoValido2)).Returns(alunoValido2);
            var result = controller.Create(alunoValido2);
            // Assert
            _repository.Verify(repo => repo.Create(alunoValido2), Times.Once);
            Assert.IsType<ViewResult>(result);
        }


    }

}
