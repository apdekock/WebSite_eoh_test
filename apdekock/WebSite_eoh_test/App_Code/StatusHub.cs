using Microsoft.AspNet.SignalR;

public class StatusHub : Hub
{
    public void StatusUpdate(string message)
    {
        Clients.All.broadcastMessage(message);
    }        
}
