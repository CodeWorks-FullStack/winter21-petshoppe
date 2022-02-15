using petshop.Models;

namespace petshop.DB
{
  public class FakeDB
  {
    public static List<Cat> Cats { get; set; } = new List<Cat>()
    {
      new Cat(6, "Koda"),
      new Cat(13, "Jax"),
      new Cat(8, "Moo")
    };
  }
}