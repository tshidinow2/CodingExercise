using CodingExercise.Address.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Address.Service
{
    public class AddressService
    {
        public string PrettyPrintAddress(Model.Address address)
        {
            var type = (address.type is null) ? "No Type" : address?.type.Name;
            var addresslineline = (address.addressLineDetail is null) ? "No addressLineDetail" :  $"{address?.addressLineDetail.Line1} { address?.addressLineDetail.Line2}";
            var cityortown = (string.IsNullOrEmpty(address.cityOrTown))? "No City" :address.cityOrTown;
            var provinceorstate = (address.provinceOrState is null) ? "No provinceOrState" : address.provinceOrState.Name;
            var postcode = (string.IsNullOrEmpty(address.postalCode))?"No Postal Code" : address.postalCode;
            var country = (address.country is null) ? "No country" : address.country.Name;
            return $"{type} : {addresslineline} - {cityortown} - {provinceorstate} - {postcode} - {country}"; 
        }
        public void PrettyPrintAll(List<Model.Address> addresses)
        {
            foreach (var address in addresses)
            {
                Console.WriteLine(PrettyPrintAddress(address));
            }
        }
        public void PrettyPrintType(List<Model.Address> addresses, string type)
        {
            var typeaddresses = addresses.Where(x => x.type.Name==type);

            foreach (var address in typeaddresses)
            {
                Console.WriteLine(PrettyPrintAddress(address));
            }
        }
        public void ValidateImportedAddress(List<Model.Address> addresses)
        {
            foreach (var address in addresses)
            {
                var addressvalidation = ValidateAddress(address);
                Console.WriteLine($"validation results Address No {address.Id} : {addressvalidation.isvalid} | {addressvalidation.reason} ");
            }
        }
        public (bool isvalid,string reason) ValidateAddress(Model.Address address)
        {
            var failurereason = new StringBuilder();
            var isvalid = true;

            var ispostalcodevalid = CheckPostalCode(address);
            if(!ispostalcodevalid.isvalid)
                failurereason.AppendLine(ispostalcodevalid.reason);
    
            var iscountryvalid = CheckCountry(address);
            if(!iscountryvalid.isvalid)
                failurereason.AppendLine(iscountryvalid.reason);

            var isaddresslinevalid = CheckAddressLine(address);
            if (!isaddresslinevalid.isvalid)
                failurereason.AppendLine(isaddresslinevalid.reason);

            var isprovinceorstatevalid = CheckProvinceOrState(address);
            if (!isprovinceorstatevalid.isvalid)
                failurereason.AppendLine(isprovinceorstatevalid.reason);

            //check is any property of address returned failure reason
            if (failurereason.Length > 0)
                isvalid = false;

            var failurereasonarray = failurereason.ToString().TrimEnd(Environment.NewLine.ToCharArray()).Split("\r\n");

            return (isvalid, string.Join("|", failurereasonarray));

        }
        public (bool isvalid,string reason) CheckPostalCode(Model.Address address)
        {
            if (int.TryParse(address.postalCode, out var code) == false)
                return (false,"Postal Code Must be Numbers");            
            return (true,"");
        }
        public (bool isvalid,string reason) CheckCountry(Model.Address address)
        {
            if(address.country is null)
                return (false,"Country Is Empty");           
            return (true,"");
        }
        public (bool isvalid, string reason) CheckAddressLine(Model.Address address)
        {
            if (address.addressLineDetail is null)
                return (false,"Address Detail Is Empty");

            if (string.IsNullOrEmpty(address.addressLineDetail.Line1) == true && string.IsNullOrEmpty(address.addressLineDetail.Line2) == true)
                return (false, "All Address Detail Lines are Empty");
            return (true,"");
        }
        public (bool isvalid, string reason)  CheckProvinceOrState(Model.Address address)
        {
            if (CheckCountry(address).isvalid == true)
            {
                if (address.country.Code.Equals("ZA"))
                    if (address.provinceOrState is null)
                        return (false,"ProvinceOrState is Empty For ZA");
            }
            return (true,"");
        }
    }
}
