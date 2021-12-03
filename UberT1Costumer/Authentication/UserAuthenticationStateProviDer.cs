using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using UberT1Costumer.Data;
using UberT1Costumer.Data;
using UberT1Costumer.Models;
using UberT1Costumer.Services;

namespace UberT1Costumer.Authentication
{
    public class UserAuthenticationStateProvider:AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IUserServices client;
        
        private Costumer cachedUser;

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
                    Costumer tmp = JsonSerializer.Deserialize<Costumer>(userAsJson);
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
                Costumer costumer = client.Login(username, password);
                identity = SetupClaimsForUser(costumer);
                string serialisedData = JsonSerializer.Serialize(costumer);
                jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = costumer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }
        
        public Costumer GetUser()
        {
            return cachedUser;
        }

        public void Logout()
        {
            client.Logout(cachedUser);
            cachedUser = null;
            var costumer = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(costumer)));
        }
        
            
        private ClaimsIdentity SetupClaimsForUser(Costumer user) {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.username));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}