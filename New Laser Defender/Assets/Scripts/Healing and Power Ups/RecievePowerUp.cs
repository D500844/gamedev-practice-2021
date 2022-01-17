using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecievePowerUp : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    [SerializeField] ParticleSystem powerUpEffect;
    Shooter shooter;

    AudioPlayer audioPlayer;
    int counter = 0;
    int counterMinus = -1;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        ActivateObjects();
    }


    public void Update()
    {
        objects[counter].SetActive(true);
        if (counterMinus > 1)
        {
            counterMinus = 1;
        }
    }

    public void ActivateObjects()
    {
        foreach (var obj in objects)
            obj.SetActive(false);
    }

    public void PowerUp()
    {   
        if (counter != 2)
        {
            counter++;
            counterMinus++;
            objects[counterMinus].SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PowerUp powerUpItem = other.GetComponent<PowerUp>();
        if (powerUpItem != null)
        {
            PowerUp();
            PlayPowerUpEffect();
            audioPlayer.PlayPowerUpClip();
            powerUpItem.Hit();
        }
    }

    void PlayPowerUpEffect()
    {
        if (powerUpEffect != null)
        {
            ParticleSystem instance = Instantiate(powerUpEffect,
                                                  transform.position,
                                                  Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration +
                                         instance.main.startLifetime.constantMax);
        }
    }
}
