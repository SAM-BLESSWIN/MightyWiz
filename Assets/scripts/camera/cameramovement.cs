using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    private Transform player;

    public float follow_height = 8f;
    public float follow_distance = 10f;

    private Quaternion euler;

    private float target_height;

    private float current_height;
    private float current_rotation;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        target_height = player.position.y + follow_height;   //camera height above player
        current_rotation = transform.eulerAngles.y;          //current camera rotation in degrees
        euler = Quaternion.Euler(0f, current_rotation, 0f);  //camera rotation only along y axis
    }
    private void Update()
    {
        //give intermediate float value b/w 2 position with time(used for zoom in effect)
        current_height = Mathf.Lerp(transform.position.y, target_height, 0.9f * Time.deltaTime);

        //target camera position calculation (i.e z denotes the dist b/w camera and player,x will be player x position )
        Vector3 target_pos = player.position - (Vector3.forward* follow_distance); 

        target_pos.y = current_height; //make camera fixed at y(fixed height) only change along x and z
        transform.position = target_pos;//assign values to camera position
        transform.LookAt(player);//always make camera look at player
    }
}
