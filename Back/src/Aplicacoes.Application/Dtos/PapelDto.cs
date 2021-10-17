using System.ComponentModel.DataAnnotations;

namespace Aplicacoes.Application.Dtos
{
    public class PapelDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!"),
         StringLength(6, MinimumLength = 4,
                         ErrorMessage = "Tamanho permitido de 4 a 6 caracteres.")]
        public string Nome { get; set; }
        [StringLength(120,
        ErrorMessage = "O tamanho máximo é de 120 caracteres.")]
        public string Descricao { get; set; }
    }
}