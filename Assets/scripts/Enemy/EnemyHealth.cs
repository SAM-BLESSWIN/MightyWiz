using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    private Animator Anim;
    public Image Health_img;
    private NavMeshAgent Navagent;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Navagent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damageamount)
    {
        health -= damageamount;
        Health_img.fillAmount = health / 100f;

        if (health <= 0)
        {
            Anim.SetBool("Death", true);
            Destroy(gameObject,3f);
            Navagent.isStopped = true;
        }
    }
}