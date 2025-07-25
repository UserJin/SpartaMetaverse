using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance
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

    private void Awake()
    {
        if (_instance == null)
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
        _instance = FindObjectOfType<DataManager>();
        if (_instance == null)
        {
            GameObject obj = new GameObject();
            _instance = obj.AddComponent<DataManager>();
            obj.name = $"{_instance.GetType().Name}";
            DontDestroyOnLoad(obj);
        }
    }
}
