﻿using Microsoft.AspNetCore.Identity;

namespace MovieDb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public string? ProfilePicture { get; set; }

    }
}
