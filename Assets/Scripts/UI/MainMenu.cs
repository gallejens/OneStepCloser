using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LevelManager.Instance.LoadEmpty();
        GenericMethods.SetAllChildrenActive(gameObject, true);
    }

    public void SelectButtonPressed()
    {
        Disable();
        SelectMenu.Instance.Enable();
    }

    public void OptionsButtonPressed()
    {
        Disable();
        OptionsMenu.Instance.Enable();
    }

    public void CreditsButtonPressed()
    {
        Disable();
        CreditMenu.Instance.Enable();
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void HelpButtonPressed()
    {
        Disable();
        HelpMenu.Instance.Enable();
    }

    public void Enable()
    {
        GenericMethods.SetAllChildrenActive(gameObject, true);
        LevelManager.Instance.LoadEmpty();
    }

    public void Disable() => GenericMethods.SetAllChildrenActive(gameObject, false);
}
