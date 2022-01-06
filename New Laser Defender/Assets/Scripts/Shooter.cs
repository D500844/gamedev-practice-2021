using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5;
    [SerializeField] float baseFiringRate = 0.2f;
    
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;

    //[Header("Projectile Settings")]
    //public int numberOfProjectiles;            // Number of projectiles to shoot
    //public float newProjectileSpeed;              // Speed of the projectile
    //public GameObject ProjectilePrefab;        // Prefab to spawn

    //[Header("PrivateVariables")]
    //private Vector3 startPoint;                // Starting position of the bullet
    //private const float radius = 1f;           // Help us find the move direction

    PauseManager pause;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }


    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (PauseManager.paused == false && isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                              transform.position,
                                              Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
                //startPoint = transform.position;
                //SpawnProjectile(numberOfProjectiles);
            }
            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
                                                    baseFiringRate + firingRateVariance);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }

    //private void SpawnProjectile(int _numberOfProjectiles)
    //{
    //    float angleStep = 360f / _numberOfProjectiles;
    //    float angle = 0f;

    //    for (int i = 0; i <= _numberOfProjectiles - 1; i++)
    //    {
    //        // Direction calculations
    //        float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
    //        float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

    //        Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
    //        Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * newProjectileSpeed;

    //        GameObject tmpObj = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
    //        tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

    //        angle += angleStep;
    //    }
    //}
}
