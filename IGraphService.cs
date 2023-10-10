using Microsoft.Graph.Models;

namespace SimpleGraphClient
{
    public interface IGraphService
    {
        Task<User?> Me();
    }
}
