using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    public static SelectMenu Instance { get; private set; }

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject panel;

    private List<GameObject> LevelSelectButtons = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < LevelManager.Instance.Levels.Length; i++)
        {
            int temp = i;

            GameObject createdButton = (Instantiate(buttonPrefab, panel.transform) as GameObject);

            createdButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text += (i+1);
            createdButton.GetComponentInChildren<Button>().onClick.AddListener(() => LevelButtonClicked(temp));
            createdButton.name = i.ToString();

            LevelSelectButtons.Add(createdButton);
        }
    }

    public void LevelButtonClicked(int number)
    {
        Disable();
        PlayingUI.Instance.Enable(number);
    }

    public void BackButtonPressed()
    {
        Disable();
        MainMenu.Instance.Enable();
    }

    public void Enable()
    {
        GenericMethods.SetAllChildrenActive(gameObject, true);
    }

    public void Disable()
    {
        GenericMethods.SetAllChildrenActive(gameObject, false);
    }
}
