﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TMKStore.DTOs;

namespace TMKStore.States
{
    public static class DecryptJWTService
    {
        public static CustomUserClaims DecryptToken(string jwtToken)
        {
            try
            {
                if (string.IsNullOrEmpty(jwtToken)) return new CustomUserClaims();

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtToken);

                var name = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Name);
                var email = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Email);
                var role = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Role);
                return new CustomUserClaims(name!.Value, email!.Value, role!.Value);
            }
            catch
            {
                return null!;
            }
        }
    }
}
