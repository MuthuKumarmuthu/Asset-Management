using BusinessLogic;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace AssetManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
 
    public class AssetManagementController : ControllerBase
    {
      
        //public AssetLogic AssetLog;
        //public IHttpContextAccessor _httpContextAccessor;
        //public AssetManagementController()
        //{

        //    AssetLog = new AssetLogic();
        //    _httpContextAccessor = new HttpContextAccessor();
        //}
        public AssetLogic AssetLog;
      
        public AssetManagementController( )
        {
            AssetLog = new AssetLogic();
       
        }


      
        [HttpGet]
        public ActionResult GetDropdownList()
        {
            var mv = AssetLog.GetDropdownList();

            return Ok(mv);
        }

      
        [HttpGet]
        public List<AssetIdList> GetAssetIdList()
        {

            var mv = AssetLog.GetAssetIdList();

            return mv;
        }

     
        [HttpPost]
        public ActionResult CreateAssetRegister(AssetsObject Asset)
        {
            var date = DateTime.Now;
            Asset.createdBy = User.Identity.Name;
            AssetLog.CreateAssetRegister(Asset);
            UserActivity(date);
            return Ok("");
        }

    
        [HttpPost]
        public ActionResult DeleteAssetRegister(int assetId)
        {
            var date = DateTime.Now;
            AssetLog.DeleteAssetRegister(assetId);
            UserActivity(date);
            return Ok(assetId);
        }

      
        [HttpPost]
        public ActionResult UpdateAssetRegister(int assetId, AssetsObject model)
        {

            model.updatedBy = User.Identity.Name;
            //var userName = User.Identity.Name;
            //UserActivityObject Users = new UserActivityObject();
            //Users.requestMethod = HttpContext.Request.Method;
            //Users.requestUrl = HttpContext.Request.Path;
            //Users.membershipId= HttpContext.Session.GetInt32("MembershipId") ?? 0;
            //Users.userName = HttpContext.Session.GetString("UserName");

            //Users.ipAddress = _httpContextAccessor.HttpContext!.Connection.RemoteIpAddress?.ToString();
            //Users.host= _httpContextAccessor.HttpContext.Request.Host.Port.ToString();

            //AssetLog.RegisterUserActivity (Users);
            var date = DateTime.Now;
            AssetLog.UpdateAssetRegister(assetId, model);
            //AssetLog.RegisterUserActivityLogOut(Users);
            UserActivity(date);
            return Ok("");
        }

       
        [HttpGet]
     
        public List<AssetsObject> GetAssetRegister()
        {
            var date = DateTime.Now;
        
            var MV = AssetLog.GetAssetRegister();
            UserActivity(date);
            return MV;

        }

      
        [HttpGet]
        public ActionResult Dashboard()
        {
            var date = DateTime.Now;
            var mv = AssetLog.Dashboard();
            UserActivity(date);
            return Ok(mv);
        }

      
        [HttpPost]
        public ActionResult AssetToolRegister(ToolObject Tool)
        {
            var date = DateTime.Now;
            AssetLog.AssetToolRegister(Tool);
            //var result = string.Empty;
            //result = "Data Created";
            UserActivity(date);
            return Ok("");
        }

      
        [HttpGet]
        public List<UserItems> GetUserRegister()
        {
            var date = DateTime.Now;
            var MV = AssetLog.GetUserRegister();
            UserActivity(date);
            return MV;

        }
        //    GetStaffAssets
     
        [HttpGet]
        public List<AssetsObject> GetStaffAssets(int membershipId, string role)
        {
            var date = DateTime.Now;
            var MV = AssetLog.GetStaffAssets(membershipId, role);
            UserActivity(date);
            return MV;

        }

     
        [HttpGet]
        public List<AssetsObject> GetAssetFilter([FromQuery] SearchObject search)
        {
            var date = DateTime.Now;
            var result = AssetLog.GetAssetFilter(search);
            UserActivity(date);
            return result;



        }
     
        [HttpPost]
        public ActionResult UpdateUserStatus(int membershipId, bool isLockedOut)
        {
            var date = DateTime.Now;
            AssetLog.UpdateUserStatus(membershipId, isLockedOut);
            UserActivity(date);
            return Ok("");
        }


      
        [HttpGet]
        public List<UserItems> GetUserFilter(string userName)
        {


            var date = DateTime.Now;
            //WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();

            //// Check if the user is authenticated
            //bool isAuthenticated = currentIdentity != null && currentIdentity.IsAuthenticated;
            //Console.WriteLine("Is Authenticated: " + isAuthenticated);
            //string username = currentIdentity != null ? currentIdentity.Name : "Unknown";
            //Console.WriteLine("Username: " + username);


            //Console.WriteLine("Username: " + username);
   
            var result = AssetLog.GetUserFilter(userName);
            UserActivity(date);
            return result;



        }
       
        [HttpGet]
        public List<DownloadObject> DownloadAssets()
        {
            var date = DateTime.Now;
            var MV = AssetLog.DownloadAssets();
            UserActivity(date);
            return MV;

        }

        [NonAction]
        public void UserActivity(DateTime Dat)
        {

           
            UserActivityObject Users = new UserActivityObject();

            Users.LoggedinTime = Dat;
            Users.userName = User.Identity.Name;
            var identit = HttpContext.User.Identity as ClaimsIdentity;

            var membershipIdClaim = identit.FindFirst(ClaimTypes.Sid);

            if (membershipIdClaim != null)
            {
                Users.membershipId = Convert.ToInt32(membershipIdClaim.Value);
            }
            Users.requestMethod = HttpContext.Request.Method;
            Users.requestUrl = HttpContext.Request.Path;

            //Users.userName = HttpContext.Session.GetString("UserName");

            Users.ipAddress = HttpContext!.Connection.RemoteIpAddress?.ToString();
            Users.host = HttpContext.Request.Host.Port.ToString();

            AssetLog.RegisterUserActivity(Users);

        }
       


    }
}
