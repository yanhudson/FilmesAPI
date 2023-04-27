using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesAPI.Models;

public class Filme
{
    [Key]
    [Required]
    private int Id { get; set; }
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    private string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatória")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 " +
        "caracteres")]
    private string Genero { get; set; }
    [Required(ErrorMessage = "A duração do filme é obrigatória")]
    [Range(70, 300, ErrorMessage = "A duraçao do filme deve ser entre 70 e 600 " +
        "minutos")]
    private int Duracao { get; set; }

    public int GetId() { return Id; }
    public string GetTitulo() { return Titulo; }
    public string GetGenero() { return Genero; }
    public int GetDuracao() { return Duracao; }
}
