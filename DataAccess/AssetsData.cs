using BusinessObject;

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Diagnostics;
using System.Net;
using System.Globalization;

namespace DataAccess
{
    public class AssetsData
    {
        public AssestInventoryContext context;
        public AssetsData()
        {
            context = new AssestInventoryContext();
        }
        public Dropdownlist GetDropdownList()
        {


            Dropdownlist Drop = new Dropdownlist();
           var result = (from Assettype in context.AssestTypes
                                      select new AssetTypeList
                                      {
                                          assetTypeId = Assettype.AssestTypeId,
                                          assetTypeCode = Assettype.Code,
                                          assetTypeDescription = Assettype.Description
                                      }).ToList();

           var res = (from department in context.Departments
                                       select new DepartmentList
                                       {
                                           departmentId = department.DepartmentId,
                                           departmentCode = department.Code,
                                           departmentDescription = department.Description
                                       }).ToList();

            var vendorList = (from vendor in context.Vendors
                       select new Vendorlist
                       {
                           vendorId = vendor.VendorId,
                           vendorName = vendor.VendorName,
                        
                       }).ToList();
          

            var ownerlist = (from owner in context.Memberships.Where(x=>x.MembershipTypeCode=="OWNER")
                           
                             select new OwnerList
                             {
                                 ownerId = owner.MembershipId,
                                 ownerName = owner.UserName,
                              
                             }).ToList();

            var user = (from Mem in context.Memberships.Where(x=>x.MembershipTypeCode=="STAFF")
         
                        select new UserList
                        {
                              userId = Mem.MembershipId,
                              userName = Mem.UserName,
                             
                          }).ToList();


            Drop.AssetTypeList = result;
            Drop.DepartmentList = res;
            Drop.Vendorlist = vendorList;
            Drop.OwnerList = ownerlist;
            Drop.UserList = user;
            return Drop;
       



        }
        public List<AssetIdList> GetAssetIdList()
        {

            var result = (from Id in context.Assests
                          select new AssetIdList
                          {
                              assetId = Id.AssestId,
                              assetName = Id.Code,
                          }).ToList();

            return result;


        }


        public void CreateAssetRegister(AssetsObject Obj)
        {
         

            AssestStatus Status = new AssestStatus
            {
                Code = Obj.code,
                Description = Obj.description,
                Status = Obj.status,
                CreatedBy = Obj.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Obj.createdBy,
                UpdatedOn = DateTime.Now,
               
        };
            Assest AssetDet = new Assest
            {
                Name = Obj.name,
                Code = Obj.code,
                Description = Obj.description,
                AssestTypeId= Obj.assetTypeId,
                DepartmentId = Obj.departmentId,
              //  AssestStatusId =Obj.AssestStatusId,
                VendorId = Obj.vendorId,
                OwnerId =Obj.ownerId,
                UserId = Obj.userId,
                SerialNumber =Obj.serialNumber,
                Make =Obj.make,
                Model =Obj.model,
                Processor = Obj.processor,
                Memory =Obj.memory,
                Storage =Obj.storage,
                OperatingSystem=Obj.operatingSystem,
                Ipaddress =Obj.ipaddress,
                InsuranceDetails=Obj.insuranceDetails,
                LicenceDetails =Obj.licenceDetails,
                LicenceExpiry =Obj.licenceExpiry,
                PurchaseDate =Obj.purchaseDate,
                InvoiceNumber =Obj.invoiceNumber,
                Amc =Obj.amc,
                Warranty =Obj.warranty,
                Remarks =Obj.remarks,
                Location =Obj.location,
                CreatedBy =Obj.createdBy ,
                CreatedOn =DateTime.Now,
                UpdatedBy =Obj.createdBy,
                UpdatedOn=DateTime.Now,
             

        };
            DevelopmentTool DevelopTool = new DevelopmentTool
            {
                Name = Obj.toolName,
                IsInternal = Obj.isInternal,
                SerialNumber = Obj.toolSerialNo,
                Keys = Obj.keys,
                CreatedBy = Obj.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Obj.createdBy,
                UpdatedOn = DateTime.Now,

            };

            ToolsinAssest ToolAsset = new ToolsinAssest
            {
                Status = Obj.toolStatus,
                Active = Obj.active,
                CreatedBy = Obj.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = Obj.createdBy,
                UpdatedOn = DateTime.Now,

            };


            Status.Assests.Add(AssetDet);
            context.AssestStatuses.Add(Status);
       

            AssetDet.ToolsinAssests.Add(ToolAsset);
            context.Assests.Add(AssetDet);

            DevelopTool.ToolsinAssests.Add(ToolAsset);
            context.DevelopmentTools.Add(DevelopTool);
            context.SaveChanges();


        }





        public List<AssetsObject> GetAssetRegister()
        {

         
            var result = (from assetStatus in context.AssestStatuses
                        join asset in context.Assests on assetStatus.AssestStatusId equals asset.AssestStatusId
                        join toolsInAsset in context.ToolsinAssests on asset.AssestId equals toolsInAsset.AssestId
                        join developmentTool in context.DevelopmentTools on toolsInAsset.ToolId equals developmentTool.ToolId
                        join assettype in context.AssestTypes on asset.AssestTypeId equals assettype.AssestTypeId
                        join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                        join owner in context.Memberships on asset.OwnerId equals owner.MembershipId
                        join user in context.Memberships on asset.UserId equals user.MembershipId
                        join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                        select new AssetsObject
                        {
                              assetId = asset.AssestId,
                              code = asset.Code,
                              description= asset.Description,
                              name = asset.Name,
                              status = assetStatus.Status,
                              assetTypeId = asset.AssestTypeId,
                              departmentId = asset.DepartmentId,
                              assestStatusId=asset.AssestStatusId,
                              vendorId=asset.VendorId,
                              ownerId=asset.OwnerId,
                              userId=asset.UserId,
                              serialNumber=asset.SerialNumber,
                              make=asset.Make,
                              model=asset.Model,
                              processor=asset.Processor,
                              memory=asset.Memory,
                              storage=asset.Storage,
                              operatingSystem=asset.OperatingSystem,
                              ipaddress=asset.Ipaddress,
                              insuranceDetails=asset.InsuranceDetails,
                              licenceDetails=asset.LicenceDetails,
                              licenceExpiry=asset.LicenceExpiry,
                              purchaseDate=asset.PurchaseDate,
                              invoiceNumber=asset.InvoiceNumber,
                              amc=asset.Amc,
                              warranty=asset.Warranty,  
                              location=asset.Location,
                              remarks=asset.Remarks,
                              toolId=developmentTool.ToolId,
                              toolName=developmentTool.Name,
                              toolSerialNo=developmentTool.SerialNumber,
                              isInternal=developmentTool.IsInternal,
                              keys=developmentTool.Keys,
                              toolStatus=toolsInAsset.Status,
                              active=toolsInAsset.Active,
                              assetType=assettype.Description,
                              department=depart.Description,
                              user=user.UserName,
                              owner=owner.UserName,
                              vendor=vendor.VendorName,

                             
                          }).ToList();
    
            
                return result;
            
       

        }
        public void DeleteAssetRegister(int assetId)
        {

            var result = (from asset in context.Assests
                          join assetStatus in context.AssestStatuses on asset.AssestStatusId equals assetStatus.AssestStatusId
                          join toolAsset in context.ToolsinAssests on asset.AssestId equals toolAsset.AssestId
                          join developmentTool in context.DevelopmentTools on toolAsset.ToolId equals developmentTool.ToolId
                          where asset.AssestId == assetId
                          select new
                          {
                              Asset = asset,
                              AssetStatus = assetStatus,
                              ToolAsset = toolAsset,
                              DevelopmentTool = developmentTool
                          })
                 .FirstOrDefault();

            if (result != null)
            {
              
                context.ToolsinAssests.Remove(result.ToolAsset);
                context.DevelopmentTools.Remove(result.DevelopmentTool);
                context.Assests.Remove(result.Asset);
                context.AssestStatuses.Remove(result.AssetStatus);
              

                context.SaveChanges();
            }

              

        }
        public void UpdateAssetRegister(int assetId, AssetsObject Obj)
        {
            var query = (from asset in context.Assests
                         join statusAsset in context.AssestStatuses on asset.AssestStatusId equals statusAsset.AssestStatusId
                         join toolAsset in context.ToolsinAssests on asset.AssestId equals toolAsset.AssestId
                         join developTool in context.DevelopmentTools on toolAsset.ToolId equals developTool.ToolId
                         where asset.AssestId == assetId
                         select new
                         {
                             Asset = asset,
                             AssetStatus = statusAsset,
                             ToolAsset = toolAsset,
                             DevelopmentTool = developTool
                         }).FirstOrDefault();
         

            if (query != null)
            {
                var asset = query.Asset;
                var statusAsset = query.AssetStatus;
                var toolAsset = query.ToolAsset;
                var developTool = query.DevelopmentTool;

                statusAsset.Code = Obj.code;
                statusAsset.Description = Obj.description;
                statusAsset.Status = Obj.status;
                //statusAsset.CreatedBy = "Muthu";
                //statusAsset.CreatedOn = DateTime.Now;
                statusAsset.UpdatedBy = Obj.updatedBy;
                statusAsset.UpdatedOn = DateTime.Now;

                asset.Code = Obj.code;
                asset.Description = Obj.description;
                asset.Name = Obj.name;
                asset.AssestTypeId = Obj.assetTypeId;
                asset.DepartmentId = Obj.departmentId;
                asset.VendorId = Obj.vendorId;
                asset.OwnerId = Obj.ownerId;
                asset.UserId = Obj.userId;
                asset.SerialNumber = Obj.serialNumber;
                asset.Make = Obj.make;
                asset.Model = Obj.model;
                asset.Processor = Obj.processor;
                asset.Memory = Obj.memory;
                asset.Storage = Obj.storage;
                asset.OperatingSystem = Obj.operatingSystem;
                asset.Ipaddress = Obj.ipaddress;
                asset.InsuranceDetails = Obj.insuranceDetails;
                asset.LicenceDetails = Obj.licenceDetails;
                asset.LicenceExpiry = Obj.licenceExpiry;
                asset.PurchaseDate = Obj.purchaseDate;
                asset.InvoiceNumber = Obj.invoiceNumber;
                asset.Amc = Obj.amc;
                asset.Warranty = Obj.warranty;
                asset.Location = Obj.location;
                asset.SerialNumber = Obj.serialNumber;
                //asset.CreatedBy = "Muthu";
                //asset.CreatedOn = DateTime.Now;
                asset.UpdatedBy = Obj.updatedBy;
                asset.UpdatedOn = DateTime.Now;

                developTool.Name = Obj.toolName;
                developTool.IsInternal = Obj.isInternal;
                developTool.SerialNumber = Obj.toolSerialNo;
                developTool.Keys = Obj.keys;
                //developTool.CreatedBy = "Muthu";
                //developTool.CreatedOn = DateTime.Now;
                developTool.UpdatedBy = Obj.updatedBy;
                developTool.UpdatedOn = DateTime.Now;

                toolAsset.Status = Obj.toolStatus;
                toolAsset.Active = Obj.active;
                //toolAsset.CreatedBy = "Muthu";
                //toolAsset.CreatedOn = DateTime.Now;
                toolAsset.UpdatedBy = Obj.updatedBy;
                toolAsset.UpdatedOn = DateTime.Now;
            }

            context.SaveChanges();
        }


        public DashboardObject Dashboard()
        {

            DashboardObject Dash = new DashboardObject();
            var asset = context.Assests.Count();
            Dash.assetno = asset;
            var admin = context.Memberships.Where(x=>x.MembershipTypeCode=="ADMIN").Count();
            Dash.admin = admin;
            var owner = context.Memberships.Where(x => x.MembershipTypeCode == "OWNER").Count();
            Dash.owner = owner;
            var user = context.Memberships.Where(x => x.MembershipTypeCode == "STAFF").Count();
            Dash.staffs = user;
            var vendor = context.Vendors.Count();
            Dash.vendor = vendor;
            var assettype = context.AssestTypes.Count();
            Dash.assetType = assettype;

            return Dash;

        }

        public void AssetToolRegister(ToolObject Obj)
        {
            DevelopmentTool DevelopTool = new DevelopmentTool
            {
                    Name = Obj.name,
                    IsInternal = Obj.isInternal,
                    SerialNumber = Obj.serialNumber,
                    Keys = Obj.keys,
                    CreatedBy = Obj.createdBy,
                    CreatedOn = DateTime.Now,
                    UpdatedBy = null,
                    UpdatedOn = null,

                };

            ToolsinAssest ToolAsset = new ToolsinAssest
            {
                AssestId=Obj.assetId,
                Status = Obj.status,
                Active = Obj.active,
                CreatedBy =Obj.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = null,
                UpdatedOn = DateTime.Now,

            };
            DevelopTool.ToolsinAssests.Add(ToolAsset);
            context.DevelopmentTools.Add(DevelopTool);
            context.SaveChanges();

        }

        public List<UserItems> GetUserRegister()
        {

            var result = (from user in context.Memberships.Where(x => x.MembershipTypeCode == "STAFF" || x.MembershipTypeCode == "OWNER" || x.MembershipTypeCode=="ADMIN")
                          select new UserItems
                          {
                              membershipId=user.MembershipId,
                              role=user.MembershipTypeCode,
                              userName=user.UserName,
                              isLockedOut=user.IsLockedOut,
                              //active=user.Active,
                              //status=user.Status,

                          }).ToList();
            return result;


        }
        //    GetStaffAssets

        public List<AssetsObject> GetStaffAssets(int membershipId, string role)
        {
       
            if (role == "STAFF")
            {
                var result = (from membership in context.Memberships.Where(x => x.MembershipId == membershipId)
                              join asset in context.Assests on membership.MembershipId equals asset.UserId
                              join assetstatus in context.AssestStatuses on asset.AssestStatusId equals assetstatus.AssestStatusId
                              join toolsinassets in context.ToolsinAssests on asset.AssestId equals toolsinassets.AssestId
                              join developmenttool in context.DevelopmentTools on toolsinassets.ToolId equals developmenttool.ToolId
                              join AssetType in context.AssestTypes on asset.AssestTypeId equals AssetType.AssestTypeId
                              join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                              join owner in context.Memberships on asset.OwnerId equals  owner.MembershipId
                              join user in context.Memberships on asset.UserId equals user.MembershipId
                              join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                              select new AssetsObject

                              {
                               //   assetId = asset.AssestId,
                                  code = asset.Code,
                                  description = asset.Description,
                                  name = asset.Name,
                                  status = assetstatus.Status,
                                  assetType = AssetType.Code,
                                  department = depart.Description,
                                //  assestStatusId = asset.AssestStatusId,
                                  vendor = vendor.VendorName,
                                  owner = owner.UserName,
                                  user = user.UserName,
                                  serialNumber = asset.SerialNumber,
                                  make = asset.Make,
                                  model = asset.Model,
                                  processor = asset.Processor,
                                  memory = asset.Memory,
                                  storage = asset.Storage,
                                  operatingSystem = asset.OperatingSystem,
                                  ipaddress = asset.Ipaddress,
                                  insuranceDetails = asset.InsuranceDetails,
                                  licenceDetails = asset.LicenceDetails,
                                  licenceExpiry = asset.LicenceExpiry,
                                  purchaseDate = asset.PurchaseDate,
                                  invoiceNumber = asset.InvoiceNumber,
                                  amc = asset.Amc,
                                  warranty = asset.Warranty,
                                  location = asset.Location,
                                  remarks = asset.Remarks,
                                //  toolId = developmenttool.ToolId,
                                  toolName = developmenttool.Name,
                                  toolSerialNo = developmenttool.SerialNumber,
                                  isInternal = developmenttool.IsInternal,
                                  keys = developmenttool.Keys,
                                  toolStatus = toolsinassets.Status,
                                  active = toolsinassets.Active,

                              }).ToList();


                return result;
            }
            else if (role == "OWNER")
            {
                var result = (from membership in context.Memberships.Where(x => x.MembershipId == membershipId)
                              join asset in context.Assests on membership.MembershipId equals asset.OwnerId
                              join assetstatus in context.AssestStatuses on asset.AssestStatusId equals assetstatus.AssestStatusId
                              join toolsinassets in context.ToolsinAssests on asset.AssestId equals toolsinassets.AssestId
                              join developmenttool in context.DevelopmentTools on toolsinassets.ToolId equals developmenttool.ToolId
                              join AssetType in context.AssestTypes on asset.AssestTypeId equals AssetType.AssestTypeId
                              join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                              join owner in context.Memberships on asset.OwnerId equals owner.MembershipId
                              join user in context.Memberships on asset.UserId equals user.MembershipId
                              join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                              select new AssetsObject

                              {
                               //   assetId = asset.AssestId,
                                  code = asset.Code,
                                  description = asset.Description,
                                  name = asset.Name,
                                  status = assetstatus.Status,
                                  assetType = AssetType.Code,
                                  department = depart.Description,
                                  //  assestStatusId = asset.AssestStatusId,
                                  vendor = vendor.VendorName,
                                  owner = owner.UserName,
                                  user = user.UserName,
                                  serialNumber = asset.SerialNumber,
                                  make = asset.Make,
                                  model = asset.Model,
                                  processor = asset.Processor,
                                  memory = asset.Memory,
                                  storage = asset.Storage,
                                  operatingSystem = asset.OperatingSystem,
                                  ipaddress = asset.Ipaddress,
                                  insuranceDetails = asset.InsuranceDetails,
                                  licenceDetails = asset.LicenceDetails,
                                  licenceExpiry = asset.LicenceExpiry,
                                  purchaseDate = asset.PurchaseDate,
                                  invoiceNumber = asset.InvoiceNumber,
                                  amc = asset.Amc,
                                  warranty = asset.Warranty,
                                  location = asset.Location,
                                  remarks = asset.Remarks,
                                //  toolId = developmenttool.ToolId,
                                  toolName = developmenttool.Name,
                                  toolSerialNo = developmenttool.SerialNumber,
                                  isInternal = developmenttool.IsInternal,
                                  keys = developmenttool.Keys,
                                  toolStatus = toolsinassets.Status,
                                  active = toolsinassets.Active,

                              }).ToList();


                return result;
            }
            return null!;
        }


        public List<AssetsObject> GetAssetFilter(SearchObject search)
        {


            if (search.searchAssetCode != null && search.searchAssetName != null && search.searchNameOFUser != null)
            {
                var result = (from assetStatus in context.AssestStatuses
                              join asset in context.Assests on assetStatus.AssestStatusId equals asset.AssestStatusId
                              join toolsInAsset in context.ToolsinAssests on asset.AssestId equals toolsInAsset.AssestId
                              join developmentTool in context.DevelopmentTools on toolsInAsset.ToolId equals developmentTool.ToolId
                              join assettype in context.AssestTypes on asset.AssestTypeId equals assettype.AssestTypeId
                              join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                              join owner in context.Memberships on asset.OwnerId equals owner.MembershipId
                              join user in context.Memberships on asset.UserId equals user.MembershipId
                              join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                              where asset.Code == search.searchAssetCode && asset.Name == search.searchAssetName && user.UserName == search.searchNameOFUser

                              select new AssetsObject
                              {
                                  assetId = asset.AssestId,
                                  code = asset.Code,
                                  description = asset.Description,
                                  name = asset.Name,
                                  status = assetStatus.Status,
                                  assetTypeId = asset.AssestTypeId,
                                  departmentId = asset.DepartmentId,
                                  assestStatusId = asset.AssestStatusId,
                                  vendorId = asset.VendorId,
                                  ownerId = asset.OwnerId,
                                  userId = asset.UserId,
                                  serialNumber = asset.SerialNumber,
                                  make = asset.Make,
                                  model = asset.Model,
                                  processor = asset.Processor,
                                  memory = asset.Memory,
                                  storage = asset.Storage,
                                  operatingSystem = asset.OperatingSystem,
                                  ipaddress = asset.Ipaddress,
                                  insuranceDetails = asset.InsuranceDetails,
                                  licenceDetails = asset.LicenceDetails,
                                  licenceExpiry = asset.LicenceExpiry,
                                  purchaseDate = asset.PurchaseDate,
                                  invoiceNumber = asset.InvoiceNumber,
                                  amc = asset.Amc,
                                  warranty = asset.Warranty,
                                  location = asset.Location,
                                  remarks = asset.Remarks,
                                  toolId = developmentTool.ToolId,
                                  toolName = developmentTool.Name,
                                  toolSerialNo = developmentTool.SerialNumber,
                                  isInternal = developmentTool.IsInternal,
                                  keys = developmentTool.Keys,
                                  toolStatus = toolsInAsset.Status,
                                  active = toolsInAsset.Active,
                                  assetType = assettype.Description,
                                  department = depart.Description,
                                  user = user.UserName,
                                  owner = owner.UserName,
                                  vendor = vendor.VendorName,


                              }).ToList();

                return result;
        
            }
            else if(search.searchAssetName!=null && search.searchAssetCode!=null)
            {
                var result = (from assetStatus in context.AssestStatuses
                              join asset in context.Assests on assetStatus.AssestStatusId equals asset.AssestStatusId
                              join toolsInAsset in context.ToolsinAssests on asset.AssestId equals toolsInAsset.AssestId
                              join developmentTool in context.DevelopmentTools on toolsInAsset.ToolId equals developmentTool.ToolId
                              join assettype in context.AssestTypes on asset.AssestTypeId equals assettype.AssestTypeId
                              join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                              join owner in context.Memberships on asset.OwnerId equals owner.MembershipId
                              join user in context.Memberships on asset.UserId equals user.MembershipId
                              join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                              where asset.Code == search.searchAssetCode && asset.Name == search.searchAssetName
                              select new AssetsObject
                              {
                                  assetId = asset.AssestId,
                                  code = asset.Code,
                                  description = asset.Description,
                                  name = asset.Name,
                                  status = assetStatus.Status,
                                  assetTypeId = asset.AssestTypeId,
                                  departmentId = asset.DepartmentId,
                                  assestStatusId = asset.AssestStatusId,
                                  vendorId = asset.VendorId,
                                  ownerId = asset.OwnerId,
                                  userId = asset.UserId,
                                  serialNumber = asset.SerialNumber,
                                  make = asset.Make,
                                  model = asset.Model,
                                  processor = asset.Processor,
                                  memory = asset.Memory,
                                  storage = asset.Storage,
                                  operatingSystem = asset.OperatingSystem,
                                  ipaddress = asset.Ipaddress,
                                  insuranceDetails = asset.InsuranceDetails,
                                  licenceDetails = asset.LicenceDetails,
                                  licenceExpiry = asset.LicenceExpiry,
                                  purchaseDate = asset.PurchaseDate,
                                  invoiceNumber = asset.InvoiceNumber,
                                  amc = asset.Amc,
                                  warranty = asset.Warranty,
                                  location = asset.Location,
                                  remarks = asset.Remarks,
                                  toolId = developmentTool.ToolId,
                                  toolName = developmentTool.Name,
                                  toolSerialNo = developmentTool.SerialNumber,
                                  isInternal = developmentTool.IsInternal,
                                  keys = developmentTool.Keys,
                                  toolStatus = toolsInAsset.Status,
                                  active = toolsInAsset.Active,
                                  assetType = assettype.Description,
                                  department = depart.Description,
                                  user = user.UserName,
                                  owner = owner.UserName,
                                  vendor = vendor.VendorName,


                              }).ToList();

                return result;

            }
            else if (search.searchAssetCode != null && search.searchNameOFUser != null)
            {
                var result = (from assetStatus in context.AssestStatuses
                              join asset in context.Assests on assetStatus.AssestStatusId equals asset.AssestStatusId
                              join toolsInAsset in context.ToolsinAssests on asset.AssestId equals toolsInAsset.AssestId
                              join developmentTool in context.DevelopmentTools on toolsInAsset.ToolId equals developmentTool.ToolId
                              join assettype in context.AssestTypes on asset.AssestTypeId equals assettype.AssestTypeId
                              join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                              join owner in context.Memberships on asset.OwnerId equals owner.MembershipId
                              join user in context.Memberships on asset.UserId equals user.MembershipId
                              join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                              where asset.Code == search.searchAssetCode && user.UserName == search.searchNameOFUser
                              select new AssetsObject
                              {
                                  assetId = asset.AssestId,
                                  code = asset.Code,
                                  description = asset.Description,
                                  name = asset.Name,
                                  status = assetStatus.Status,
                                  assetTypeId = asset.AssestTypeId,
                                  departmentId = asset.DepartmentId,
                                  assestStatusId = asset.AssestStatusId,
                                  vendorId = asset.VendorId,
                                  ownerId = asset.OwnerId,
                                  userId = asset.UserId,
                                  serialNumber = asset.SerialNumber,
                                  make = asset.Make,
                                  model = asset.Model,
                                  processor = asset.Processor,
                                  memory = asset.Memory,
                                  storage = asset.Storage,
                                  operatingSystem = asset.OperatingSystem,
                                  ipaddress = asset.Ipaddress,
                                  insuranceDetails = asset.InsuranceDetails,
                                  licenceDetails = asset.LicenceDetails,
                                  licenceExpiry = asset.LicenceExpiry,
                                  purchaseDate = asset.PurchaseDate,
                                  invoiceNumber = asset.InvoiceNumber,
                                  amc = asset.Amc,
                                  warranty = asset.Warranty,
                                  location = asset.Location,
                                  remarks = asset.Remarks,
                                  toolId = developmentTool.ToolId,
                                  toolName = developmentTool.Name,
                                  toolSerialNo = developmentTool.SerialNumber,
                                  isInternal = developmentTool.IsInternal,
                                  keys = developmentTool.Keys,
                                  toolStatus = toolsInAsset.Status,
                                  active = toolsInAsset.Active,
                                  assetType = assettype.Description,
                                  department = depart.Description,
                                  user = user.UserName,
                                  owner = owner.UserName,
                                  vendor = vendor.VendorName,


                              }).ToList();

                return result;

            }
            else if (search.searchNameOFUser != null && search.searchAssetName != null)
            {
                var result = (from assetStatus in context.AssestStatuses
                              join asset in context.Assests on assetStatus.AssestStatusId equals asset.AssestStatusId
                              join toolsInAsset in context.ToolsinAssests on asset.AssestId equals toolsInAsset.AssestId
                              join developmentTool in context.DevelopmentTools on toolsInAsset.ToolId equals developmentTool.ToolId
                              join assettype in context.AssestTypes on asset.AssestTypeId equals assettype.AssestTypeId
                              join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                              join owner in context.Memberships on asset.OwnerId equals owner.MembershipId
                              join user in context.Memberships on asset.UserId equals user.MembershipId
                              join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                              where user.UserName == search.searchNameOFUser && asset.Name == search.searchAssetName
                              select new AssetsObject
                              {
                                  assetId = asset.AssestId,
                                  code = asset.Code,
                                  description = asset.Description,
                                  name = asset.Name,
                                  status = assetStatus.Status,
                                  assetTypeId = asset.AssestTypeId,
                                  departmentId = asset.DepartmentId,
                                  assestStatusId = asset.AssestStatusId,
                                  vendorId = asset.VendorId,
                                  ownerId = asset.OwnerId,
                                  userId = asset.UserId,
                                  serialNumber = asset.SerialNumber,
                                  make = asset.Make,
                                  model = asset.Model,
                                  processor = asset.Processor,
                                  memory = asset.Memory,
                                  storage = asset.Storage,
                                  operatingSystem = asset.OperatingSystem,
                                  ipaddress = asset.Ipaddress,
                                  insuranceDetails = asset.InsuranceDetails,
                                  licenceDetails = asset.LicenceDetails,
                                  licenceExpiry = asset.LicenceExpiry,
                                  purchaseDate = asset.PurchaseDate,
                                  invoiceNumber = asset.InvoiceNumber,
                                  amc = asset.Amc,
                                  warranty = asset.Warranty,
                                  location = asset.Location,
                                  remarks = asset.Remarks,
                                  toolId = developmentTool.ToolId,
                                  toolName = developmentTool.Name,
                                  toolSerialNo = developmentTool.SerialNumber,
                                  isInternal = developmentTool.IsInternal,
                                  keys = developmentTool.Keys,
                                  toolStatus = toolsInAsset.Status,
                                  active = toolsInAsset.Active,
                                  assetType = assettype.Description,
                                  department = depart.Description,
                                  user = user.UserName,
                                  owner = owner.UserName,
                                  vendor = vendor.VendorName,


                              }).ToList();

                return result;

            }
            else 
            {
                var result = (from assetStatus in context.AssestStatuses
                              join asset in context.Assests on assetStatus.AssestStatusId equals asset.AssestStatusId
                              join toolsInAsset in context.ToolsinAssests on asset.AssestId equals toolsInAsset.AssestId
                              join developmentTool in context.DevelopmentTools on toolsInAsset.ToolId equals developmentTool.ToolId
                              join assettype in context.AssestTypes on asset.AssestTypeId equals assettype.AssestTypeId
                              join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                              join owner in context.Memberships on asset.OwnerId equals owner.MembershipId
                              join user in context.Memberships on asset.UserId equals user.MembershipId
                              join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                              where asset.Code == search.searchAssetCode || asset.Name == search.searchAssetName || user.UserName ==search.searchNameOFUser
                              select new AssetsObject
                              {
                                  assetId = asset.AssestId,
                                  code = asset.Code,
                                  description = asset.Description,
                                  name = asset.Name,
                                  status = assetStatus.Status,
                                  assetTypeId = asset.AssestTypeId,
                                  departmentId = asset.DepartmentId,
                                  assestStatusId = asset.AssestStatusId,
                                  vendorId = asset.VendorId,
                                  ownerId = asset.OwnerId,
                                  userId = asset.UserId,
                                  serialNumber = asset.SerialNumber,
                                  make = asset.Make,
                                  model = asset.Model,
                                  processor = asset.Processor,
                                  memory = asset.Memory,
                                  storage = asset.Storage,
                                  operatingSystem = asset.OperatingSystem,
                                  ipaddress = asset.Ipaddress,
                                  insuranceDetails = asset.InsuranceDetails,
                                  licenceDetails = asset.LicenceDetails,
                                  licenceExpiry = asset.LicenceExpiry,
                                  purchaseDate = asset.PurchaseDate,
                                  invoiceNumber = asset.InvoiceNumber,
                                  amc = asset.Amc,
                                  warranty = asset.Warranty,
                                  location = asset.Location,
                                  remarks = asset.Remarks,
                                  toolId = developmentTool.ToolId,
                                  toolName = developmentTool.Name,
                                  toolSerialNo = developmentTool.SerialNumber,
                                  isInternal = developmentTool.IsInternal,
                                  keys = developmentTool.Keys,
                                  toolStatus = toolsInAsset.Status,
                                  active = toolsInAsset.Active,
                                  assetType = assettype.Description,
                                  department = depart.Description,
                                  user = user.UserName,
                                  owner = owner.UserName,
                                  vendor = vendor.VendorName,


                              }).ToList();

                return result;

            }


        }
        public void UpdateUserStatus(int membershipId, bool isLockedOut)
        {
            var query = context.Memberships.Where(x => x.MembershipId == membershipId).FirstOrDefault();
            if (query != null)
            {
                if (isLockedOut == false)
                {
                    query.IsLockedOut = false;
                    query.IsApproved = true;
                    query.LastLockoutDate = DateTime.Now;
                    context.SaveChanges();
                }
                else
                {
                    query.IsLockedOut = true;
                    query.IsApproved = false;
                    query.LastLockoutDate = DateTime.Now;
                    context.SaveChanges();
                }

            }

        }

        public void RegisterUserActivity(UserActivityObject  User)
        {
            UserActivityLog userActivity = new UserActivityLog
            {

                MembershipId = User.membershipId,
                UserName = User.userName,
                Host = User.host,
                LoggedinTime = User.LoggedinTime,
                LoggedoutTime=DateTime.Now,
                CreatedOn = DateTime.Now,
                IpAddress = User.ipAddress,

            };
            UserActivityLogDetail Log = new UserActivityLogDetail
            {
                RequestMethod = User.requestMethod,
                RequestUrl = User.requestUrl,
                CreatedOn=DateTime.Now,
                

            };
            userActivity.UserActivityLogDetails.Add(Log);
            context.UserActivityLogs.Add(userActivity);
            context.SaveChanges();

        }
    
        public List<UserItems> GetUserFilter(string userName)
        {
            var result = (from user in context.Memberships
                          where user.UserName == userName &&
                                (user.MembershipTypeCode == "ADMIN" ||
                                 user.MembershipTypeCode == "STAFF" ||
                                 user.MembershipTypeCode == "OWNER")
                          select new UserItems
                          {
                              membershipId = user.MembershipId,
                              role = user.MembershipTypeCode,
                              userName = user.UserName,
                              isLockedOut = user.IsLockedOut,
                              //active=user.Active,
                              //status=user.Status,
                          }).ToList();




   
            return result;




        }
        public List<DownloadObject> DownloadAssets()
        {


            var result = (from assetStatus in context.AssestStatuses
                          join asset in context.Assests on assetStatus.AssestStatusId equals asset.AssestStatusId
                          join toolsInAsset in context.ToolsinAssests on asset.AssestId equals toolsInAsset.AssestId
                          join developmentTool in context.DevelopmentTools on toolsInAsset.ToolId equals developmentTool.ToolId
                          join assettype in context.AssestTypes on asset.AssestTypeId equals assettype.AssestTypeId
                          join depart in context.Departments on asset.DepartmentId equals depart.DepartmentId
                          join owner in context.Memberships on asset.OwnerId equals owner.MembershipId
                          join user in context.Memberships on asset.UserId equals user.MembershipId
                          join vendor in context.Vendors on asset.VendorId equals vendor.VendorId
                          select new DownloadObject
                          {
                             // assetId = asset.AssestId,
                              code = asset.Code,
                              description = asset.Description,
                              name = asset.Name,
                              status = assetStatus.Status,
                              //assetTypeId = asset.AssestTypeId,
                              //departmentId = asset.DepartmentId,
                              //assestStatusId = asset.AssestStatusId,
                              //vendorId = asset.VendorId,
                              //ownerId = asset.OwnerId,
                             // userId = asset.UserId,
                              serialNumber = asset.SerialNumber,
                              make = asset.Make,
                              model = asset.Model,
                              processor = asset.Processor,
                              memory = asset.Memory,
                              storage = asset.Storage,
                              operatingSystem = asset.OperatingSystem,
                              ipaddress = asset.Ipaddress,
                              insuranceDetails = asset.InsuranceDetails,
                              licenceDetails = asset.LicenceDetails,
                              licenceExpiry = asset.LicenceExpiry,
                              purchaseDate = asset.PurchaseDate,
                              invoiceNumber = asset.InvoiceNumber,
                              amc = asset.Amc,
                              warranty = asset.Warranty,
                              location = asset.Location,
                              remarks = asset.Remarks,
                            //  toolId = developmentTool.ToolId,
                              toolName = developmentTool.Name,
                              toolSerialNo = developmentTool.SerialNumber,
                              isInternal = developmentTool.IsInternal,
                              keys = developmentTool.Keys,
                              toolStatus = toolsInAsset.Status,
                              active = toolsInAsset.Active,
                              assetType = assettype.Description,
                              department = depart.Description,
                              user = user.UserName,
                              owner = owner.UserName,
                              vendor = vendor.VendorName,


                          }).ToList();


            return result;



        }



    }
}