using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingUI : MonoBehaviour
{
    public static PlayingUI Instance { get; private set; }

    public static bool IsEnabled { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause") && IsEnabled)
        {
            Disable();
            PauseMenu.Instance.Enable();
            AudioController.Instance.GamePaused();
        }
    }

    public void Enable(int levelNumber)
    {
        LevelManager.Instance.LoadLevel(levelNumber);

        Enable();
    }

    public void Enable()
    {
        GenericMethods.SetAllChildrenActive(gameObject, true);

        IsEnabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Disable()
    {
        GenericMethods.SetAllChildrenActive(gameObject, false);

        IsEnabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
