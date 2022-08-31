public interface IInitializationClass
{
    void InitializeClass();
    //Implementation Not Needed For All Init classes inately.
    void WaitingOnOtherInit();
    bool AllInitialized { get; }

}

