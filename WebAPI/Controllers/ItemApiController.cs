using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repository;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        IInventoryRepository _invRepo;
        public ItemApiController(IInventoryRepository _invRepo)
        {
            this._invRepo = _invRepo;
        }

        
        [HttpGet]
        [Route("api/GetAllItemInventory")]
        public object GetAllItemInventory(int page)
        {
            try
            {
                var data = _invRepo.GetAllList(page);
                if (data!=null)
                {
                    return data;
                }
                else
                {
                    return "No record found";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        [HttpPost]
        [Route("api/CreateUpdateItemInventory")]
        public object CreateUpdateItemInventory(ItemInventory obj)
        {
            try
            {
                var data = _invRepo.AddItem(obj);
                if (data != null)
                {
                    return "Record Updated";
                }
                else
                {
                    return "Record Created";
                }
                ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("api/DeleteItemInventory")]
        public object DeleteItemInventory(int item_id)
        {
            try
            {
                var data = _invRepo.ItemDelete(item_id);
                return "Record Deleted";
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
