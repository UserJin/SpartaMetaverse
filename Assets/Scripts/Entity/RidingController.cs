using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RidingController : MonoBehaviour
{
    // 탑승물 능력치
    StatHandler statHandler;

    private void Awake()
    {
        statHandler = FindObjectOfType<PlayerController>().GetComponent<StatHandler>();
    }

    public void ActiveRide()
    {

    }

    public void DeactiveRide()
    {

    }
}
