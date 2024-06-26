﻿using MediatR;
using MoneyFellows.Application.Helpers;

namespace MoneyFellows.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<Response<bool>>
    {
        public DeleteOrderCommand(Guid id)
        {
       
            Id = id;
        }
        public DeleteOrderCommand()
        {
        }
        public Guid Id { get; set; }
     
    }
}
