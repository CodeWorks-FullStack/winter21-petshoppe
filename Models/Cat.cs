using System.ComponentModel.DataAnnotations;
// NOTE using == import

namespace petshop.Models
{
  public class Cat
  {
    public Cat(int age, string name)
    {
      Id = Guid.NewGuid().ToString();
      Age = age;
      Name = name;
      // NOTE this.name = data.name in JS
    }
    public string? Id { get; set; }
    [Range(0, int.MaxValue)]
    public int Age { get; set; }
    // NOTE the property directly beneath the required field will be required

    // NOTE this is called the decorator pattern
    [Required]
    public string Name { get; set; }
  }
}