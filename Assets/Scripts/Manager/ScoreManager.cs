using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if( _instance == null )
            {
                Init();
            }

            return _instance;
        }
    }

    private int flappyBirdBestScore;

    private int flappyBirdCurScore;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void Init()
    {
        _instance = FindObjectOfType<ScoreManager>();
        if (_instance == null)
        {
            GameObject obj = new GameObject();
            obj.name = "ScoreManager";
            _instance = obj.AddComponent<ScoreManager>();
            DontDestroyOnLoad(obj);
        }
    }
}
