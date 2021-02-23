

using System;

namespace LeilaoOnline.Core
{
    public class Lance
    {

        public Interessada Cliente { get; }
        public double Valor { get; }
        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0)
            {
                throw new System.ArgumentException("Valor do Lance não pode ser Negativo!");
            }
            Valor = valor;
            Cliente = cliente;
        }
    }
}