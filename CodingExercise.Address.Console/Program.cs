using CodingExercise.Address.Infrastructure;
using CodingExercise.Address.Service;
using System.Threading.Tasks;

namespace CodingExercise.Address.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var addressService = new AddressService();
            var loadedaddress = AddressJsonReader.ReadJsonAddress(@"addresses.json");
            while (true)
            {
                System.Console.WriteLine("please enter the number of the option you want to perform - type exit when done");
                System.Console.WriteLine("1 - pretty print all the addresses from the file");
                System.Console.WriteLine("2 - pretty print certain address type (postal, physical, business) from the file");
                System.Console.WriteLine("3 - validate all addresses from the file");

                var input = System.Console.ReadLine();

                if (int.TryParse(input, out var option) == false)
                {
                    break;
                }

                if (option == 1)
                    addressService.PrettyPrintAll(loadedaddress);
                else if (option == 2)
                {
                    System.Console.WriteLine("Enter Address Type");
                    var addresstype = System.Console.ReadLine();
                    addressService.PrettyPrintType(loadedaddress, addresstype);
                }
                else if (option == 3)
                {
                    addressService.ValidateImportedAddress(loadedaddress);
                }
                else
                {
                    System.Console.WriteLine("Wrong Option");
                }

            }
        }
    }
}
