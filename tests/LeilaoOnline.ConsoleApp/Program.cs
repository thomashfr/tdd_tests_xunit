using System;
using LeilaoOnline.Core;

namespace LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
           var leilao = new Leilao("Van Gogh");
           var fulano = new Interessada("Fulano",leilao);
           var maria = new Interessada("Maria",leilao);

           leilao.RecebeLance(fulano, 800);
           leilao.RecebeLance(maria,800);
           leilao.RecebeLance(fulano, 1000);

           leilao.TerminarPregao();

           Console.WriteLine(leilao.Ganhador.Valor);

        }
    }
}
