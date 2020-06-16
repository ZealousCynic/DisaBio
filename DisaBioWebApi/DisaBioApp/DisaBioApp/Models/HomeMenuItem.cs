using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioApp.Models
{
    public enum MenuItemType
    {
        Settings,
        Cinema,
        Movies,
        Orders
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string Source { get; set; }
    }
}
