using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IutInfo.ProgReseau.SignalR.WebUi.Hubs
{
    public sealed class MessengerHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}