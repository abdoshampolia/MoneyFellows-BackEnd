﻿using MoneyFellows.Application.Contracts.Common;
using MoneyFellows.Core.Entities;

namespace MoneyFellows.Application.Contracts.Repository
{
    public interface IOrderRepository : IModifiableEntityRepository<Order>
    {
    }
}
