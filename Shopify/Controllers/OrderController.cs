using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopify.Contexts;
using Shopify.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Controllers
{
    [ControllerName("Invoice")]
    public class OrderController : Controller
    {
        private readonly MyDbContext db;
        JRuntime model = new JRuntime();
        public IWebHostEnvironment Env { get; }

        public OrderController(MyDbContext _db, IWebHostEnvironment env, JRuntime j)
        {
            db = _db;
            Env = env;
            model = j;
        }
      
        public async Task<IActionResult> ViewOrder()
        {
            return View(await db.Orders.ToListAsync());
        }

        public IActionResult CreateOrder()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(OrderModel Order)
        {
            if (ModelState.IsValid)
            {
                string extention = Order.Picture.FileName.Substring(Order.Picture.FileName.LastIndexOf("."));

                try
                {

                    Order.ImageName = Order.Id + extention;
                    await db.Orders.AddAsync(Order);
                    await db.SaveChangesAsync();
                    var image = Image.Load(Order.Picture.OpenReadStream());
                    image.Mutate(x => x.Resize(300, 300));
                    image.Save($@"{Env.WebRootPath}\Images\Items\{Order.ImageName}");
                    image.Dispose();

                }
                catch (Exception)
                {

                    throw;
                }


            }

            return RedirectToAction("ViewOrder");

        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (Guid id)
        {
            try
            {

                db.Orders.Remove(await db.Orders.FindAsync(id));
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                //throw;
            }

            return RedirectToAction("ViewOrder");
        }

    }
}




