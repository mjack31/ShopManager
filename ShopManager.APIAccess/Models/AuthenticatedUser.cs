﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.APIAccess
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public string Username { get; set; }
        public string Access_token { get; set; }
    }
}
