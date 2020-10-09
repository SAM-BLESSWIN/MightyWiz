using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    private bool isshielded;
    private Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

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
            print("Player Health"+health);
            if (health<=0)
            {
                Anim.SetBool("Death", true);
                if(!Anim.IsInTransition(0) && Anim.GetCurrentAnimatorStateInfo(0).IsName("Death") || Anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=0.95f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
