using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNuBullets : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 10;
    [SerializeField] private float startAngle = 360f;

    public float bulletFrequency =1f;
    private Vector2 bulletMoveDirection;

    void Start()
    {
        InvokeRepeating("Fire", 0f, bulletFrequency);    
    }

    private void Fire()
    {
        float angleStep = 360f / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i <= bulletsAmount -1; i++)
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

            angle += angleStep ;
        }
    }

}
