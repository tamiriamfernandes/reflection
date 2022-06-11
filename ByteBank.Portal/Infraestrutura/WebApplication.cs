using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public  class WebApplication
    {
        private readonly string[] _prefixos;
        public WebApplication(string[] prefixos)
        {
            if(prefixos == null)
                throw new ArgumentNullException(nameof(prefixos));

            _prefixos = prefixos;
        }
        public void Iniciar()
        {
            var httpListener = new HttpListener();
            httpListener.Start();


            foreach (var prefixo in _prefixos)
                httpListener.Prefixes.Add(prefixo);

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var respostaTexto = "Hello World";
            var respostaConteudoBytes = Encoding.UTF8.GetBytes(respostaTexto);

            resposta.ContentType = "text/html; charset=utf-8";
            resposta.StatusCode = 200;
            resposta.ContentLength64 = respostaConteudoBytes.Length;

            resposta.OutputStream.Write(respostaConteudoBytes, 0, respostaConteudoBytes.Length);
            resposta.OutputStream.Close();

            httpListener.Stop();

        }
    }
}
