using System.Threading.Tasks;
using Orleans.Providers;
using Test.Interfaces;

namespace Test.Collection
{
    /// <summary>
    /// Orleans grain implementation class Grain1.
    /// </summary>
    [StorageProvider(ProviderName = "RedisStore")]
    public class Person : Orleans.Grain<IPersonState>, IPerson
    {
        public async Task<string> SayHello()
        {
            await this.State.ReadStateAsync();
            this.State.OperationCount++;
            await this.State.WriteStateAsync();
            return string.Format("Hello from {0} {1} - again ({2})", this.State.FirstName, this.State.LastName, this.State.OperationCount);
        }

        public async Task SetName(string firstName, string lastName)
        {
            this.State.FirstName = firstName;
            this.State.LastName = lastName;
            await this.State.WriteStateAsync();
        }
    }
}
