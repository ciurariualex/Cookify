// <copyright file="AuthorisationPolicies.cs" company="Novia">
// Copyright (c) Novia. All rights reserved.
// </copyright>

namespace Web
{
    using Microsoft.AspNetCore.Authorization;

    public static class AuthorisationPolicies
    {
        
        public const string UserRegister = "Users.Register";

        public static void AddApplicationAuthorisationPolicies(this AuthorizationOptions policies)
        {
            const string userAdminRole = "Admin";

            policies.AddPolicy(UserRegister, policy => policy.RequireRole(userAdminRole));
        }
    }
}
