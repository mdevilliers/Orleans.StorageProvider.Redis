using Orleans;

namespace Test.Interfaces
{
    public interface IPersonState : IGrainState
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int OperationCount { get; set; }
    }
}