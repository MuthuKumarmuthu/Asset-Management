using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessObject
{
    
    public class SearchObject
    {
        public string? searchNameOFUser { get; set; }
        public string? searchAssetName { get; set; }
        public string? searchAssetCode { get; set; }


    }
    public class DashboardObject
    {
        public int? assetno { get; set; }
        public int? staffs { get; set; }
        public int? owner { get; set; }
        public int? assetType { get; set; }
        public int? admin { get; set; }
        public int? vendor { get; set; }

    }
    public class AssetsObject
    {
        //assetStatus

   //     public int AssestStatusId { get; set; }

        public int? assetId { get; set; }
        public string? code { get; set; }

        public string? description { get; set; }

        public bool? status { get; set; }

        //assets


     //   public int AssestId { get; set; }

        public string? name { get; set; }

   //     public string? Code { get; set; }

     //   public string? Description { get; set; }

        public int assetTypeId { get; set; }

        public int? departmentId { get; set; }

        public int? assestStatusId { get; set; }

        public int? vendorId { get; set; }

        public int? ownerId { get; set; }

        public int? userId { get; set; }

        public string? serialNumber { get; set; }

        public string? make { get; set; }

        public string? model { get; set; }

        public string? processor { get; set; }

        public string? memory { get; set; }

        public string? storage { get; set; }

        public string? operatingSystem { get; set; }

        public string? ipaddress { get; set; }

        public string? insuranceDetails { get; set; }

        public string? licenceDetails { get; set; }

        public DateTime? licenceExpiry { get; set; }

        public DateTime? purchaseDate { get; set; }

        public string? invoiceNumber { get; set; }

        public string? amc { get; set; }

        public string? warranty { get; set; }

        public string? remarks { get; set; }

        public string? location { get; set; }

        public int? toolId { get; set; }

        public string? toolName { get; set; }

        public bool? isInternal { get; set; }

        public string? toolSerialNo { get; set; }

        public string? keys { get; set; }


  //      public int toolsinAssetId { get; set; }


        public bool? toolStatus { get; set; }

        public bool? active { get; set; }

        public string? createdBy { get; set; } 

        public DateTime? createdOn { get; set; }

        public string? updatedBy { get; set; } 

        public DateTime? updatedOn { get; set; }

      //  public byte[]? Version { get; set; } 
      public string? assetType { get; set; }
        public string? department { get; set; }
        public string? owner { get; set; }
        public string? vendor { get; set; }
        public string? user { get; set; }

    }
    public class AssetObject
    {
        //assetStatus

        //     public int AssestStatusId { get; set; }
        public int? AssetId { get; set; }
        public string? code { get; set; }

        public string? description { get; set; }

        public bool? status { get; set; }

        public string? name { get; set; }

        //     public string? Code { get; set; }

        //   public string? Description { get; set; }

        public int? assetTypeId { get; set; }

        public int? departmentId { get; set; }

        public int? assestStatusId { get; set; }

        public int? vendorId { get; set; }

        public int? ownerId { get; set; }

        public int? userId { get; set; }

        public string? serialNumber { get; set; }

        public string? make { get; set; }

        public string? model { get; set; }

        public string? processor { get; set; }

        public string? memory { get; set; }

        public string? storage { get; set; }

        public string? operatingSystem { get; set; }

        public string? ipaddress { get; set; }

        public string? insuranceDetails { get; set; }

        public string? licenceDetails { get; set; }

        public DateTime? licenceExpiry { get; set; }

        public DateTime? purchaseDate { get; set; }

        public string? invoiceNumber { get; set; }

        public string? amc { get; set; }

        public string? warranty { get; set; }

        public string? remarks { get; set; }

        public string? location { get; set; }

        public string? createdBy { get; set; }

        public DateTime? createdOn { get; set; }

        public string? updatedBy { get; set; }

        public DateTime? updatedOn { get; set; }

        public int toolId { get; set; }

        public string? toolName { get; set; }

        public bool? isInternal { get; set; }

        public string? toolSerialNo { get; set; }

        public string? keys { get; set; }


       public int toolsinAssetId { get; set; }


        public bool? toolstatus { get; set; }

        public bool? active { get; set; }


    }
    public class ToolObject
    {

      //  public int toolId { get; set; }

        public string? name { get; set; }

        public bool isInternal { get; set; }

        public string? serialNumber { get; set; }

        public string? keys { get; set; }

       
        public int assetId { get; set; }


        public bool? status { get; set; }

        public bool? active { get; set; }

        public string? createdBy { get; set; }

        public DateTime createdOn { get; set; }

        public string? updatedBy { get; set; }

        public DateTime? updatedOn { get; set; }
    }

    public class Vendorlist
    {
        public int vendorId { get; set; }
        public string vendorName { get; set; } = null!;

    }
    public class OwnerList
    {
        public int ownerId { get; set; }
        public string ownerName { get; set; } = null!;

    }


    public class UserList
    {
        public int userId { get; set; }
        public string userName { get; set; } = null!;

    }


    public class Dropdownlist
    {
        public List<AssetTypeList>? AssetTypeList { get; set; }
        public List<DepartmentList>? DepartmentList { get; set; }
        public List<Vendorlist>? Vendorlist { get; set; }
        public List<OwnerList>? OwnerList { get; set; }
        public List<UserList>? UserList { get; set; }
    }


    public class AssetTypeList
    {
        public int assetTypeId { get; set; }
        public string? assetTypeCode { get; set; }
        public string? assetTypeDescription { get; set; }
    }

    public class DepartmentList
    {
        public int departmentId { get; set; }
        public string? departmentCode { get; set; }
        public string? departmentDescription { get; set; }

    }



    public class AddressDropdown
    {
        public List<CountryList>? CountryList { get; set; }
        public List<RegionsList>? RegionsList { get; set; }
        public List<CityList>? CityList { get; set; }
      
    }
    public class CountryList
    {
        public int countryId { get; set; }
        public string? countryCode { get; set; }
        public string? countryName { get; set; }

    }

    public class RegionsList
    {
        public int regionId { get; set; }
        public string? regionCode { get; set; }
        public string? regionName { get; set; }

    }
    public class CityList
    {
        public int cityId { get; set; }
        public string? cityCode { get; set; }
        public string? cityName { get; set; }

    }
    public class RoleList
    {
        public int roleId { get; set; }
        public string? roleCode { get; set; }
        public string? roleName { get; set; }

    }
    public class AddressTypeList
    {
        public int typeId { get; set; }
        public string? typeCode { get; set; }
        public string? typeName { get; set; }

    }
    public class AssetIdList
    {
        public int assetId { get; set; }
        public string? assetName { get; set; } 
    }

    public class UserItems
    {
        public int membershipId { get; set; }
        public string? userName { get; set; }

        public string? role { get; set; }


        public bool? isLockedOut { get ;set ;}
  //      public bool? status { get; set; }
    }

    public class UserActivityObject
    {
        public int membershipId { get; set; }
        public string? userName { get; set; }
        public string? host { get; set; }
        public string? requestMethod { get; set; }
        public string? requestUrl { get; set; }
        public string? ipAddress { get; set; }

        public DateTime? LoggedinTime { get; set; }
        public DateTime? LoggedOutTime { get; set; }
    }


    public class DownloadObject
    {
      
        public string? assetType { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        public bool? status { get; set; }
        public string? department { get; set; }
        public string? owner { get; set; }
        public string? vendor { get; set; }
        public string? user { get; set; }

        public string? serialNumber { get; set; }

        public string? make { get; set; }

        public string? model { get; set; }

        public string? processor { get; set; }

        public string? memory { get; set; }

        public string? storage { get; set; }

        public string? operatingSystem { get; set; }

        public string? ipaddress { get; set; }

        public string? insuranceDetails { get; set; }

        public string? licenceDetails { get; set; }

        public DateTime? licenceExpiry { get; set; }

        public DateTime? purchaseDate { get; set; }

        public string? invoiceNumber { get; set; }

        public string? amc { get; set; }

        public string? warranty { get; set; }

        public string? remarks { get; set; }

        public string? location { get; set; }

     

        public string? toolName { get; set; }

        public bool? isInternal { get; set; }

        public string? toolSerialNo { get; set; }

        public string? keys { get; set; }


        public bool? toolStatus { get; set; }

        public bool? active { get; set; }

      
       

    }

}

