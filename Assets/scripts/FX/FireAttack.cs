using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public float damage = 20f;
    public float Radius = 1f;
    public LayerMask EnemyLayer;
    public float Speed=5f;
    public GameObject fireExplosion;

    private EnemyHealth enemyhealth;
    private bool collided = false;

    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        transform.rotation = Quaternion.LookRotation(Player.transform.forward);
    }

    void Update()
    {
        move();
        FireDamge();
    }

    private void move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void FireDamge()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);

        foreach(Collider c in hit)
        {
           enemyhealth=c.gameObject.GetComponent<EnemyHealth>();
            collided = true;
        }

        if(collided)
        {
            enemyhealth.TakeDamage(damage);
            Vector3 temp = transform.position;
            temp.y += 2f;
            Instantiate(fireExplosion,temp, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
