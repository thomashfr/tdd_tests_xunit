using LeilaoOnline.Core;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExeptionDadoValorNegativo()
        {
            //Given
            var valorNegativo = -100;
            //When
            Assert.Throws<System.ArgumentException>(
                //Them
                () => new Lance(null, valorNegativo));
        }
    }
}