using Newtonsoft.Json;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json.Serialization;

namespace ProveIt_CopyingObjectsChallenge;

class Program
{
    static void Main(string[] args)
    {
        PersonModel firstPerson = new PersonModel
        {
            FirstName = "Sue",
            LastName = "Storm",
            DateOfBirth = new DateTime(1998, 7, 19),
            Addresses = new List<AddressModel>
            {
                new AddressModel
                {
                    StreetAddress = "101 State Street",
                    City = "Salt Lake City",
                    State = "UT",
                    ZipCode = "76321"
                },
                new AddressModel
                {
                    StreetAddress = "842 Lawrence Way",
                    City = "Jupiter",
                    State = "FL",
                    ZipCode = "22558"
                }
            }
        };

        // Creates a second PersonModel object
        PersonModel secondPerson = null;

        ////METHOD 1: DEEP COPY
        ////serializing/deserializing only affects public variable (not private)
        //string tempPerson = JsonConvert.SerializeObject(firstPerson);
        //secondPerson = JsonConvert.DeserializeObject<PersonModel>(tempPerson);

        //METHOD 2: USING CONSTRUCTORS
        //gives you a lot more control than first method
        secondPerson = new PersonModel(firstPerson);

        // Set the value of the secondPerson to be a copy of the firstPerson
        // Update the secondPerson's FirstName to "Bob" 
        // and change the Street Address for each of Bob's addresses
        // to a different value
        secondPerson.FirstName = "Bob";
        secondPerson.Addresses[0].StreetAddress = "123 bobbness monster way";
        secondPerson.Addresses[1].StreetAddress = "789 quackness drive";

        // Ensure that the following statements are true
        Console.WriteLine($"{firstPerson.FirstName} != {secondPerson.FirstName}");
        Console.WriteLine($"{firstPerson.LastName} == {secondPerson.LastName}");
        Console.WriteLine($"{firstPerson.DateOfBirth.ToShortDateString()} == {secondPerson.DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"{firstPerson.Addresses[0].StreetAddress} != {secondPerson.Addresses[0].StreetAddress}");
        Console.WriteLine($"{firstPerson.Addresses[0].City} == {secondPerson.Addresses[0].City}");
        Console.WriteLine($"{firstPerson.Addresses[1].StreetAddress} != {secondPerson.Addresses[1].StreetAddress}");
        Console.WriteLine($"{firstPerson.Addresses[1].City} == {secondPerson.Addresses[1].City}");
    }
}

public class PersonModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();

    public PersonModel() { }
    public PersonModel(PersonModel other)
    {
        FirstName = other.FirstName;
        LastName = other.LastName;
        DateOfBirth = other.DateOfBirth;
        Addresses = other.Addresses;
    }
}

public class AddressModel
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public AddressModel() { }
    public AddressModel(AddressModel other)
    {
        StreetAddress = other.StreetAddress;
        City = other.City;
        State = other.State;
        ZipCode = other.ZipCode;
    }
}
