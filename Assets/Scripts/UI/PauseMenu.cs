using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ResumeButtonPressed()
    {
        Disable();
        PlayingUI.Instance.Enable();
    }

    public void RestartButtonPressed()
    {
        Disable();
        PlayingUI.Instance.Enable(LevelManager.CurrentLevelIndex);
    }

    public void MenuButtonPressed()
    {
        Disable();
        MainMenu.Instance.Enable();
    }

    public void Enable() => GenericMethods.SetAllChildrenActive(gameObject, true);

    public void Disable() => GenericMethods.SetAllChildrenActive(gameObject, false);
}
