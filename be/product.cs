using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace be
{
    public class product
    {
        [Key]
        public int productId { get; set; }
        public int typeId { get; set; }
        public type type { get; set; }
        public orderId orderId { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string vol { get; set; }
        public float price { get; set; }
        public string pic { get; set; }
        public string descript { get; set; }
        public List<gallery> galley { get; set; }
        public List<Order_product> Order_Products { get; set; }
    }
    public class type
    {
        public int typeId { get; set; }
        public string title { get; set; }
        public List<product> products { get; set; }
    }
    public class gallery
    {
        [Key]
        public int galleryId { get; set; }
        public int productId { get; set; }
        public string picname { get; set; }
        public product product { get; set; }
    }
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int productId { get; set; }
        public string userId { get; set; }
        public UserApp user { get; set; }
        public float totalPrice { get; set; }
        public List<Order_product> Order_Products { get; set; }
    }
    public class Order_product
    {
        public int id { get; set; }
        public product product { get; set; }
        public int productId { get; set; }
        public Order Order { get; set; }
        public int oId { get; set; }
    }
    public class orderId
    {
        [Key]
        public int productId { get; set; }
        public int count { get; set; }
    }
}
