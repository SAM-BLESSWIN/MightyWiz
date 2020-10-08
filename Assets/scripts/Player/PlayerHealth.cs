using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    private bool isshielded;

    public bool Shielded
    {
        get
        {
            return isshielded;
        }
        set
        {
            isshielded = value;
        }
    }

    public void TakeDamage(float damage_amount)
    {
        if(!isshielded)
        {
            health -= damage_amount;
            if(health<=0)
            {
                print("Player DEAD");
            }
        }
    }

}
