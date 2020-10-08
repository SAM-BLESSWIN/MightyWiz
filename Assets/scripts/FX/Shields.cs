using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    private PlayerHealth playerhealth;   
    void Awake()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        playerhealth.Shielded = true;
        print("shield");
    }
    private void OnDisable()
    {
        playerhealth.Shielded = false;
    }
}
