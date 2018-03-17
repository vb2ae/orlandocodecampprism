using System;
using System.Threading.Tasks;

namespace OrlandoDemo.Services
{
    public interface IGetLaunches
    {
        Task<Models.Welcome> GetLaunches();
    }
}
