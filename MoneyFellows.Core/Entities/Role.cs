﻿using Microsoft.AspNetCore.Identity;

namespace MoneyFellows.Core.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public override Guid Id { get; set; }
    }
}
