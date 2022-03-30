using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBossDisplay : MonoBehaviour
{

    [Header("Boss Health")]
    [SerializeField] Slider bossHealthSlider;
    [SerializeField] Health bossHealth;

    void Start()
    {
        bossHealthSlider.maxValue = bossHealth.GetHealth();
    }

    void Update()
    {
        bossHealthSlider.value = bossHealth.GetHealth();
    }
}