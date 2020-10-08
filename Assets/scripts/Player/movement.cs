using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    private CharacterController playercontrol;
    private Animator anim;
    private CollisionFlags collisionFlags = CollisionFlags.None;   //player collision to none

    private float  movespeed=5f;

    bool canmove;
    private bool finishedmove = true;

    private Vector3 targetpos = Vector3.zero;   //initialize target position to zero
    private Vector3 player_move = Vector3.zero; //where the player should move
    private float playertopointdist;           //to store dist b/w player and mouseclick

    private float gravity = 9.8f;
    private float height;

    private void Awake()
    {
        playercontrol = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        calculateheight();          //smoothing gravity
        checkfinishedmove();        //smoothing animation
    }

    //check player is on grounf
    private bool isgrounded()
    {
        return  collisionFlags == CollisionFlags.CollidedBelow ? true : false;
    }

    //applying gravity to player
    private void calculateheight()
    {
        if(isgrounded())
        {
            height = 0f;
        }
        else
        {
            height -= gravity * Time.deltaTime; //smoothing jump and fly
        }
    }

    //smoothing animation
    private void checkfinishedmove()
    {
        //if DIDNOT finish movement
        if(!finishedmove)   //get into if condition -- if the animation is not finished(i.e when finishedmove is false)
        {
            if(!anim.IsInTransition(0)      //check is the transition not in 0th state
                && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand") //current animation name is stand
                && anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=0.8f)// normalized time is animation played time (0-started,0.5 mid of anmation,1-completed)
            {
                finishedmove = true; 
            }
        }
        else
        {
            playermovement();
            player_move.y = height * Time.deltaTime;
            collisionFlags = playercontrol.Move(player_move);
        }
    }

    private void playermovement()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // y ray rather than using direct mouse postion?
            //mouse.postion gives screen co-ord ,we need world co-ord so, we get by hit.point;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //cast rays from camera to mouse click position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))  //detects any ray hits
            {
                if (hit.collider is TerrainCollider)  //if hit collides wih terrain collider
                {
                    //y dist b/w player and hit position and not dist b/w player and mouse position?
                    //**hit.points are given in world co-ord where mouse.postion given in screen co-ord
                    playertopointdist = Vector3.Distance(transform.position, hit.point);
                    if (playertopointdist>=1.0f)
                    {
                        canmove = true;
                        targetpos = hit.point;    //make the ray-hit position on terrain ,as the target position where the player has to move
                    }
                }
            }

        }

        if(canmove)
        {
            anim.SetFloat("Walk", 1.0f);
            //y direction should not change (this is done for supporting proper rotation)
            Vector3 targettemp = new Vector3(targetpos.x, transform.position.y, targetpos.z);

            //player rotation
            //direction of rotation of player
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targettemp - transform.position), 15f*Time.deltaTime); 

            //forward-blue axis or z axis (move along the direction pointed by blueaxis after rotation)
            player_move = transform.forward * movespeed * Time.deltaTime;

            if(Vector3.Distance(transform.position,targetpos)<=0.5f)
            {
                canmove = false;
            }
        }
        else
        {
            player_move.Set(0f, 0f, 0f);
            anim.SetFloat("Walk", 0f);
        }
    }

    public bool Finishedmove
    {
        get
        {
            return finishedmove;
        }

        set
        {
            finishedmove = value;
        }
    }

    public Vector3 Targetpos
    {
        get
        {
            return targetpos;
        }
        set
        {
            targetpos = value;
        }
    }
}
