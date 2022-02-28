public interface IInitializationClass
{
    void InitializeClass();
    void WaitingOnOtherInit();
    bool AllInitialized { get; }
}