using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    private BaseController baseController;
    private AnimationHandler animationHandler;
    private StatHandler statHandler;

    private void Awake()
    {
        baseController = GetComponent<BaseController>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }
}
