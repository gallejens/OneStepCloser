using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTargetting : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private int targetDistance = 3;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (PlayingUI.IsEnabled)
        {
            GameObject currentTarget = LookingAtTargettableObject();
            if (currentTarget != null)
            {
                if (Input.GetButtonDown("Select"))
                {
                    Destroy(currentTarget);
                    LevelManager.TargettablesRemaining--;
                    AudioController.Instance.TargettableClicked();
                }
            }
        }
    }

    private GameObject LookingAtTargettableObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, targetDistance, 1 << 6))
        {
            return hit.transform.gameObject;
        }

        return null;
    }
}
