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
    public event EventHandler onEnemyHit;

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

    // Let's take the following code- reverse engineer it and create
    // an actual Healing item with appropriate sounds/particles/image/math
    // and a power up as well.

    void OnTriggerEnter2D(Collider2D other)
    {
        // So what is damage dealing;
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        // Ok so is it damage dealing;
        if (damageDealer != null)
        {
            // Nice it is, let's;
            // Get hurt
            TakeDamage(damageDealer.GetDamage());
            // Sparkle a bit like Twilight
            PlayHitEffect();
            // Make a cool sound
            audioPlayer.PlayDamageClip();
            // Try to impress Megan Fox
            ShakeCamera();

            // Destroy the evidence
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
    }


    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        onEnemyHit?.Invoke(this, EventArgs.Empty);

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
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

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
