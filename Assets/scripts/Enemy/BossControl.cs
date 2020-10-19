using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControl : MonoBehaviour
{
    private Transform PlayerTarget;
    private GameObject player;
    private BossStateControl bossstatecontrol;
    private Animator Anim;
    private NavMeshAgent Navagent;

    private float CurrentAttackTime = 0f;
    private float WaitingTime = 1f;

    private bool finishedattack = true;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bossstatecontrol = GetComponent<BossStateControl>();
        Anim = GetComponent<Animator>();
        Navagent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if(player)
        {
            PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
       if(player)
        {
            if (!finishedattack)
            {
                if (!Anim.IsInTransition(0) && Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    Anim.SetInteger("Atk", 0);
                    finishedattack = true;
                }
            }
            else
            {
                GetStateControl();
            }
        }
    }

    private void GetStateControl()
    {
        if(bossstatecontrol.bossState==BossState.DEATH)
        {
            Anim.SetBool("Death", true);
            Destroy(gameObject, 3f);
            Navagent.isStopped = true;
        }

        else if(bossstatecontrol.bossState==BossState.RUN)
        {
            Anim.SetBool("Run", true);
            Navagent.isStopped = false;
            Navagent.SetDestination(PlayerTarget.position);
        }

        else if(bossstatecontrol.bossState==BossState.ATTACK)
        {
            Anim.SetBool("Run", false);
            Vector3 TargetPosition = new Vector3(PlayerTarget.position.x, transform.position.y, PlayerTarget.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TargetPosition - transform.position), 5f * Time.deltaTime);
            
            if (CurrentAttackTime >= WaitingTime)
            {
                int AtkRange =Random.Range(1, 5);
                Anim.SetInteger("Atk", AtkRange);
                CurrentAttackTime = 0f;
            }
            else
            {
                Anim.SetInteger("Atk", 0);
                CurrentAttackTime += Time.deltaTime;
            }
        }
    }
}
