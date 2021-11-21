using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = .2f;
    [SerializeField] float antiTorqueAmount = -0.2f;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(antiTorqueAmount);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            torqueAmount = 10;
            antiTorqueAmount = -10;
        }
    }
}
