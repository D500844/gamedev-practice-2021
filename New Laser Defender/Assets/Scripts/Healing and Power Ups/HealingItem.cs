using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] int healing = 10;

    public int GetHealed()
    {
        return healing;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
