using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIGameStart : MonoBehaviour
{
    // initial button that will recieve controller selection
    public GameObject firstSelectionButton;

    void Start()
    {
        // clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(firstSelectionButton);
    }
}
