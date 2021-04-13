using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Context;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using ReflectionIT.Mvc.Paging;
using WebApp.Repository;
namespace WebApp.Controllers
{
    public class ItemController : Controller
    {
        IInventoryRepository _invRepo;
        public ItemController(IInventoryRepository _invRepo)
        {
            this._invRepo = _invRepo;
        }
        public IActionResult Index(int page = 1)
        {
           
            try
            {
               var data =  _invRepo.GetAllList(page);
                return View(data);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
        }
       
        public async Task<IActionResult> ItemDelete(int item_id)
        {
            try
            {
                await _invRepo.ItemDelete(item_id);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
        }

        public IActionResult Create(ItemInventory obj)
        {
            var lstCat = _invRepo.LoadData();
            ViewBag.lst = lstCat;
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ItemInventory obj)
        {
            try
            {
                var data = await _invRepo.AddItem(obj);
               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
        }
    }
}
