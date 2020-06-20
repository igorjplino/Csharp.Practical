using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using static ByteBank.Portal.Infraestrutura.Utilidades;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        public string[] Prefixos { get; }

        public WebApplication(string[] prefixos)
        {
            Prefixos = prefixos ?? throw new ArgumentNullException(nameof(prefixos));
        }

        public void Iniciar()
        {
            while (true)
                ManipularRequisicao();
        }

        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in Prefixos)
            {
                httpListener.Prefixes.Add(prefixo);
            }

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var path = requisicao.Url.AbsolutePath;
            var nomeResource = ConverterPathParaNomeAssembly(path);

            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream(nomeResource);
            var byteResource = new byte[resourceStream.Length];

            resourceStream.Read(byteResource, 0, (int)resourceStream.Length);

            resposta.ContentType = ObterTipoDeConteudo(path);
            resposta.StatusCode = 200;
            resposta.ContentLength64 = resourceStream.Length;

            resposta.OutputStream.Write(byteResource, 0, byteResource.Length);

            resposta.OutputStream.Close();

            httpListener.Stop();
        }
    }
}
