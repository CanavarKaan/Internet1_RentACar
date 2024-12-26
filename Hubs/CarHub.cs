using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR_CarCount.Hubs
{
    public class CarHub : Hub
    {
        public async Task SendCarCount(int carCount)
        {
            await Clients.All.SendAsync("ReceiveCarCount", carCount);
        }
    }
}