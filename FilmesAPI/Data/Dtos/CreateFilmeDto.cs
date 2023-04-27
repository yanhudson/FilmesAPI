﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatória")]
    [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 " +
        "caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração do filme é obrigatória")]
    [Range(70, 300, ErrorMessage = "A duraçao do filme deve ser entre 70 e 600 " +
        "minutos")]
    public int Duracao { get; set; }


}
