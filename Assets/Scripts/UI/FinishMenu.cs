using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMenu : MonoBehaviour
{
    public static FinishMenu Instance { get; private set; }

    private bool arrivedAtFinish = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (LevelManager.TargettablesRemaining == 0 && !arrivedAtFinish)
        {
            PlayingUI.Instance.Disable();
            Enable();
            arrivedAtFinish = true;
        }
    }

    public void NextButtonPressed()
    {
        Disable();
        LevelManager.CurrentLevelIndex++;
        PlayingUI.Instance.Enable(LevelManager.CurrentLevelIndex);
    }

    public void ReplayButtonPressed()
    {
        Disable();
        PlayingUI.Instance.Enable(LevelManager.CurrentLevelIndex);
    }

    public void MenuButtonPressed()
    {
        Disable();
        MainMenu.Instance.Enable();
    }

    private void Enable()
    {
        GenericMethods.SetAllChildrenActive(gameObject, true);
    }

    public void Disable()
    {
        GenericMethods.SetAllChildrenActive(gameObject, false);
        arrivedAtFinish = false;
    }
}
