﻿namespace ProductManagement.Domain;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}