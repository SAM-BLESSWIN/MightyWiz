using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heals : MonoBehaviour
{
    private PlayerHealth playerhealth;
    public float HealthAmount=10f;
    private Image Player_health;

    void Awake()
    {
        Player_health = GameObject.Find("Health").GetComponent<Image>();
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        playerhealth.PlayerHeal(HealthAmount);
    }
}
