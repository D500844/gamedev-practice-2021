using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] bool isBoss;
    [SerializeField] GameObject itemDropPrefab;
    [SerializeField] bool doubleItemDrop = false;
    [SerializeField] GameObject doubleItemDropPrefab;
    [SerializeField] public int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem healEffect;
    [SerializeField] ParticleSystem chorusonEffect;
    [SerializeField] ParticleSystem powerUpEffect;
    public event EventHandler onEnemyHit;
    public event EventHandler onPlayerHealed;
    public Slider bossSlider;
    public GameObject bossSliderToggle;
    public bool secondForm = false;
    private float changeInThisTime = 1;

    [SerializeField] bool applyCameraShake;
    [SerializeField] bool applyViolentCameraShake;
    CameraShake cameraShake;
    CameraShake violentCameraShake;

    [SerializeField] Shooter shooter;
    [SerializeField] FireNuBullets fireNuBullets;
    [SerializeField] FireNuBulletspattern2 fireNuBulletspattern2;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    GameObject playerObjectCheck;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        if(isPlayer && health > 50)
        {
            health = 50;
        }

        if(isBoss == true)
        {
            //bossSlider.value = health;
            //bossSliderToggle.SetActive(true);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////
    ///       On Trigger components
    ///  /////////////////////////////////////////////////////////////////////////////

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health = 0;
        }

        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        }

        BoWaPDamageDealer bowapdamageDealer = other.GetComponent<BoWaPDamageDealer>();
        if (bowapdamageDealer != null)
        {
            TakeDamage(bowapdamageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            bowapdamageDealer.Hit();
        }


        HealingItem healingItem = other.GetComponent<HealingItem>();
        if (healingItem != null)
        {
            TakeHealing(healingItem.GetHealed());
            PlayHealEffect();
            audioPlayer.PlayHealedClip();
            healingItem.Hit();
        }

        ChorusActivator chorusItem = other.GetComponent<ChorusActivator>();
        if (chorusItem != null)
        {
            ChorusUp();
            ChorusEffect();
            audioPlayer.PlayPowerUpClip();
            chorusItem.Hit();
        }

        DelayActivator delayItem = other.GetComponent<DelayActivator>();
        if (delayItem != null)
        {
            DelayUp();
            ChorusEffect();
            audioPlayer.PlayPowerUpClip();
            delayItem.Hit();
        }

        ReverbActivator reverbItem = other.GetComponent<ReverbActivator>();
        if (reverbItem != null)
        {
            ReverbUp();
            ChorusEffect();
            audioPlayer.PlayPowerUpClip();
            reverbItem.Hit();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////
    ///      Event System 
    /// //////////////////////////////////////////////////////////////////////////////

    void TakeDamage(int damage)
    {
        onEnemyHit?.Invoke(this, EventArgs.Empty);
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void TakeHealing(int healing)
    {
        onPlayerHealed?.Invoke(this, EventArgs.Empty);
        health += healing;
        if (health >= 50)
        {
            health = 50;
        }
    }


    public int GetHealth()
    {
        return health;
    }

    public void SecondFormSet()
    {
        secondForm = true;
    }

    void Die()
    {
        ///////////////////////////////////////////////////////////////////////////
        // Second Form Boss Script
        ///////////////////////////////////////////////////////////////////////////

        if (isBoss && secondForm == false)
        {
            Invoke("SecondFormSet", changeInThisTime);
            health = 2465;
            fireNuBulletspattern2.bulletFrequency2 = .03f;
            fireNuBullets.bulletFrequency = .7f;
            fireNuBullets.bulletsAmount = 70;
            shooter.baseFiringRate = .14f;
            shooter.firingRateVariance = .1f;
            shooter.minimumFiringRate = .09f;
            ShakeCamera();
            PlayPowerUpEffect();

        }
        
        if (isBoss && secondForm == true)
        {
            scoreKeeper.ModifyScore(score);
            SpawnItem();
            Destroy(gameObject);
        }

        if (!isPlayer && !isBoss)
        {
            scoreKeeper.ModifyScore(score);
            SpawnItem();
            Destroy(gameObject);
        }

        if (isPlayer)
        {
            Destroy(gameObject);
            levelManager.LoadGameOver();
        }
    }

    void SpawnItem()
    {
        GameObject instance = Instantiate(itemDropPrefab,
                                              transform.position,
                                              Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

        if (doubleItemDrop == true)
        {
            GameObject instance2 = Instantiate(doubleItemDropPrefab,
                                      transform.position,
                                      Quaternion.identity);
            Rigidbody2D rb2 = instance2.GetComponent<Rigidbody2D>();
        }
    }



    //////////////////////////////////////////////////////////////////////////////////
    ///      Special Effects
    /// //////////////////////////////////////////////////////////////////////////////

    [Header("\b")]
    [SerializeField] GameObject Bluech;
    [SerializeField] GameObject Greench;
    [SerializeField] GameObject Purplech;

    //////////////////////////
    ///     Chorus
    //////////////////////////
    ///
    [Header("Chorus Plug ins")]
    [SerializeField] GameObject ChorusB;
    [SerializeField] GameObject ChorusG;
    [SerializeField] GameObject ChorusP;



    public void ChorusUp()
    {
        if (Bluech.activeSelf is true)
        {
            ChorusB.SetActive(true);
        }
        if (Greench.activeSelf is true)
        {
            ChorusG.SetActive(true);
        }   
        if(Purplech.activeSelf is true)
        {
            ChorusP.SetActive(true);
        }
            
    }

    //////////////////////////
    ///     Delay
    //////////////////////////
    ///
    [Header("Delay Plug ins")]
    [SerializeField] GameObject DelayB;
    [SerializeField] GameObject DelayG;
    [SerializeField] GameObject DelayP;



    public void DelayUp()
    {
        if (Bluech.activeSelf is true)
        {
            DelayB.SetActive(true);
        }
        if (Greench.activeSelf is true)
        {
            DelayG.SetActive(true);
        }
        if (Purplech.activeSelf is true)
        {
            DelayP.SetActive(true);
        }

    }

    //////////////////////////
    ///     Reverb
    //////////////////////////
    ///
    [Header("Reverb Plug ins")]
    [SerializeField] GameObject ReverbB;
    [SerializeField] GameObject ReverbG;
    [SerializeField] GameObject ReverbP;



    public void ReverbUp()
    {
        if (Bluech.activeSelf is true)
        {
            ReverbB.SetActive(true);
        }
        if (Greench.activeSelf is true)
        {
            ReverbG.SetActive(true);
        }
        if (Purplech.activeSelf is true)
        {
            ReverbP.SetActive(true);
        }

    }
    /////////////////////////////////////////////////////////////////////////////////
    ///  Particle Triggers
    ///  ////////////////////////////////////////////////////////////////////////////


    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, 
                                                  transform.position, 
                                                  Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration +
                                         instance.main.startLifetime.constantMax);
        }
    }

    void PlayHealEffect()
    {
        if (healEffect != null)
        {
            ParticleSystem instance = Instantiate(healEffect,
                                                  transform.position,
                                                  Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration +
                                         instance.main.startLifetime.constantMax);
        }
    }

    void ChorusEffect()
    {
        if (chorusonEffect != null)
        {
            ParticleSystem instance = Instantiate(chorusonEffect,
                                                  transform.position,
                                                  Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration +
                                         instance.main.startLifetime.constantMax);
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

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void ViolentShakeCamera()
    {
        if (cameraShake != null && applyViolentCameraShake)
        {
            violentCameraShake.ViolentPlay();
        }
    }

}
