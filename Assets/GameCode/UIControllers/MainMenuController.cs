using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private Button continueButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(delegate { OnClickLoadGame(); });
    }

    // Update is called once per frame
    void Update()
    {
        
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
