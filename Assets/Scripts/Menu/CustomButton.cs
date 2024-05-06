using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    public Action<bool, GameObject> OnFocusMouse { get { return onFocusMouse; } set { onFocusMouse = value; } }
    private Action<bool, GameObject> onFocusMouse;
    private GameObject thisObject;
    protected override void Start()
    {
        thisObject=gameObject;
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        onFocusMouse?.Invoke(true, thisObject);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        onFocusMouse?.Invoke(false, thisObject);
    }
}
