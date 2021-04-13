using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repository
{
    public interface IInventoryRepository
    {
        PagingList<ItemInventory>  GetAllList(int page);
        Task<int> ItemDelete(int id);
        Task<int> AddItem(ItemInventory obj);
        List<Category> LoadData();


    }
}
