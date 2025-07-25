using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader _instance;
    public static SceneLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                Init();
            }

            return _instance;
        }
    }

    int prevSceneIdx = -1;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            prevSceneIdx = -1;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void Init()
    {
        _instance = FindObjectOfType<SceneLoader>();
        if (_instance == null)
        {
            GameObject obj = new GameObject();
            _instance = obj.AddComponent<SceneLoader>();
            obj.name = $"{_instance.GetType().Name}";
            _instance.prevSceneIdx = -1;
            DontDestroyOnLoad(obj);
        }
    }

    public void LoadScene(string scnenName)
    {
        prevSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scnenName);
    }

    public void LoadScene(int sceneIdx)
    {
        prevSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIdx);
    }

    public void LoadPrevScene()
    {
        if (prevSceneIdx == -1)
            return;

        int tmpSceneIdx = prevSceneIdx;
        LoadScene(tmpSceneIdx);
    }

    public void LoadMainScene(int resultScore)
    {
        LoadScene(0);
    }
}
