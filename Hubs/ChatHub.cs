using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Eyouth1.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendNotification(string name,string message)
        {
            await Clients.All.SendAsync("receiveMsg", name, message);
        }
    }
}
