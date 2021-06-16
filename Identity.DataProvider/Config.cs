using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.DataProvider
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim("name", "Bob"),
                        new Claim("website", "https://bob.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "naveen.papisetty",
                    Password = "12345",
                    Claims = new []
                    {
                        new Claim("name", "Naveen Papisetty"),
                        new Claim("website", "https://naveen.papisetty.com")
                    }
                },
            };
        }
    }
}
