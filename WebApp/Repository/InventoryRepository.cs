using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Models.Context;

namespace WebApp.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        public ApplicationDBContext _db;
        public InventoryRepository(ApplicationDBContext _db)
        {
            this._db = _db;
        }
        public async Task<int> AddItem(ItemInventory obj)
        {
            try
            {
                if (obj.item_id == 0)
                {
                    _db.tbl_ItemInventory.Add(obj);
                    await _db.SaveChangesAsync();
                    return 0;
                }
                else
                {
                    _db.Entry(obj).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return 0;
            }
        }

        public PagingList<ItemInventory> GetAllList(int page)
        {
            List<ItemInventory> items = new List<ItemInventory>();
            try
            {
                var data = from a in _db.tbl_ItemInventory
                           join b in _db.tbl_Category
                           on a.cat_id equals b.cat_id into ItemInv
                           from c in ItemInv.DefaultIfEmpty()
                           select new ItemInventory
                           {
                               item_id = a.item_id,
                               cat_id = a.cat_id,
                               item_name = a.item_name,
                               quantity = a.quantity,
                               max_price = a.max_price,
                               min_price = a.min_price,
                               category_name = c == null ? "" : c.category_name,

                           };


                var query = data.AsNoTracking().OrderBy(a => a.item_id).ToList();
                var model = PagingList.Create(query, 2, page);
                return model;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return null;
            }
        }

        public async Task<int> ItemDelete(int item_id)
        {
            try
            {
                var data = await _db.tbl_ItemInventory.FindAsync(item_id);
                if (data != null)
                {
                    _db.tbl_ItemInventory.Remove(data);
                    await _db.SaveChangesAsync();
                }
                return item_id;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                throw;
            }
        }

        public List<Category> LoadData()
        {
            try
            {
                List<Category> lstCat = new List<Category>();
                lstCat = _db.tbl_Category.ToList();
                lstCat.Insert(0, new Category { cat_id = 0, category_name = "Please select" });
                return lstCat;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                throw;
            }
        }
    }
}
