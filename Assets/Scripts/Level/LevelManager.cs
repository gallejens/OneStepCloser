using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private GameObject player;

    public GameObject[] Levels { get; private set; }
    public static int TargettablesRemaining { get; set; }
    public static int CurrentLevelIndex { get; set; } = 0;

    private GameObject lastCreateLevelObject;

    private void Awake()
    {
        Instance = this;
        Levels = Resources.LoadAll<GameObject>("Levels");
    }

    public void LoadLevel(int index)
    {
        CurrentLevelIndex = index;
        GameObject level = Levels[CurrentLevelIndex];
        LevelData levelData = level.GetComponent<LevelData>();
        TargettablesRemaining = levelData.AmountOfTargettables;

        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = levelData.StartPosition;
        player.GetComponent<CharacterController>().enabled = true;

        Destroy(lastCreateLevelObject);
        lastCreateLevelObject = Instantiate(Levels[CurrentLevelIndex], Vector3.zero, Quaternion.identity) as GameObject;
    }

    public void LoadEmpty()
    {
        CurrentLevelIndex = 0;
        TargettablesRemaining = -1;
        Destroy(lastCreateLevelObject);
    }
}
