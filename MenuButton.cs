using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public string name;
    public bool isActive;

    private Image highlight;

    private void Start()
    {
        highlight = GetComponent<Image>();
        highlight.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            isActive = true;
            highlight.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            isActive = false;
            highlight.enabled = false;
        }
    }
}
