using petshop.DB;
using petshop.Models;

namespace petshop.Services
{
  public class CatsService
  {
    internal List<Cat> GetAll()
    {
      return FakeDB.Cats;
    }

    internal Cat GetById(string? catId)
    {
      Cat? foundCat = FakeDB.Cats.Find(c => c.Id == catId);
      if (foundCat == null)
      {
        throw new Exception("Unable to find that cat");
      }
      return foundCat;
    }

    internal Cat Create(Cat newCat)
    {
      FakeDB.Cats.Add(newCat);
      return newCat;
    }

    internal Cat Delete(string catId)
    {
      Cat foundCat = GetById(catId);
      FakeDB.Cats.Remove(foundCat);
      return foundCat;
    }

    internal Cat Edit(Cat editedCat, string catId)
    {
      // NOTE sent in catId anyways for readability
      Cat originalCat = GetById(catId);
      // NOTE this is called null coalescence - do not want users to be able to add null data to the "database"
      originalCat.Name = editedCat.Name != null ? editedCat.Name : originalCat.Name;
      originalCat.Age = editedCat.Age != 0 ? editedCat.Age : originalCat.Age;
      return originalCat;
    }
  }
}