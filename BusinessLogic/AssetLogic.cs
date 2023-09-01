using Azure;
using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AssetLogic
    {
        public AssetsData AssetDB;
        public AssetLogic()
        {
            AssetDB = new AssetsData();
        }
        public Dropdownlist GetDropdownList()
        {

           return AssetDB.GetDropdownList();
        }

        public List<AssetIdList> GetAssetIdList()
        {

            return AssetDB.GetAssetIdList();
        }


        public void CreateAssetRegister(AssetsObject Obj)
        {

            AssetDB.CreateAssetRegister(Obj);
        }
        public List<AssetsObject> GetAssetRegister()
        {
            return AssetDB.GetAssetRegister();
        }
        public void DeleteAssetRegister(int assetId)
        {

            AssetDB.DeleteAssetRegister(assetId);
        }
        public void UpdateAssetRegister(int assetId, AssetsObject model)
        {

            AssetDB.UpdateAssetRegister(assetId, model);
        }
        public DashboardObject Dashboard()
        {

            return AssetDB.Dashboard();
        }
        public void AssetToolRegister(ToolObject Obj)
        {

            AssetDB.AssetToolRegister(Obj);
        }

        public List<UserItems> GetUserRegister()
        {
            return AssetDB.GetUserRegister();
        }

        //    GetStaffAssets
        public List<AssetsObject> GetStaffAssets(int membershipId,string role)
        {
            return AssetDB.GetStaffAssets(membershipId, role);
        }

        public List<AssetsObject> GetAssetFilter(SearchObject search)
        {
            return AssetDB.GetAssetFilter(search);
        }
        public void UpdateUserStatus(int assetId, bool isLockedOut)
        {

            AssetDB.UpdateUserStatus(assetId, isLockedOut);
        }
        public void RegisterUserActivity(UserActivityObject User)
        {

            AssetDB.RegisterUserActivity(User);
        }
       
        public List<UserItems> GetUserFilter(string userName)
        {
            return AssetDB.GetUserFilter(userName);
        }

        public List<DownloadObject> DownloadAssets()
        {
            return AssetDB.DownloadAssets();
        }

    }
}
