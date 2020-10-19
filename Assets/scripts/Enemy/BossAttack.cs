using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private GameObject player;
    private Transform Playertarget;

    public GameObject BossHit;
    public GameObject BossTornado;

    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        if(player)
        {
            Playertarget = player.transform;
        }
    }

    public void BossFireTornado()
    {
        Instantiate(BossTornado, Playertarget.position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
    }

    public void BossSpell()
    {
        Vector3 temp = Playertarget.position;
        temp.y += 1.5f;
        Instantiate(BossHit, temp, Quaternion.identity);
    }

}
