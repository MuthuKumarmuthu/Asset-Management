using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public class SignupLogic
    {
        public SignupData Signdb;
        public SignupLogic()
        {
            Signdb = new SignupData();
        }
        public List<RoleList> RoleDropdownList()
        {

            return Signdb.RoleDropdownList();
        }
        public List<AddressTypeList> AddressTypeDropdownList()
        {

            return Signdb.AddressTypeDropdownList();
        }
        public List<CountryList> CountryDropdownList()
        {

            return Signdb.CountryDropdownList();
        }
        public List<RegionsList> RegionDropdownList(int countryId)
        {

            return Signdb.RegionDropdownList(countryId);
        }
        public List<CityList> CityDropdownList(int regionId)
        {

            return Signdb.CityDropdownList( regionId);
        }


        public string ValidateUser(Signupdata Obj)
        {

            return Signdb.ValidateUser(Obj);
        }
        public int GetRoleId(string membershipTypeCode)
        {

            return Signdb.GetRoleId(membershipTypeCode);
        }

        public string RegisterUser(Signupdata Obj)
        {

            return Signdb.RegisterUser(Obj);
        }

        public Logindata AccessLogin(Logindata Obj)
        {

            return Signdb.AccessLogin(Obj);
        }
        public void LogOutDetails(int membershipId)
        {

             Signdb.LogOutDetails(membershipId);
        }
        public string AccessVendorSignUp(Vendordata Obj)
        {

            return Signdb.AccessVendorSignUp(Obj);
        }

    }
}
