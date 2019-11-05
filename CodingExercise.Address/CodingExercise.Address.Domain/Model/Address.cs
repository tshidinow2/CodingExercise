using System;

namespace CodingExercise.Address.Model
{
    public class Address
    {
        public int Id { get; set; }
        public Type type { get; set; }
        public AddressLineDetail addressLineDetail { get; set; }
        public Country country { get; set; }
        public ProvinceOrState provinceOrState { get; set; }
        public string cityOrTown { get; set; }
        public string postalCode { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
