using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
namespace ProductsAPI.Controllers
{
    // localhost:5000/api/Products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product>? _products;

    public ProductsController()
    {
        _products = new List<Product>
        {
            new() { ProductId = 1, ProductName = "IPhone15", Price = 6000, IsActive = true },
            new() { ProductId = 2, ProductName = "IPhone16", Price = 7000, IsActive = true },
            new() { ProductId = 3, ProductName = "IPhone17", Price = 8000, IsActive = true },
            new() { ProductId = 4, ProductName = "IPhone18", Price = 9000, IsActive = true },
        };
    }

        // localhost:5000/api/Products =>GET
        [HttpGet]
        public IActionResult GetProducts()
        {
            if(_products == null)
            {
               return NotFound();
            } 
            return Ok(_products);                           //_products ?? new List<Product>();  return _products== null ? new List<Product>(): _products;
        }

        // localhost:5000/api/Products/1  ==>eğer talep gönderilen rotada id bilgisi de mevcutsa bu metoda gelir değilse üstteki get metoduna gider
        [HttpGet("{id}")]
        public IActionResult GetProduct (int? id) // return _products?.FirstOrDefault(i => i.ProductId ==id) ?? new Product();  eğer null değer dönerse new product ile yeni bir product listesi (boş değer) döndürür  aksi halde id ile eşleşen product nesnesini gönderir

        {
            if(id==null)
            { 
                return NotFound();
            }

            var p = _products?.FirstOrDefault(i =>i.ProductId==id);

            if(p == null)
            {
                 return NotFound();
            }
            return Ok(p);  // 200 durum kodu ile birlikte bulunan nesneyi gönderir gönderir
        }
    }
}