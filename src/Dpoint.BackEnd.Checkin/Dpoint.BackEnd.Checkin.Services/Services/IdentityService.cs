using Dpoint.BackEnd.Checkin.Common.Commons;
using Dpoint.BackEnd.Checkin.Common.Constants;
using Dpoint.BackEnd.Checkin.Domain.Contexts;
using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Dpoint.BackEnd.Checkin.Services.Models.Dtos;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;
using Dpoint.BackEnd.Checkin.Services.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace Dpoint.BackEnd.Checkin.Services.Services
{
    public class IdentityService : BaseService, IIdentityService
    {

        private IApplicationDbContext _context;
        private readonly AppSettings _appSettingsAccessor;

        public IdentityService(IApplicationDbContext context, IOptions<AppSettings> appSettingsAccessor)
        {
            _context = context;
            _appSettingsAccessor = appSettingsAccessor.Value;

        }

        public async Task<AppActionResultData<UserLoginDto>> GetUserDataAsync(UserLoginRequest request)
        {
            var result = new AppActionResultData<UserLoginDto>();
            var dtoUserLoginInfo = new UserLoginDto();

            string GoogleUrl = _appSettingsAccessor.GoogleSettings.Googleapis;
            string endpoint = _appSettingsAccessor.GoogleSettings.Parameters;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(GoogleUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(request.TokenType, request.AccessToken);

            string urlParameters = string.Format(endpoint, request.AccessToken);


            // Get data response
            var response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {

                var dataObjects = response.Content
                               .ReadAsAsync<UserLoginGoogleInfoDto>().Result;
                if (dataObjects.Hd != HostingDomainConstant.HDEmail)
                {
                    return BuildMultilingualError(result, MessageResponseConstant.ERROR_INVALID_EMAIL);
                }

                try
                {
                    var userInfos = await _context.UserInfos.Where(x => x.UserCalledName.Equals(dataObjects.Email)).FirstOrDefaultAsync();
                    if (userInfos == null) return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_USER_NOT_FOUND);
                    UserInfoDto dtoUserInfo = new UserInfoDto
                    {
                        Email = userInfos.UserCalledName,
                        FullName = userInfos.UserFullName,
                        UserId = userInfos.UserEnrollNumber,
                        DeptId = userInfos.UserIDD
                    };

                    var token = GenerateJwtToken(dtoUserInfo);

                    dtoUserLoginInfo.Auth = token;
                    dtoUserLoginInfo.Data = dtoUserInfo;

                }
                catch (Exception ex)
                {
                    return BuildMultilingualError(result, MessageResponseConstant.ERROR_LOGIN_FAILED + "");
                }
            }
            else
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_LOGIN_FAILED);
            }

            return BuildMultilingualResult(result, dtoUserLoginInfo, MessageResponseConstant.SUCCESSFULLY);
        }



        #region Private Method
        private DtoToken GenerateJwtToken(UserInfoDto userInfoDto)
        {
            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, userInfoDto.UserId.ToString()),
               new Claim(ClaimTypes.Name, userInfoDto.FullName),
               new Claim(ClaimTypes.Email, userInfoDto.Email),
               new Claim("DeptId", userInfoDto.DeptId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettingsAccessor.TokenSettings.ClientSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_appSettingsAccessor.TokenSettings.ClientId,
                _appSettingsAccessor.TokenSettings.ClientId,
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);


            var dtoToken = new DtoToken();
            dtoToken.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            dtoToken.ExpiresAccess = DateTime.UtcNow.AddDays(1);

            return dtoToken;
        }
        #endregion Private Method
    }
}
