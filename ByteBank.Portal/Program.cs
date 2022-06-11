using ByteBank.Portal.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var prefixos = new string[] { "http://localhost:5341/" };
            var webApllication = new WebApplication(prefixos);
            webApllication.Iniciar();
        }
    }
}
