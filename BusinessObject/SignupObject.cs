using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{

    public class Signupdata
    {
        public int membershipId { get; set; }

        public string membershipTypeCode { get; set; } = null!;

        public DateTime registeredDate { get; set; }

        public string userName { get; set; } = null!;

        public string? aliasName { get; set; }

        public string password { get; set; } = null!;

        public string? passwordQuestion { get; set; }

        public string? passwordAnswer { get; set; }

        public string? emailAddress { get; set; }

        public string? email { get; set; }

        public string? loweredEmail { get; set; }

        public bool? isLockedOut { get; set; }

        public DateTime? lastPasswordChangedDate { get; set; }

        public DateTime? lastLockoutDate { get; set; }

        public int? failedPasswordAttemptCount { get; set; }

        public int? failedPasswordAnswerAttemptCount { get; set; }

        public bool? isApproved { get; set; }

        public DateTime? lastLoginDate { get; set; }

        public DateTime? lastActivityDate { get; set; }

        public bool? isOnline { get; set; }

        public DateTime? lastModifiedDate { get; set; }

        public string? comments { get; set; }

        public bool? tandCaccepted { get; set; }

        public byte[]? profileImage { get; set; }
       // public string? profileImage { get; set; }
            
        public string? profileImageContentType { get; set; }

        public bool active { get; set; }

        public bool status { get; set; }

        public string? createdBy { get; set; } 

        public DateTime? createdOn { get; set; }

        public string? updatedBy { get; set; } 

        public DateTime? updatedOn { get; set; }

        public bool enforcePasswordChange { get; set; }

        public int? contactId { get; set; }

   
        public int? VendorId { get; set; }

        public bool? isPrimary { get; set; }

        public string salutation { get; set; } = null!;

        public string firstName { get; set; } = null!;

        public string? middleName { get; set; }

        public string lastName { get; set; } = null!;

        public DateTime? dob { get; set; }

        public string? sex { get; set; }


        public string? phoneAreaCode { get; set; }

        public string? phone { get; set; }

        public string? homePhone { get; set; }

        public string? mobilePhone { get; set; }

        public string? fax { get; set; }

        public string? preferredContact { get; set; }

        public string? webSite { get; set; }

    //    public bool? status { get; set; }

        public string? identifier { get; set; }

    
        public int roleId { get; set; }

        public bool roleActive { get; set; }

        public bool roleStatus { get; set; }

        
        public int addTypeId { get; set; }

        public string address1 { get; set; } = null!;

        public string? address2 { get; set; }

        public string? address3 { get; set; }

        public int cityId { get; set; }

        public int regionId { get; set; }

        public int countryId { get; set; }

        public string postCode { get; set; } = null!;



    }
    public class Logindata
    {
        public int membershipId { get; set; }
        public string userName { get; set; } = null!;
       
        public string password { get; set; } = null!;
        public string? role { get; set; } 

        public string? token { get; set; }
        public bool? isLockedOut { get; set; }
        public int? failedPasswordAttemptCount { get; set; }

    }
    public class Vendordata
    {
        public int contactId { get; set; }

        //  public int? membershipId { get; set; }

        public string vendorName { get; set; } = null!;

        public bool? isPrimary { get; set; }

        public string salutation { get; set; } = null!;

        public string firstName { get; set; } = null!;

        public string? middleName { get; set; }

        public string lastName { get; set; } = null!;

        public DateTime? dob { get; set; }

        public string? sex { get; set; }
        public string? email { get;set; }

      

        public string? phoneAreaCode { get; set; }

        public string? phone { get; set; }

        public string? homePhone { get; set; }

        public string? mobilePhone { get; set; }

        public string? fax { get; set; }

        public string? preferredContact { get; set; }

        public string? webSite { get; set; }

        //    public bool? status { get; set; }

        public string? identifier { get; set; }

    
        public int roleId { get; set; }

        public bool roleActive { get; set; }

        public bool roleStatus { get; set; }

      
        public int addTypeId { get; set; }

        public string address1 { get; set; } = null!;

        public string? address2 { get; set; }

        public string? address3 { get; set; }

        public int cityId { get; set; }

        public int regionId { get; set; }

        public int countryId { get; set; }

        public string postCode { get; set; } = null!;

        public bool? status { get; set; }

        public bool? active { get; set; }

        //public string? identifier { get; set; }
        public string? createdBy { get; set; }

        public DateTime? createdOn { get; set; }

        public string? updatedBy { get; set; }

        public DateTime? updatedOn { get; set; }

    }


}
