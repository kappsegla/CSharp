using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApp.Exercise4.Helpers;
using ConsoleApp.Exercise4.Models;

namespace ConsoleApp.Exercise4.Repositories
{
    public class FileShopRepository : IShopRepository
    {
        private readonly List<Shop> _shops;
        
        public FileShopRepository()
        {
            var path = Path.Combine(FileHelper.GetUserHomePath(), ".DemoApp2020", "shops.json");
            _shops = File.Exists(path) ? FileHelper.LoadFromJson<Shop>(path).ToList() : new List<Shop>();
        }
         
        public IEnumerable<Shop> GetAll()
        {
            return _shops;
        }

        public Shop GetById(string id)
        {
            return _shops.FirstOrDefault(s => s.Id == id);
        }

        public void Delete(Shop shop)
        {
            _shops.Remove(shop);
            Save();
        }

        public void Insert(Shop shop)
        {
            _shops.Add(shop);
            Save();
        }

        public void Save()
        {
            var path = Path.Combine(FileHelper.GetUserHomePath(), ".DemoApp2020", "shops.json");
            FileHelper.SaveToJson(path, _shops);
        }
    }
}