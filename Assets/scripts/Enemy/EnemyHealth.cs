using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    float health = 100f;
    private Animator Anim;
    private Image Health_img;

    private void Awake()
    {
        Anim = GetComponent<Animator>();

        if(tag=="Enemy")
        {
            Health_img = GameObject.Find("HealthFG").GetComponent<Image>();
        }
    }

    public void TakeDamage(float damageamount)
    {
        health -= damageamount;
        Health_img.fillAmount = health / 100f;

        if (health <= 0)
        {
            Anim.SetBool("Death", true);
            if (!Anim.IsInTransition(0) && Anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                Destroy(gameObject,2f);
            }
        }
    }
}