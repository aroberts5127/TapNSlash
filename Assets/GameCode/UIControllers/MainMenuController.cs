using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EnumUtil;

public class MainMenuController : MonoBehaviour, IUIScreenBehavior
{

    [SerializeField]
    private Button continueButton;

    public eScreenID ScreenID { get { return eScreenID.mainMenu; } set { } }
    
    public void Setup(object data)
    {
        continueButton.onClick.AddListener(delegate { OnClickLoadGame(); });
    }

    private void OnClickLoadGame()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync("Overworld");
        //INIT DATA
        while (!MainInitialization.Instance._allInitialized)
            yield return null;
        while (!sceneLoad.isDone)
        {
            Debug.Log("Loading");
            yield return null;
        }
    }
}
