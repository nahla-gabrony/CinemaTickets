﻿using System.Collections.Generic;

namespace CinemaTickets.Data.ViewModels.User
{
    public class UserClaimsViewModel
    {
        public string UserId { get; set; }
        public List<UserClaim> Claims { get; set; } = new List<UserClaim>();

    }
}
