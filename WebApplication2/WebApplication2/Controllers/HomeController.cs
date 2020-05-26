using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
       

        IRepository<Good> db;
        private readonly IWebHostEnvironment environment;
        public HomeController(IRepository<Good> db, IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await db.GetAllAsync());
        //}


        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewBag.user = User.Identity.Name;
            return View(await db.GetAllAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GoodViewModel goodWM)
        {
            if (goodWM.UploadedFile != null)
            {
                string path = "/Files" + goodWM.UploadedFile.FileName;
                using (FileStream file = new FileStream(environment.WebRootPath + path, FileMode.Create))
                {
                    await goodWM.UploadedFile.CopyToAsync(file);
                }
                Good good = new Good();
                good = goodWM.Good;
                good.FileName = goodWM.UploadedFile.FileName;
                good.Path = path;
                await db.AddAsync(good);
            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await db.GetByIdAsync(id);
            if(item!=null)
            {
                return View(item);
            }

            return RedirectToAction("Index");
        }

       [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var good = await db.GetByIdAsync(id);


            if (good != null)
            {

                GoodViewModel gv = new GoodViewModel() { Good = good };
                return View(gv);

            }

            //if (goodWM.UploadedFile != null)
            //{

                //string path = "/Files" + good.FileName;
                //using (FileStream file = new FileStream(environment.WebRootPath + path, FileMode.Create))
                //{
                //    await good.CopyToAsync(file);
                //}
                //Good good = new Good();
                //good = goodWM.Good;
                //good.FileName = goodWM.UploadedFile.FileName;
                //good.Path = path;
                //await db.AddAsync(good);

                return RedirectToAction("Index");
            //}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GoodViewModel goodWM)
        {
            if (goodWM.UploadedFile != null)
            {
                string path = "/Files" + goodWM.UploadedFile.FileName;
                using (FileStream file = new FileStream(environment.WebRootPath + path, FileMode.Create))
                {
                    await goodWM.UploadedFile.CopyToAsync(file);
                }

                goodWM.Good.FileName = goodWM.UploadedFile.FileName;
                goodWM.Good.Path = path;
            }


            if (!(await db.UpdateAsync(goodWM.Good)))
                    return View();

            return RedirectToAction("Index", await db.GetAllAsync());
        }

        

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Good g = await db.GetByIdAsync(id);

            if(g!=null)
            {
                return View(g);
            }

            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete2(int id)
        {
            await db.DeleteAsync(id);
            var goods = await db.GetAllAsync();

            return RedirectToAction("Index", goods);
        }





        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
