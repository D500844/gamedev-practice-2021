using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNuBulletspattern2 : MonoBehaviour
{
    public float bulletFrequency2 = 1f; 
    private float angle = 0f;

    void Start()
    {
        InvokeRepeating("Fire", 0f, bulletFrequency2);    
    }

    private void Fire()
    {

            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletpoolInstance.GetBullet();
               bul.transform.position = transform.position;
               bul.transform.rotation = transform.rotation;
               bul.SetActive(true);
               bul.GetComponent<NuBullet>().SetMoveDirection(bulDir);

            angle += 10f;

    }

}
