using Microsoft.IdentityModel.Tokens;
using PalmGroupRESTAPIServer.DatabaseObjects;
using PalmGroupRESTAPIServer.DatabaseRepositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace PalmGroupRESTAPIServer.Tools
{
    public static class TokenTools

    {
        public static TokensRepository _tokenRepository = new TokensRepository();
        public static Token CreateToken(User u, string deviceName)
        {          
            string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));           
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);
           var payload = new JwtPayload
           {
               { "Name",u.Name},
               {"Surname",u.Surname},
               { "Email",u.Email},
               { "DeviceName",deviceName},
               { "CreationDateTime",System.DateTime.Now}
           };
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();           
            var tokenString = handler.WriteToken(secToken);          
            Token t = new Token();
            t.TokenString = tokenString;
            t.ObjectUser = u;
            t.ValidTo = System.DateTime.Now.AddHours(8);
            t.DeviceName = deviceName;
            _tokenRepository.Add(t);
            _tokenRepository.Save();
            return t;
        }
        private static bool IsTokenExpired(Token t)
        {
            if (t.ValidTo < System.DateTime.Now)
                return true;
            return false;
                   
        }
        public static Token RefreshToken(string Token)
        {
            Token t = _tokenRepository.FindBy(x => x.TokenString == Token &&x.IsDeleted==false&&x.ValidTo>System.DateTime.Now).FirstOrDefault();
            if (!IsTokenExpired(t))
            {
                t.ValidTo=System.DateTime.Now.AddHours(8);
                _tokenRepository.Edit(t);
                _tokenRepository.Save();
                return t;
            }
         return CreateToken(t.ObjectUser, t.DeviceName);       
        }
        public static bool Authentication(string Token, string Device)
        {
            if (_tokenRepository.FindBy(x => x.IsDeleted == false && x.ObjectUser.IsDeleted == false && x.TokenString == Token && x.DeviceName == Device&&x.ValidTo>System.DateTime.Now).FirstOrDefault() == null)
            {
                return false;
            }
            else
            {
                RefreshToken(Token);
                return true;
            }
        }
        public static User getUserFromToken(string Token)
        {
            return _tokenRepository.FindBy(x => x.TokenString == Token&&x.ValidTo>System.DateTime.Now&&x.IsDeleted==false).FirstOrDefault().ObjectUser;            
        }
        public static Token getTokenObjectFromString(string Token)
        {
            return _tokenRepository.FindBy(x => x.TokenString == Token && x.IsDeleted == false).FirstOrDefault();
        }
    }
}