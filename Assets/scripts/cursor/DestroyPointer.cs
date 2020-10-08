using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
       if(Vector3.Distance(player.position,transform.position)<=1.5f)
        {
            Destroy(gameObject);
        }
    }
}
