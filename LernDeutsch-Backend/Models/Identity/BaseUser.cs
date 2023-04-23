﻿using Microsoft.AspNetCore.Identity;

namespace LernDeutsch_Backend.Models.Identity
{
    public class BaseUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}