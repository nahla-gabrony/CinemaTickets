﻿using System.Collections.Generic;
using System.Security.Claims;

namespace CinemaTickets.Models
{
    public static class ClaimStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Role","Create Role"),
            new Claim("Delete Role","Delete Role"),
            new Claim("Edit Role","Edit Role")
        };
    }
}
