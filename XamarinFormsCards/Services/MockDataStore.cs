using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XamarinFormsCards.Models;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsCards.Services.MockDataStore))]
namespace XamarinFormsCards.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            var description = "This is an item description for item";

            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item Title #1".ToUpper(), Description = description, PublishDate = currentDate, BoxColor = "#03a9f4" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item Title #2".ToUpper(), Description = description, PublishDate = currentDate, BoxColor = "#e91e63" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item Title #3".ToUpper(), Description = description, PublishDate = currentDate, BoxColor = "#673ab7" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item Title #4".ToUpper(), Description = description, PublishDate = currentDate, BoxColor = "#3f51b5" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Item Title #5".ToUpper(), Description = description, PublishDate = currentDate, BoxColor = "#f44336" },
            };

            foreach (var item in mockItems)
                items.Add(item);
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}