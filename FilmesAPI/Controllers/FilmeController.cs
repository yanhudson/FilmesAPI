using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult listaFilmes([FromQuery]int skip = 0,
        [FromQuery]int take = 50)
    {
        return _context.Filmes.Count() > 0 ? 
            Ok(_context.Filmes.Skip(skip).Take(take)) :
            NoContent();
    }

    [HttpPost]
    public IActionResult CadastrarFilme([FromBody] CreateFilmeDto filmeDto)
    {


        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(ListaFilmePorId),
            new { id = filme.GetId() },
            filme);
    }

    [HttpGet("{id}")]
    public IActionResult ListaFilmePorId(int id)
    {
        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.GetId() == id);

        return filme != null ? Ok(filme) : NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.GetId() == id);

        if (filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.GetId() == id);

        return filme != null ? Ok(_context.Filmes.Remove(filme)) : NotFound();
    }

}
