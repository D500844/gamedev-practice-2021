using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderToggler : MonoBehaviour
{
    [SerializeField] GameObject BossBar;

    private void Update()
    {

    }

    public void ToggleBarOn()
    {
        BossBar.SetActive(true);
    }
}
