using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] GameObject itemDropPrefab;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem healEffect;
    public event EventHandler onEnemyHit;
    public event EventHandler onPlayerHealed;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //////////////////////////////////////////////////////////////////////
        //       On Trigger components
        //////////////////////////////////////////////////////////////////////
        //

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

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
        SpawnItem();
    }

    void SpawnItem()
    {
        GameObject instance = Instantiate(itemDropPrefab,
                                              transform.position,
                                              Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
    }

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

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
