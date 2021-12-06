using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using T1Driver.Data;
using T1Driver.Models;

namespace T1Driver.Authentication
{
    public class UserAuthenticationStateProvider:AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IUserServices client;
        
        private Driver cachedUser;

        public UserAuthenticationStateProvider(IJSRuntime jsRuntime, IUserServices client)
        {
            this.jsRuntime = jsRuntime;
            this.client = client;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    Driver tmp = JsonSerializer.Deserialize<Driver>(userAsJson);
                    ValidateLogin(tmp.username, tmp.password);
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public void ValidateLogin(string username, string password)
        {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                client.Connect();
                Driver driver = client.Login(username, password);
                identity = SetupClaimsForUser(driver);
                string serialisedData = JsonSerializer.Serialize(driver);
                jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = driver;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public Driver GetUser()
        {
            return cachedUser;
        }

        public Driver EditUser(Driver driver)
        {
            cachedUser = client.EditDriver(driver);
            return cachedUser;
        }

        public void Logout()
        {
            client.Logout(cachedUser);
            cachedUser = null;
            var driver = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(driver)));
        }
            
        private ClaimsIdentity SetupClaimsForUser(Driver user) {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.username));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        
    }
}