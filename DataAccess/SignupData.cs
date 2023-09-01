using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SignupData
    {
        public AssestInventoryContext context;
        public SignupData()
        {
            context = new AssestInventoryContext();
        }
        public List<RoleList> RoleDropdownList()
        {

            var result = (from role in context.Roles
                          select new RoleList
                          {
                              roleId = role.RoleId,
                              roleCode = role.RoleCode,
                              roleName = role.RoleName
                          }).ToList();

            return result;


        }
        public List<AddressTypeList> AddressTypeDropdownList()
        {

            var result = (from type in context.AddressTypes
                          select new AddressTypeList
                          {
                              typeId = type.AddTypeId,
                              typeCode = type.Code,
                              typeName = type.Description,
                          }).ToList();

            return result;


        }

        public List<CountryList> CountryDropdownList()
        {

            var result = (from country in context.Countries
                          select new CountryList
                          {
                              countryId = country.CountryId,
                              countryCode = country.Elscode,
                              countryName = country.Elscode
                          }).ToList();

            return result;


        }
        public List<RegionsList> RegionDropdownList(int countryId)
        {

            var result = (from region in context.Regions.Where(X => X.CountryId == countryId)
                          select new RegionsList
                          {
                              regionId = region.RegionId,
                              regionCode = region.Code,
                              regionName = region.RegionName,
                          }).ToList();


            return result;


        }
        public List<CityList> CityDropdownList(int regionId)
        {

            var result = (from city in context.Cities.Where(x => x.RegionId == regionId)
                          select new CityList
                          {
                              cityId = city.CityId,
                              cityCode = city.Code,
                              cityName = city.CityName,
                          }).ToList();


            return result;


        }
        public string ValidateUser(Signupdata Obj)
        {


            bool Mov = context.Memberships.Any(x => x.UserName == Obj.userName);
            if (Mov == true)
            {
                return "User Name Exists";
            }
            return "Register Successful";

        }
        public int GetRoleId(string membershipTypeCode)
        {


            var Mov = context.Roles.Where(x => x.RoleCode == membershipTypeCode).FirstOrDefault();
            if (Mov != null)
            {
                return Mov.RoleId;
            }
            return 0;
        }

        public string RegisterUser(Signupdata Sign)
        {


            Membership Mem = new Membership
            {
                MembershipTypeCode = Sign.membershipTypeCode,
                RegisteredDate = DateTime.Now,
                UserName = Sign.userName,
                //AliasName = Sign.aliasName,
                Password = Sign.password,
                //PasswordQuestion = Sign.passwordQuestion,
                //PasswordAnswer = Sign.passwordAnswer,
                Email = Sign.emailAddress,
                //LoweredEmail = Sign.loweredEmail,
                TandCaccepted = Sign.tandCaccepted,
                //ProfileImage =  Encoding.UTF8.GetBytes(Sign.profileImage), //Sign.profileImage,     //Convert.ToBase64String(byteArray);
                //ProfileImageContentType = Sign.profileImageContentType,
                IsLockedOut=Sign.isLockedOut,
                Active = true,
                Status = true,
                CreatedBy = Sign.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Sign.createdBy,
                UpdatedOn = DateTime.Now,
                EnforcePasswordChange = Sign.enforcePasswordChange,

            };
            MembersinRole MemberRole = new MembersinRole
            {
                //  MembershipId = Sign.membershipId,
                RoleId = Sign.roleId,
                Active = Sign.roleActive,
                Status = Sign.status,
                CreatedBy = Sign.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Sign.createdBy,
                UpdatedOn = DateTime.Now,
            };
            Contact Cont = new Contact
            {

                //  MembershipId=Sign.membershipId,
                //IsPrimary = Sign.isPrimary,
                Salutation = Sign.salutation,
                FirstName = Sign.firstName,
                MiddleName = Sign.middleName,
                LastName = Sign.lastName,
                Dob = Sign.dob,
                Sex = Sign.sex,
                EMail = Sign.email,
                PhoneAreaCode = Sign.phoneAreaCode,
                Phone = Sign.phone,
                HomePhone = Sign.homePhone,
                MobilePhone = Sign.mobilePhone,
                //Fax = Sign.fax,
                PreferredContact = Sign.preferredContact,
                //WebSite = Sign.webSite,
                Status = Sign.status,
                //Identifier = Sign.identifier,
                CreatedBy = Sign.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Sign.createdBy,
                UpdatedOn = DateTime.Now,

            };
            Address memAddress = new Address
            {
                AddTypeId = Sign.addTypeId,
                Address1 = Sign.address1,
                Address2 = Sign.address2,
                Address3 = Sign.address3,
                CityId = Sign.cityId,
                RegionId = Sign.regionId,
                CountryId = Sign.countryId,
                PostCode = Sign.postCode,
                Status = Sign.status,
                Active = Sign.active,
                Identifier = Sign.identifier,
                CreatedBy = Sign.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Sign.createdBy,
                UpdatedOn = DateTime.Now,

            };


            Mem.Contacts.Add(Cont);
            Mem.MembersinRoles.Add(MemberRole);
            context.Memberships.Add(Mem);
            Cont.Addresses.Add(memAddress);
            //    context.Contacts.Add(cont);

            context.SaveChanges();

            return "Register Successful";
        }
        public Logindata AccessLogin(Logindata Log)
        {


            var Mem = context.Memberships.Where(a => a.UserName.Equals(Log.userName)).FirstOrDefault();
            if (Mem != null)
            {

                if (Mem.Password == Log.password)
                {

                    Logindata Reg = new Logindata
                    {
                        membershipId = Mem.MembershipId,
                        userName = Mem.UserName,
                        password = Mem.Password,
                        role = Mem.MembershipTypeCode,
                        isLockedOut = Mem.IsLockedOut,

                    };
                    Mem.IsOnline = true;
                    Mem.LastLoginDate = DateTime.Now;
                    Mem.FailedPasswordAttemptCount = 0;
                    context.SaveChanges();
                    return Reg;
                }
                else
                {

                    if(Mem.FailedPasswordAttemptCount>3)
                    {
                        Log.failedPasswordAttemptCount = Mem.FailedPasswordAttemptCount;
                        Mem.IsLockedOut = true;
                        Mem.IsApproved = false;
                        Mem.LastLockoutDate = DateTime.Now;
                        context.SaveChanges();
                        Log.isLockedOut = true;
                     
                        return Log;

                    }

                    var fail = Mem.FailedPasswordAttemptCount;
                    Mem.FailedPasswordAttemptCount=++fail;
                    context.SaveChanges();
                    return Log;
                    
                }
            }
            //var Member = context.Memberships.Where(a => a.UserName.Equals(Log.userName)).FirstOrDefault();
            //if(Member!=null)
            //{
               
            //   //Reg.failedPasswordAttemptCount++;

            //    Member.FailedPasswordAttemptCount++;
            //    context.SaveChanges();
            //    return Log;
              
            //}
            return null;
          


        }
        public string AccessVendorSignUp(Vendordata Obj)
        {

            Vendor Vend = new Vendor
            {
                VendorName = Obj.vendorName,
                CreatedBy = Obj.vendorName,
                CreatedOn = DateTime.Now,
                UpdatedBy = Obj.createdBy,
                UpdatedOn = DateTime.Now,

            };

            Contact cont = new Contact
            {

                //  MembershipId=Sign.membershipId,
                //IsPrimary = Obj.isPrimary,
                Salutation = Obj.salutation,
                FirstName = Obj.firstName,
                MiddleName = Obj.middleName,
                LastName = Obj.lastName,
                Dob = Obj.dob,
                Sex = Obj.sex,
                EMail = Obj.email,
                PhoneAreaCode = Obj.phoneAreaCode,
                Phone = Obj.phone,
                HomePhone = Obj.homePhone,
                MobilePhone = Obj.mobilePhone,
                Fax = Obj.fax,
                PreferredContact = Obj.preferredContact,
                //WebSite = Obj.webSite,
                //Status = Obj.status,
                Identifier = Obj.identifier,
                CreatedBy = Obj.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Obj.createdBy,
                UpdatedOn = DateTime.Now,

            };
            Address venAddress = new Address
            {
                AddTypeId = Obj.addTypeId,
                Address1 = Obj.address1,
                Address2 = Obj.address2,
                Address3 = Obj.address3,
                CityId = Obj.cityId,
                RegionId = Obj.regionId,
                CountryId = Obj.countryId,
                PostCode = Obj.postCode,
                Status = Obj.status,
                Active = Obj.active,
                Identifier = Obj.identifier,
                CreatedBy = Obj.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Obj.createdBy,
                UpdatedOn = DateTime.Now,

            };
            Vend.Contacts.Add(cont);
            context.Vendors.Add(Vend);

            cont.Addresses.Add(venAddress);
            context.Contacts.Add(cont);
            context.SaveChanges();

            //Member.Contactdetails.Add(Cont);
            //db.Memberships.Add(Member);
            //db.SaveChanges();
            return "Register Successful";
        
        }
        public void LogOutDetails(int membershipId)
        {

            var member = context.Memberships.FirstOrDefault(x => x.MembershipId == membershipId);
            if(member!=null)
            {
                member.LastActivityDate = DateTime.Now;
                member.IsOnline = false;
                context.SaveChanges();
            }

        }

    }
}
