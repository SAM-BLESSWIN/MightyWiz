using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    private Transform PlayerTarget;

    public Transform[] WalkPoints;
    private int WalkIndex = 0;

    private float RunDist=8f;
    private float AttackDist = 2f;
    private float CurrentAttackTime;
    private float AttackInterval = 1f;

    private Vector3 NextDest;
    private NavMeshAgent NavAgent;
    private Animator Anim;
    private GameObject Player;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        NavAgent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        if(Player!=null)
        {
            PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (Player!=null)
        {
            float Distance = Vector3.Distance(PlayerTarget.position, transform.position);
            if (Distance > RunDist)
            {
                if (NavAgent.remainingDistance <= 0.5f)   //gives distance between enemy and walkpoint
                {
                    NavAgent.isStopped = false;
                    Anim.SetBool("Walk", true);
                    Anim.SetBool("Run", false);
                    Anim.SetInteger("Atk", 0);

                    NextDest = WalkPoints[WalkIndex].position;
                    NavAgent.SetDestination(NextDest);


                    if (WalkIndex == WalkPoints.Length - 1)
                    {
                        WalkIndex = 0;
                    }
                    else
                    {
                        WalkIndex++;
                    }
                }
            }
            else if (Distance > AttackDist)
            {
                NavAgent.isStopped = false;
                Anim.SetBool("Walk", false);
                Anim.SetBool("Run", true);
                Anim.SetInteger("Atk", 0);

                NavAgent.SetDestination(PlayerTarget.position);

            }
            else
            {
                NavAgent.isStopped = true;
                Anim.SetBool("Walk", false);
                Anim.SetBool("Run", false);

                Vector3 TargetPos = new Vector3(PlayerTarget.position.x, transform.position.y, PlayerTarget.position.z);
                transform.rotation = Quaternion.Slerp(
                                                transform.rotation,
                                                Quaternion.LookRotation(TargetPos - transform.position),
                                                5f * Time.deltaTime);
                if (CurrentAttackTime >= AttackInterval)
                {
                    int AtkRange = Random.Range(1, 3);
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
        else
        {
            if (NavAgent.remainingDistance <= 0.5f)   //gives distance between enemy and walkpoint
            {
                NavAgent.isStopped = false;
                Anim.SetBool("Walk", true);
                Anim.SetBool("Run", false);
                Anim.SetInteger("Atk", 0);

                NextDest = WalkPoints[WalkIndex].position;
                NavAgent.SetDestination(NextDest);


                if (WalkIndex == WalkPoints.Length - 1)
                {
                    WalkIndex = 0;
                }
                else
                {
                    WalkIndex++;
                }
            }
        }
    }
}
