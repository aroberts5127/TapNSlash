using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumUtil;

public class UIManager : SingletonClass<UIManager>, IInitializationClass
{
    private bool _initialized;
    //May need to become a Dictionary? So we have a way to call it by its eScreenID.
    List<IUIScreenBehavior> screensNeededInOpenScene;

    public bool AllInitialized => _initialized;

    public void InitializeClass()
    {
        if (screensNeededInOpenScene != null)
        {
            foreach (IUIScreenBehavior screen in screensNeededInOpenScene)
                screen.Setup();
        }
        _initialized = true;
    }

    public void WaitingOnOtherInit()
    {       
    }

    public void NewSceneLoaded(List<IUIScreenBehavior> screensInNewScene)
    {
        screensNeededInOpenScene.Clear();
        foreach (IUIScreenBehavior screen in screensInNewScene)
        {
            screensNeededInOpenScene.Add(screen);
            screen.Setup();
        }

        for(int i = 0; i < screensNeededInOpenScene.Count; i++)
        {
            screensNeededInOpenScene[i].Setup();
        }
    }
}


public interface IUIScreenBehavior
{ 
    eScreenID ScreenID { get; set; }

    void Setup(object data = null);
}