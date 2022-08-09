using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumUtil;


public class MainInitialization : MonoBehaviour
{
    public static MainInitialization Instance;

    private List<IInitializationClass> initializationClasses = new List<IInitializationClass>();
    public EnumInitializationStatus _initializationStatus { get; private set; }

    public bool _allInitialized;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            _allInitialized = false;
        }

        //ADD INIT CLASSES TO List Here;
        initializationClasses.Add(PlayerAccountInformation.Instance);
        initializationClasses.Add(UIManager.Instance);

        InitializeApplicationClasses();
    }

    public void InitializeApplicationClasses()
    {
        foreach(IInitializationClass initClass in initializationClasses)
        {
            initClass.InitializeClass();
        }
        StartCoroutine(CheckOnInitializations());
    }

    private IEnumerator CheckOnInitializations()
    {
        _allInitialized = false;
        while (!_allInitialized)
        {
            _allInitialized = true;
            foreach(IInitializationClass initClass in initializationClasses)
            {
                if (!initClass.AllInitialized)
                {
                    initClass.WaitingOnOtherInit();
                    _allInitialized = false;
                }
            }
            yield return null;
        }
        _initializationStatus = EnumInitializationStatus.Initialized;
    }
}
