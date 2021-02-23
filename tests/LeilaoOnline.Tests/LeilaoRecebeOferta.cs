using LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(4, new double[] { 1800, 2000, 1200, 1400 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int quantidadeEsperada, double[] ofertas)
        {
            //Given
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciarPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }
                else
                {
                    leilao.RecebeLance(maria, ofertas[i]);
                }

            }
            leilao.TerminarPregao();

            //When
            leilao.RecebeLance(fulano, 1000);

            //Then
            Assert.Equal(quantidadeEsperada, leilao.Lances.Count());
        }
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Given
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciarPregao();
            leilao.RecebeLance(fulano, 800);

            //When
            leilao.RecebeLance(fulano, 1000);

            //Then
            var quantidadeEsperada = 1;
            Assert.Equal(quantidadeEsperada, leilao.Lances.Count());
        }
    }

}