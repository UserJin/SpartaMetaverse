using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uIManager;

    public virtual void Init(UIManager uIManager)
    {
        this.uIManager = uIManager;
    }

    protected abstract UIState GetUIStates();

    public void SetActive(UIState state)
    {
        gameObject.SetActive(GetUIStates() == state);
    }
}
