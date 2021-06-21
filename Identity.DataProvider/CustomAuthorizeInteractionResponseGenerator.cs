using IdentityServer4.Models;
using IdentityServer4.ResponseHandling;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DataProvider
{
    public class CustomAuthorizeInteractionResponseGenerator : AuthorizeInteractionResponseGenerator
    {
        public CustomAuthorizeInteractionResponseGenerator(ISystemClock clock, 
            ILogger<AuthorizeInteractionResponseGenerator> logger,
            IConsentService consent, 
            IProfileService profile) : base(clock, logger, consent, profile)
        {
          
        }

        protected override async Task<InteractionResponse> ProcessLoginAsync(ValidatedAuthorizeRequest request)
        {
            var response =  await base.ProcessLoginAsync(request);
            return response;
        }

        public override async Task<InteractionResponse> ProcessInteractionAsync(ValidatedAuthorizeRequest request, ConsentResponse consent = null)
        {
            var response = await base.ProcessInteractionAsync(request, consent);
            return response;
        }
    }
}
