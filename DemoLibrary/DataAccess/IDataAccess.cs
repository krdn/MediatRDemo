using DemoLibrary.Interface;
using DemoLibrary.Models;

namespace DemoLibrary.DataAccess;
public interface IDataAccess: ISingletonService
{
    List<PersonModel> GetPeople();
    PersonModel InsertPerson(string firstName, string lastName);
}