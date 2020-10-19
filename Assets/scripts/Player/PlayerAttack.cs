using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Image fadeimage1;
    public Image fadeimage2;
    public Image fadeimage3;
    public Image fadeimage4;
    public Image fadeimage5;
    public Image fadeimage6;

    private int[] fillimage=new int[]{0,0,0,0,0,0};

    
    private movement move;
    private Animator anim;

    private bool canattack = true;


    private void Awake()
    {
        move = GetComponent<movement>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canattack = true;
        }
        else
        {
            canattack = false;
        }

        checkinput();
        checkfade();
    }

    private void checkinput()
    {
        if (anim.GetInteger("Atk") == 0)
        {
            move.Finishedmove = false;

            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                move.Finishedmove = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (move.Finishedmove && fillimage[0] != 1 && canattack)
            {
                fillimage[0] = 1;
                anim.SetInteger("Atk", 1);
                move.Targetpos = transform.position;
                RemovePointeratAttack();       
            }
         
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (move.Finishedmove && fillimage[1] != 1 && canattack)
            {
                fillimage[1] = 1;
                anim.SetInteger("Atk", 2);

                move.Targetpos = transform.position;
                RemovePointeratAttack();
            }

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (move.Finishedmove && fillimage[2] != 1 && canattack)
            {
                fillimage[2] = 1;
                anim.SetInteger("Atk", 3);

                move.Targetpos = transform.position;
                RemovePointeratAttack();
            }

        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (move.Finishedmove && fillimage[3] != 1 && canattack)
            {
                fillimage[3] = 1;
                anim.SetInteger("Atk", 4);

                move.Targetpos = transform.position;
                RemovePointeratAttack();
            }

        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (move.Finishedmove && fillimage[4] != 1 &&canattack)
            {
                fillimage[4] = 1;
                anim.SetInteger("Atk", 6);

                move.Targetpos = transform.position;
                RemovePointeratAttack();
            }

        }

        else if (Input.GetMouseButton(1))
        {
            if (move.Finishedmove && fillimage[5] != 1 &&canattack)
            {
                fillimage[5] = 1;
                anim.SetInteger("Atk", 5);

                move.Targetpos = transform.position;
                RemovePointeratAttack();
            }
        }
        else
        {
            anim.SetInteger("Atk", 0);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 targetpos = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                targetpos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetpos - transform.position), 15f * Time.deltaTime);
            }
        }
    }

    private void checkfade()
    {
        if(fillimage[0]==1)
        {
            if(fadeandwait(fadeimage1, 0.8f))
            {
                fillimage[0] = 0;
            }
        }

        if (fillimage[1] == 1)
        {
            if (fadeandwait(fadeimage2, 0.6f))
            {
                fillimage[1] = 0;
            }
        }

        if (fillimage[2] == 1)
        {
            if (fadeandwait(fadeimage3, 0.1f))
            {
                fillimage[2] = 0;
            }
        }

        if (fillimage[3] == 1)
        {
            if (fadeandwait(fadeimage4, 0.2f))
            {
                fillimage[3] = 0;
            }
        }

        if (fillimage[4] == 1)
        {
            if (fadeandwait(fadeimage5, 0.3f))
            {
                fillimage[4] = 0;
            }
        }

        if (fillimage[5] == 1)
        {
            if (fadeandwait(fadeimage6 ,0.1f))
            {
                fillimage[5] = 0;
            }
        }

    }

    private bool fadeandwait(Image fadeimage, float fadetime)
    {
        bool faded = false;

        if(!fadeimage.gameObject.activeInHierarchy)
        {
            fadeimage.gameObject.SetActive(true);
            fadeimage.fillAmount = 1f;
        }
        fadeimage.fillAmount -= fadetime * Time.deltaTime; 
        if(fadeimage.fillAmount<=0)
        {
            fadeimage.gameObject.SetActive(false);
            faded = true;
        }
        return faded;
    }

    private void RemovePointeratAttack()
    {
        GameObject Pointer = GameObject.FindGameObjectWithTag("Cursor");
        if(Pointer)
        {
            Destroy(Pointer);
        }
    }
}
