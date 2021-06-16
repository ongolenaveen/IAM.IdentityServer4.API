using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Inventory.Domain.DomainModels;
using Inventory.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inventory.Core
{
    public class LoginService : ILoginService
    {
        private ILoginDataProvider _loginDataProvider;
        private IUserDataProvider _userDataprovider;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IEventService _events;
        private IIdentityServerInteractionService _interaction;

        public LoginService(ILoginDataProvider loginDataProvider,
            IUserDataProvider userDataprovider,
            IEventService events,
            IHttpContextAccessor httpContextAccessor,
            IIdentityServerInteractionService interaction)
        {
            _loginDataProvider = loginDataProvider;
            _userDataprovider = userDataprovider;
            _httpContextAccessor = httpContextAccessor;
            _events = events;
            _interaction = interaction;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var context = await _interaction.GetAuthorizationContextAsync(request.ReturnUrl);
            if (context == null)
            {
                await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
                return null;
            }

            var response = await _loginDataProvider.Login(request);

            if (response == null)
            {
                await _interaction.DenyAuthorizationAsync(null, AuthorizationError.AccessDenied);
                return null;
            }
            var user = await _userDataprovider.GetUser(request.UserName);
            await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.SubjectId, user.UserName, clientId: "2"));
            AuthenticationProperties props = null;
            if ( request.RememberLogin)
            {
                props = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.Add(new TimeSpan(1, 0, 0)),
                    IssuedUtc = DateTimeOffset.UtcNow
                };
            };
            var isuser = new IdentityServerUser(user.SubjectId)
            {
                DisplayName = user.UserName,
                AdditionalClaims = new List<Claim> { 
                    new Claim("FirstName", user.FirstName), 
                    new Claim("LastName", user.LastName),
                    new Claim("PostCode", user.Address?.PostCode)}
            };
            await _httpContextAccessor.HttpContext.SignInAsync(isuser, props);
            return response;
        }
    }
}