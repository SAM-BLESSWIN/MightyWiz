using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFX : MonoBehaviour
{
    public float timer = 1f;
    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
