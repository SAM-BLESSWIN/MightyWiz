using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    private bool isshielded;
    private Animator Anim;
    private Image Player_health;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Player_health = GameObject.Find("Health").GetComponent<Image>();
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
            Player_health.fillAmount = health / 100f;

            if (health<=0)
            {
                Anim.SetBool("Death", true);
                if(!Anim.IsInTransition(0) && Anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
                {
                    if(Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    public void PlayerHeal(float HealAmount)
    {
        health += HealAmount;
        if (health > 100.0f)
        {
            health = 100.0f;
        }
        Player_health.fillAmount = health / 100.0f;
    }
}
