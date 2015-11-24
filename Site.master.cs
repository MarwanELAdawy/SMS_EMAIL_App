using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            MenuItems();
        }
    }

    protected void MenuItems()
    {
        MenuItemCollection menuItems = NavigationMenu.Items;
        List<MenuItem> toRemoveItems = new List<MenuItem>();
        foreach (MenuItem menuItem in menuItems)
        {
            if (CurrentUser.Role() == "Normal_User")
            {
                if (menuItem.Value == "Admin")
                {
                    toRemoveItems.Add(menuItem);
                }
                else if (menuItem.Value == "search" && !CurrentUser.CanSearch())
                {
                    toRemoveItems.Add(menuItem);
                }
            }
        }
        DeleteMenuItems(menuItems, toRemoveItems);
    }


    protected void DeleteMenuItems(MenuItemCollection menuItems, List<MenuItem> toRemoveItems)
    {
        foreach (MenuItem menuItemx in toRemoveItems)
        {
            menuItems.Remove(menuItemx);
        }
    }
}
