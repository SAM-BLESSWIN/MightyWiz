using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float health = 100f;
    private Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damageamount)
    {
        health -= damageamount;
        print("Health" + health);   

        if (health <= 0)
        {
            Anim.SetBool("Death", true);
            if (!Anim.IsInTransition(0) && Anim.GetCurrentAnimatorStateInfo(0).IsName("Death") || Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
            {
                Destroy(gameObject);
            }
        }
    }
}