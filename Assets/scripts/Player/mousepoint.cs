using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousepoint : MonoBehaviour
{
    public GameObject mousepointer;
    private GameObject instantmouse; //to store last insatntiate mousepointer
    private bool instant=false;
    private Animator anim;

    private void Awake()
    {
        anim =GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider is TerrainCollider)
                    {
                        Vector3 temp = hit.point;
                        temp.y = 0.1f;
                        if (!instant)             //used only for 1st click instantiation
                        {
                            instantmouse = Instantiate(mousepointer, temp, Quaternion.identity) as GameObject;
                            instant = true;
                        }
                        else                     //used for all the other instantiations
                        {
                            Destroy(instantmouse);     //destroy previous
                            instantmouse = Instantiate(mousepointer, temp, Quaternion.identity) as GameObject;   //creates new
                        }
                    }
                }
            }  
        }
    }
}
