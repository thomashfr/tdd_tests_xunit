namespace LeilaoOnline.Core
{
  public class Interessada
  {
    public Leilao Leilao { get; set; }
    public string Nome { get; set; }
    public Interessada(string nome, Leilao leilao)
    {
      Nome = nome;
      Leilao = leilao;
      }
  }
}