using System;
using System.Linq;
using Entidades;
using Interfaces;

public class CatalogoCursosService
{
    private readonly ICursoOnlineRepository _repositorio;

    public CatalogoCursosService(ICursoOnlineRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public void RegistrarCurso(CursoOnline curso)
    {
        var cursos = _repositorio.ObterTodos();
        bool duplicado = cursos.Any(c =>
            c.Titulo?.Trim().ToLower() == curso.Titulo?.Trim().ToLower() &&
            c.Instrutor?.Trim().ToLower() == curso.Instrutor?.Trim().ToLower());

        if (duplicado)
        {
            Console.WriteLine("Curso duplicado. Registro ignorado.");
            return;
        }

        _repositorio.Adicionar(curso);
        Console.WriteLine("Curso registrado com sucesso.");
    }

    public void ListarCursos()
    {
        var cursos = _repositorio.ObterTodos();
        foreach (var c in cursos)
        {
            Console.WriteLine($"{c.Titulo} - {c.Instrutor} ({c.CargaHorariaHoras}h)");
        }
    }
}
