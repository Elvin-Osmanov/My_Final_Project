using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook
{
    public class NotificationHub:Hub
    {
       private readonly UserManager<AppUser> _userManager;

        public NotificationHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public override Task OnConnectedAsync()
        {
            AppUser user = null;

            if (Context.User.Identity.IsAuthenticated)
            {
                user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;

                if (user != null)
                {
                    user.ConnectionId = Context.ConnectionId;
                    user.IsConnected = true;

                    var result = _userManager.UpdateAsync(user).Result;
                }
            }
            return base.OnConnectedAsync();
        }


    }


}

