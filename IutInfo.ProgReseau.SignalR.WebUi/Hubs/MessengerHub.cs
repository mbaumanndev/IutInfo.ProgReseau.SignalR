using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IutInfo.ProgReseau.SignalR.WebUi.Hubs
{
    public sealed class MessengerHub : Hub // On déclare notre Hub
    {
        // Nous allons écouter les événements "SendMessage" envoyés par les clients
        public async Task SendMessage(string user, string message)
        {
            // On envoie de façon asynchrone un événement "ReceiveMessage" aux différents clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}