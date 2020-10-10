using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour
{
    private GameObject player;
    private Transform playertarget;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        if(player!=null)
        {
            playertarget= GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        if(player!=null)
        {
            if (Vector3.Distance(playertarget.position, transform.position) <= 1.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
