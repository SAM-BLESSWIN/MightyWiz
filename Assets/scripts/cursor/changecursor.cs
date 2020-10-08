using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecursor : MonoBehaviour
{
    public Texture2D texture;
    Vector2 hotspot = Vector2.zero;
    CursorMode cursorMode = CursorMode.ForceSoftware;
    void Update()
    {
        Cursor.SetCursor(texture,hotspot,cursorMode);    
    }
}
