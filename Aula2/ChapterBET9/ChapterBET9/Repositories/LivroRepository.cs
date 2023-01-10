﻿using ChapterBET9.Contexts;
using ChapterBET9.Models;

namespace ChapterBET9.Repositories
{
    public class LivroRepository
    {
        private readonly SqlContext _context;
        public LivroRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public void Atualizar(int id, Livro livro)
        {
            Livro livroBuscado = _context.Livros.Find(id);
            
            if (livroBuscado != null)
            {
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
                livroBuscado.Disponivel = livro.Disponivel;
            }

            _context.Livros.Update(livroBuscado);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro livroBuscado = _context.Livros.Find(id);
            _context.Livros.Remove(livroBuscado);
            _context.SaveChanges();
        }
    }
}
