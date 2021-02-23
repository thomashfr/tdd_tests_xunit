using LeilaoOnline.Core;
using Xunit;
namespace LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {



        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorDestino, double valorEsperado, double[] ofertas)
        {
            //Arranje - Cenário
            IModalidadeAvaliacao modalidade = new OfertaSuperiorMaisProxima(valorDestino);
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

            // act - Método sob Teste
            leilao.TerminarPregao();

            //Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Theory]
        [InlineData(new double[] { 800, 900, 1000, 990 }, 1000)]
        [InlineData(new double[] { 800 }, 800)]
        [InlineData(new double[] { 800, 900, 1000, 1200 }, 1200)]
        public void RetornaMaiorValorDadoLeilaoComPelomenosUmLance(double[] ofertas, double valorEsperado)
        {
            //Arranje - Cenário
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

            // act - Método sob Teste
            leilao.TerminarPregao();

            var valorObitido = leilao.Ganhador.Valor;

            //Assert
            Assert.Equal(valorEsperado, valorObitido);
        }

        [Fact]
        public void LancaInvalidOperationExeptionDadoPregaoNaoIniciado()
        {
            //Given
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            //Assert
            var mensagemObitida = Assert.Throws<System.InvalidOperationException>(() =>
            //When
            leilao.TerminarPregao()
            );
            var mensagemEsperada = "Não é possivel iniciar um pregão não iniciado";

            Assert.Equal(mensagemEsperada, mensagemObitida.Message);


        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje - Cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            leilao.IniciarPregao();
            // act - Método sob Teste
            leilao.TerminarPregao();

            var valorEsperado = 0;
            var valorObitido = leilao.Ganhador.Valor;
            //Assert
            Assert.Equal(valorEsperado, valorObitido);
        }
    }
}