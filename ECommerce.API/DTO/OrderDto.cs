﻿using ECommerce.API.Entity;

namespace ECommerce.API.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? AddresLine { get; set; }
        public string? CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public List<OrderItemDto> OrderItems { get; set; } = new();
        public decimal SubTotal { get; set; }
        public decimal DeliveryFree { get; set; }

    }
}
