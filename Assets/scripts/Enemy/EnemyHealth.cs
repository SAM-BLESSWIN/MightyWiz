using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float health = 100f;
    public void TakeDamage(float damageamount)
    {
        health -= damageamount;
        print("Health" + health);   

        if (health <= 0)
        {
            print("DEAD");
            Destroy(gameObject);
        }
    }
}