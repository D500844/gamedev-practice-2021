using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoWaPDamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] GameObject bulletToDie;

    

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }

    public void start()
    {
        deadBullet();
    }

    public void deadBullet()
    {
        Destroy(bulletToDie, 10);
    }
}
