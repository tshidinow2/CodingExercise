using System;
using System.Collections.Generic;
using Xunit;

namespace CodingExercise.Address.UnitTest
{
    public class AddressTest
    {
        private readonly Service.AddressService addressService;
        public AddressTest()
        {
            this.addressService = new Service.AddressService();
        }

        [Fact]
        public void pretty_when_valid_address()
        {
            //provided
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = "Jozi",
                country = new Model.Country { Code = "ZA", Name = "South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = new Model.AddressLineDetail { Line1 = "Line 1", Line2 = "Line 2" },
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };
            //when
            var results = this.addressService.PrettyPrintAddress(address);
            //then
            Assert.Equal("Physical Address : Line 1 Line 2 - Jozi - Eastern Cape - 1234 - South Africa", results);
        }

        [Fact]
        public void when_valid_postalcode_number_is_provided()
        {
            //provided
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country { Code = "ZA", Name = "South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = new Model.AddressLineDetail { Line1 = "Line 1", Line2 = " Line 2" },
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };
            //when
            var results = this.addressService.CheckPostalCode(address);
            //then
            Assert.Equal((true, ""), (results));
        }

        [Fact]
        public void when_invalid_postalcode_notnumber_is_provided()
        {
            //provided
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country { Code = "ZA", Name = "South Africa" },
                postalCode = "not a number",
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = new Model.AddressLineDetail { Line1 = "Line 1", Line2 = " Line 2" },
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };
            //when
            var results = this.addressService.CheckPostalCode(address);
            //then
            Assert.Equal((false, "Postal Code Must be Numbers"), (results));
        }

        [Fact]
        public void when_invalid_postalcode_null_is_provided()
        {
            //provided
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country { Code = "ZA", Name = "South Africa" },
                postalCode = null,
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = new Model.AddressLineDetail { Line1 = "Line 1", Line2 = " Line 2" },
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };
            //when
            var results = this.addressService.CheckPostalCode(address);
            //then
            Assert.Equal((false, "Postal Code Must be Numbers"), (results));
        }

        [Fact]     
        public void when_valid_country_is_provided()
        {
            //provided
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country { Code = "ZA", Name = "South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = new Model.AddressLineDetail { Line1 = "Line 1", Line2 = " Line 2" },
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };

            //when
            var results = this.addressService.CheckCountry(address);
            //then
            Assert.Equal((true, ""), (results));
        }

        [Fact]
        public void when_invalid_country_is_provided()
        {
            //provided
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = null,
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = new Model.AddressLineDetail { Line1 = "Line 1", Line2 = " Line 2" },
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };

            //when
            var results = this.addressService.CheckCountry(address);
            //then
            Assert.Equal((false, "Country Is Empty"), (results));
        }

        [Fact]
        public void when_valid_addressline_with_Line1_Line2_provided()
        {
            //Given
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country { Code = "ZA", Name = "South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = new Model.AddressLineDetail { Line1 = "Line 1", Line2 = "Line 2" },
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };
            //When
            var addressvalidateresults = this.addressService.CheckAddressLine(address);
            //Then
            Assert.Equal((true, ""), (addressvalidateresults));
        }
        [Fact]
        public void when_invalidvalid_addressline_with_nulladdressline_provided()
        {
            //Given
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country { Code = "ZA", Name = "South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = null,
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };
            //When
            var addressvalidateresults = this.addressService.CheckAddressLine(address);
            //Then
            Assert.Equal((false, "Address Detail Is Empty"), (addressvalidateresults));
        }
        [Fact]
        public void when_invalidvalid_addressline_with_emptyaddressline_provided()
        {
            //Given
            var address = new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country { Code = "ZA", Name = "South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState = new Model.ProvinceOrState { Code = 5, Name = "Eastern Cape" },
                addressLineDetail = new Model.AddressLineDetail { Line1="",Line2=""},
                type = new Model.Type { Code = 1, Name = "Physical Address" },
            };
            //When
            var addressvalidateresults = this.addressService.CheckAddressLine(address);
            //Then
            Assert.Equal((false, "All Address Detail Lines are Empty"), (addressvalidateresults));
        }
        [Fact]
        public void when_provinceorstate_notempty_and_country_ZA_provided()
        {
        //Given
        var addressZA =   new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country {Code="ZA", Name="South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState= new Model.ProvinceOrState{ Code =5,Name="Eastern Cape"},
                addressLineDetail = new Model.AddressLineDetail{ Line1="Line 1",Line2=" Line 2"},
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            };
        
        //When
        var provinceorstatevalidateresults = this.addressService.CheckProvinceOrState(addressZA);
        
        //Then
        Assert.Equal((true, ""), (provinceorstatevalidateresults)); 
        }

        [Fact]
        public void when_provinceorstate_empty_and_country_ZA_provided()
        {
        //Given
        var addressZA =   new Model.Address
            {
                Id = 1,
                cityOrTown = null,
                country = new Model.Country {Code="ZA", Name="South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState= null,
                addressLineDetail = new Model.AddressLineDetail{ Line1="Line 1",Line2=" Line 2"},
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            };
        
        //When
        var provinceorstatevalidateresults = this.addressService.CheckProvinceOrState(addressZA);
        
        //Then
        Assert.Equal((false, "ProvinceOrState is Empty For ZA"), (provinceorstatevalidateresults)); 
        }

        [Fact]
        public void when_provinceorstate_notempty_and_country_nonZA_provided()
        {
        //Given
        var addressZA =   new Model.Address
            {
                Id = 1,
                cityOrTown = null,
               country = new Model.Country {Code="LB", Name="Lebanon" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState= null,
                addressLineDetail = new Model.AddressLineDetail{ Line1="Line 1",Line2=" Line 2"},
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            };
        
        //When
        var provinceorstatevalidateresults = this.addressService.CheckProvinceOrState(addressZA);
        
        //Then
        Assert.Equal((true, ""), (provinceorstatevalidateresults)); 
        }

        [Fact]
        public void when_provinceorstate_empty_and_country_nonZA_provided()
        {
        //Given
        var addressZA =   new Model.Address
            {
                Id = 1,
                cityOrTown = null,
               country = new Model.Country {Code="LB", Name="Lebanon" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState= null,
                addressLineDetail = new Model.AddressLineDetail{ Line1="Line 1",Line2=" Line 2"},
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            };
        
        //When
        var provinceorstatevalidateresults = this.addressService.CheckProvinceOrState(addressZA);
        
        //Then
        Assert.Equal((true, ""), (provinceorstatevalidateresults)); 
        }

        public static IEnumerable<object[]> InValidAddresses()
        {
            yield return new object[] { new Model.Address
            {
                Id = 1,
                addressLineDetail = null,
                cityOrTown = null,
                country = null,
                postalCode = null,
                lastUpdated = DateTime.Now,
                provinceOrState= null,
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            } , false ,"Postal Code Must be Numbers|Country Is Empty|Address Detail Is Empty"};
            yield return new object[] { new Model.Address
            {
                Id = 2,
                cityOrTown = null,
                country = new Model.Country {Code="ZA", Name="South Africa" },
                postalCode = null,
                lastUpdated = DateTime.Now,
                provinceOrState= null,
                addressLineDetail = null,
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            } , false ,"Postal Code Must be Numbers|Address Detail Is Empty|ProvinceOrState is Empty For ZA"};
            yield return new object[] { new Model.Address
            {
                Id = 3,
                cityOrTown = null,
                country = new Model.Country {Code="ZA", Name="South Africa" },
                postalCode = "wrong postal",
                lastUpdated = DateTime.Now,
                provinceOrState= new Model.ProvinceOrState{ Code =5,Name="Eastern Cape"},
                addressLineDetail = new Model.AddressLineDetail{ Line1="Line 1",Line2=" Line 2"},
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            } , false ,"Postal Code Must be Numbers"};
            yield return new object[] { new Model.Address
            {
                Id = 4,
                cityOrTown = null,
                country = null,
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState= new Model.ProvinceOrState{ Code =5,Name="Eastern Cape"},
                addressLineDetail = new Model.AddressLineDetail{ Line1="Line 1",Line2="Line 2"},
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            } , false ,"Country Is Empty"};
            yield return new object[] { new Model.Address
            {
                Id = 5,
                cityOrTown = null,
                country = new Model.Country {Code="ZA", Name="South Africa" },
                postalCode = "1234",
                lastUpdated = DateTime.Now,
                provinceOrState= new Model.ProvinceOrState{ Code =5,Name="Eastern Cape"},
                addressLineDetail = new Model.AddressLineDetail{ Line1="",Line2=""},
                type = new Model.Type { Code = 1, Name = "Physical Address" } ,
            } , false ,"All Address Detail Lines are Empty"};
        }

        [Theory, MemberData(nameof(InValidAddresses))]
        public void check_failurereason_when_invalid_address(Model.Address address, bool isvalid, string reason)
        {
            var addressvalidateresults = this.addressService.ValidateAddress(address);
            Assert.Equal((isvalid, reason), (addressvalidateresults));
        }

    }
}
