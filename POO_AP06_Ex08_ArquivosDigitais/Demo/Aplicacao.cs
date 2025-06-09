using Entidades;
using Interfaces;
using Repositorios;
using System;

namespace Demo
{
    public class Aplicacao
    {
        public void Executar()
        {
            IArquivoDigitalRepository repositorio = new ArquivoDigitalJsonRepository();

            repositorio.Adicionar(new ArquivoDigital
            {
                Id = Guid.NewGuid(),
                NomeArquivo = "foto.png",
                TipoArquivo = "imagem",
                TamanhoBytes = 512000,
                DataUpload = DateTime.Now
            });

            var imagens = repositorio.BuscarPorTipo("imagem");

            Console.WriteLine("Arquivos do tipo imagem:");
            foreach (var arq in imagens)
            {
                Console.WriteLine($"{arq.NomeArquivo} ({arq.TamanhoBytes} bytes) - Enviado em {arq.DataUpload}");
            }
        }
    }
}
