using PaganaSoft.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaganaSoft.ORM.ViewModel
{
    public class DefaultViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public DefaultViewModel()
        {
            Products = new List<Product>();
            Categories = new List<Category>();
            Initializer();
            //using (var db = new NrtwdModelFirstCtx())
            //{
            //    Products = db.Products.ToList();
            //    Categories = db.Categories.ToList();
            //}
        }

        private void Initializer()
        {
            using (var db = new NrtwdModelFirstCtx())
            {
                Products = db.Products.ToList();
                Categories = db.Categories.ToList();
            }
        }

    }
}
