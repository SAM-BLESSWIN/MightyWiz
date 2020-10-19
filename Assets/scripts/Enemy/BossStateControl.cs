using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    NONE,
    IDLE,
    RUN,
    ATTACK,
    DEATH
};

public class BossStateControl : MonoBehaviour
{
    private GameObject player;
    private Transform PlayerTarget;
    private BossState boss_st = BossState.NONE;
    private float enemytarget_dist;
    private EnemyHealth enemyhealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyhealth = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        if(player)
        {
            PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        if(player)  SetState();
    }

    private void SetState()
    {
        enemytarget_dist = Vector3.Distance(transform.position, PlayerTarget.position);
        if (boss_st != BossState.DEATH)
        {
            if (enemyhealth.health <= 0f)
            {
                boss_st = BossState.DEATH;
            }

            if (enemytarget_dist>=10f)
            {
                boss_st = BossState.IDLE;
            }
            else if(enemytarget_dist<=2f)
            {
                boss_st = BossState.ATTACK;
            }
            else if(enemytarget_dist<=10f)
            {
                boss_st = BossState.RUN;
            }
            else
            {
                boss_st = BossState.NONE;
            }
        }
    }

    public BossState bossState
    {
        get
        {
            return boss_st;
        }
        set
        {
            boss_st = value;
        }
    }
}
