using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject objectToToggle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ToggleObject();
        }
    }

    private void ToggleObject()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
