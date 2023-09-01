using BusinessLogic;
using BusinessObject;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace AssetManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
     
     
        public SignupLogic SignLog;
        public AssetLogic AssetLog;
        
        public LoginController()
        {
            SignLog = new SignupLogic();
         
            AssetLog = new AssetLogic();
           
        }

        //   public List<AssetRegister> GetAssetRegister()
      
        [HttpGet]
        public List<RoleList> RoleDropdownList()
        {
            var mv = SignLog.RoleDropdownList();
            return mv;
        }

     
        [HttpGet]
        public List<AddressTypeList> AddressTypeDropdownList()
        {
            var mv = SignLog.AddressTypeDropdownList();
            return mv;
        }

      
        [HttpGet]
        public List<CountryList> CountryDropdownList()
        {
            var mv = SignLog.CountryDropdownList();
            return mv;
        }
       
        [HttpGet]
        public List<RegionsList> RegionDropdownList(int countryId)
        {
            var mv = SignLog.RegionDropdownList(countryId);
            return mv;
        }
      
        [HttpGet]
        public List<CityList> CityDropdownList(int regionId)
        {
            var mv = SignLog.CityDropdownList( regionId);
            return mv;
        }

     
        [HttpPost]
        public ActionResult AccessSignUp(Signupdata Obj)
        {
            var date = DateTime.Now;
            Obj.createdBy = User.Identity.Name;
            var Validate = SignLog.ValidateUser(Obj);
            if (Validate == "User Name Exists")
            {
                return Ok(Validate);

            }
            var getroleId = SignLog.GetRoleId(Obj.membershipTypeCode);
            Obj.roleId = getroleId;
            var mv = SignLog.RegisterUser(Obj);
            UserActivity(date);


            return Ok(mv);
        }


       
       
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AccessLogin(Logindata Log)
        {

            var date = DateTime.Now;
            var mv = SignLog.AccessLogin(Log);
          
            if (mv != null)
            {
                if (mv.membershipId != 0)
                {
                    var jwtTokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("thisisauthentication");
                    var identity = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Role,mv.role),
                new Claim(ClaimTypes.Name,mv.userName),
                new Claim(ClaimTypes.Sid, mv.membershipId.ToString())

                    });
                    var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = identity,
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = credentials

                    };

                    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                    mv.token = jwtTokenHandler.WriteToken(token);
                    UserActivityLog(date, mv);
                }
            }

          
 
            return Ok(mv);

          
        }


       
        [HttpPost]
        public ActionResult AccessVendorSignUp(Vendordata Obj)
        {
            var date = DateTime.Now;
            Obj.createdBy = User.Identity.Name;
          
            var mv = SignLog.AccessVendorSignUp(Obj);
            UserActivity(date);
            return Ok(mv);
          
        }



        [HttpPost]
       public void LogOutDetails(int membershipId)
        {
            var date = DateTime.Now;
            SignLog.LogOutDetails(membershipId);
            UserActivity(date);
        }


        [NonAction]
        public void UserActivity(DateTime date)
        {
          

            UserActivityObject Users = new UserActivityObject();

            Users.LoggedinTime = date;
            Users.userName = User.Identity.Name;
            var identit = HttpContext.User.Identity as ClaimsIdentity;

            var membershipIdClaim = identit.FindFirst(ClaimTypes.Sid);
            Users.membershipId = Convert.ToInt32(membershipIdClaim.Value);

            Users.requestMethod = HttpContext.Request.Method;
            Users.requestUrl = HttpContext.Request.Path;
          
         
            Users.ipAddress = HttpContext!.Connection.RemoteIpAddress?.ToString();
            Users.host = HttpContext.Request.Host.Port.ToString();

            AssetLog.RegisterUserActivity(Users);

        }

        [NonAction]
        public void UserActivityLog(DateTime date,Logindata Log)
        {

            UserActivityObject Users = new UserActivityObject();
            Users.LoggedinTime = date;
            Users.userName = Log.userName;
            Users.membershipId=Log.membershipId;
            Users.requestMethod = HttpContext.Request.Method;
            Users.requestUrl = HttpContext.Request.Path;
            Users.ipAddress = HttpContext!.Connection.RemoteIpAddress?.ToString();
            Users.host = HttpContext.Request.Host.Port.ToString();

            AssetLog.RegisterUserActivity(Users);

        }



    }


}
