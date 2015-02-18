using Orleans;
using System.Threading.Tasks;

namespace Test.Interfaces
{
    public interface IPerson : IGrain
    {
        Task<string> SayHello();
        Task SetName(string firstName, string lastName);
    }
}
