using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage_amount = 10f;
    private Transform PlayerTarget;
    private bool IsAttacking;
    private bool FinishedAttack = true;
    private PlayerHealth playerhealth;
    private Animator Anim;

    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(PlayerTarget)
        {
            if (FinishedAttack)
            {
                DealDamge(CheckIsattacking());
            }
            else
            {
                if (!Anim.IsInTransition(0) && Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    FinishedAttack = true;
                }
            }
        }
    }

    private bool CheckIsattacking()
    {
        IsAttacking = false;

        if (!Anim.IsInTransition(0) && Anim.GetCurrentAnimatorStateInfo(0).IsName("Atk1") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Atk2"))
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                IsAttacking = true;
                FinishedAttack = false;
            }
        }
        return IsAttacking;
    }

    private void DealDamge(bool IsAttacking)
    {
        if (IsAttacking)
        {
             playerhealth.TakeDamage(damage_amount);
        }
    }
}
