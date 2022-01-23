using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreditMenu : MonoBehaviour
{
    public static CreditMenu Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void BackButtonPressed()
    {
        Disable();
        MainMenu.Instance.Enable();
    }

    public void Enable() => GenericMethods.SetAllChildrenActive(gameObject, true);

    public void Disable() => GenericMethods.SetAllChildrenActive(gameObject, false);
}
