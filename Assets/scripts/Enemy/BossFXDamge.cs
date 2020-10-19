using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFXDamge : MonoBehaviour
{
    public LayerMask playerlayer;
    public float damageamount;
    public float radius;

    private PlayerHealth playerhealth;
    private bool collided = false;

    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, playerlayer);

        foreach(Collider c in hit)
        {
            collided = true;
        }

        if(collided)
        {
            playerhealth.TakeDamage(damageamount);
            enabled = false;
        }
    }
}
