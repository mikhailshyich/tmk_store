using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TMKStore.Data;
using TMKStore.DTOs;
using TMKStore.Models;
using TMKStore.Responses;
using TMKStore.States;
using static TMKStore.Responses.CustomResponses;

namespace TMKStore.Repos
{
    public class Account : IAccount
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration config;

        public Account(AppDbContext appDbContext, IConfiguration config)
        {
            this.appDbContext = appDbContext;
            this.config = config;
        }

        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {

            var findUser = await GetUser(model.Email); //поиск пользователя в БД
            if (findUser == null) return new LoginResponse(false, "Пользователь не зарегистрирован.");

            if(!BCrypt.Net.BCrypt.Verify(model.Password, findUser.Password)) //проверка хешированного пароля с введённым пользователем
                return new LoginResponse(false, "Почта или пароль введены неверно.");

            string jwtToken = GenerateToken(findUser);

            return new LoginResponse(true, "Авторизация прошла успешно.", jwtToken);
        }

        public LoginResponse RefreshToken(UserSession userSession)
        {
            CustomUserClaims customUserClaims = DecryptJWTService.DecryptToken(userSession.JWTToken);
            if (customUserClaims is null) return new LoginResponse(false, "Неверный токен авторизации");
            string newToken = GenerateToken(new ApplicationUser()
            { Name = customUserClaims.Name, Email = customUserClaims.Email });
            return new LoginResponse(true, "Новый токен авторизации", newToken);
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="model">Объект класса RegisterDTO</param>
        /// <returns></returns>
        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var findUser = await GetUser(model.Email); //поиск пользователя в БД
            if (findUser != null) return new RegistrationResponse(false, "Пользователь уже зарегистрирован.");
            var cart = new Cart();
            var newUser = new ApplicationUser()
            {
                Name = model.Name,
                Email = model.Email,
                Role = model.Role,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password), //хэшируем пароль
            };

            //Добавление нового пользователя в базу
            appDbContext.Users.Add(newUser);

            await appDbContext.SaveChangesAsync(); //сохраняем пользователя в БД
            return new RegistrationResponse(true, "Успешная регистрация.");

        }


        /// <summary>
        /// Генерация JWT токена
        /// </summary>
        /// <param name="user">Объект класса ApplicationUser</param>
        /// <returns></returns>
        private string GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"]!,
                audience: config["JWT:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        /// <summary>
        /// Поиск пользователя в БД
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetUser(string email)
            => await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    }
}
