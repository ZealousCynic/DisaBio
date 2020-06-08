using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Settings,
        Search_Cinema,
        Search_Movie,
        Show_Orders
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
