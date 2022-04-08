using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform player; 

    public Texture2D defaultCursor;
    public Texture2D onClickCursor;
    public int xoffset;
    public int yoffset;

    private Vector2 cursorHotSpot = Vector2.zero;
    private CursorMode mode = CursorMode.ForceSoftware;
    
    void Start()
    {
        player = GetComponent<Transform>();
        Cursor.SetCursor(defaultCursor, cursorHotSpot, mode);
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 offSet = new Vector3(xoffset, yoffset, 0);
        player.position = mousePosition + offSet;

        if(Input.GetMouseButton(0))
        {
            Cursor.SetCursor(onClickCursor, cursorHotSpot, mode);
        }
        else
        {
            Cursor.SetCursor(defaultCursor, cursorHotSpot, mode);
        }
    }
}
