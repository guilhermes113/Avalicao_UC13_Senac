using System.ComponentModel.DataAnnotations;

namespace CadastroAluno.Models
{
    public class Aluno
    {
        

        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 6)]
        public string Turma { get; set; }
        [Required]
        [StringLength(2)]
        public double Media { get; set; }

        public void AtualizarDados(string nome, string turma)
        {
            Nome = nome;
            Turma = turma;
        }

        public bool VerificaAprovacao() 
            => Media > 5;

        public void AtualizaMedia(double novaMedia)
        {
            Media = novaMedia;
        }
    }
}
