﻿namespace ECommerce.API.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock { get; set; }

    }
}
