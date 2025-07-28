using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    private BaseController baseController;
    private AnimationHandler animationHandler;
    private StatHandler statHandler;
    private RidingController ridingeController;

    private void Awake()
    {
        baseController = GetComponent<BaseController>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
        ridingeController = GetComponent<RidingController>();
    }

    public void ToggleAimator()
    {
        animationHandler.ToggleAnimator();
    }

    public void SetSpeed(int speed)
    {
        statHandler.Speed = speed;
    }

    public int GetSpeed()
    {
        return statHandler.Speed;
    }
}
