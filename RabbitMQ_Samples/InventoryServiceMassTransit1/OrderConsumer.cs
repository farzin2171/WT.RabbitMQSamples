using MassTransit;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryServiceMassTransit1
{
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            await Console.Out.WriteAsync(context.Message.Name);
        }
    }
}
