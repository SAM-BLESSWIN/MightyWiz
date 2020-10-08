using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heals : MonoBehaviour
{
    private PlayerHealth playerhealth;
    public float HealthAmount=10f;

    void Awake()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Start()
    {
       
         playerhealth.health += HealthAmount;

    }
}
