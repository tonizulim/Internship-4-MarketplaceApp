﻿using System;

namespace Internship_4_MarketplaceApp.Data.Entities.Models.Users
{
    public class Users
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }

        public Users(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
    }
    }
