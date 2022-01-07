using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] public float moveSpeed = 5f;

    private void OnEnable()
    {
        Invoke("Destroy", 5f);
    }



    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);    
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
