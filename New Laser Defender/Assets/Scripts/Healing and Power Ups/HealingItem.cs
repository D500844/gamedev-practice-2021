using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] int healing = 10;

    private void Awake()
    {
        Invoke("Umissedme", 3f);
    }

    void Umissedme()
    {
        Object.Destroy(this.gameObject);
    }

    public int GetHealed()
    {
        return healing;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
