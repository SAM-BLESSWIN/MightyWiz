using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDamges : MonoBehaviour
{
    public LayerMask EnemyLayer;
    public float damagetaken = 10f;
    public float Radius = 1f;

    private EnemyHealth enemyhealth;
    private bool collided=false;

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);
        foreach (Collider c in hit)
        {
            enemyhealth=c.gameObject.GetComponent<EnemyHealth>();
            collided = true;
        }

        if(collided)
        {
            enemyhealth.TakeDamage(damagetaken);
            enabled = false;
        }
    }
}
