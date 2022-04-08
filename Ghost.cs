using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    // Game objects
    Image image;
    Conductor conductor;
    AudioSource audio;

    // Public vars
    public string id;
    public Sprite defaultSprite;
    public Sprite onClickSprite;
    public byte red;
    public byte green;
    public byte blue;

    private bool ghostCollision;

    void Start()
    {
        // set default color to white
        image = GetComponent<Image>();
        conductor = GetComponentInParent<Conductor>();
        audio = GetComponent<AudioSource>();
        setDefaults();
    }

    private void FixedUpdate()
    {
        // if conductor isn't conducting and the player cursor is over the ghost
        bool allowPlay = !conductor.isConducting && ghostCollision;

        if (Input.GetMouseButton(0) && allowPlay)
        {
            activate();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ghostCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ghostCollision = false;
    }

    public void activate()
    {
        image.sprite = onClickSprite;
        image.color = new Color32(255, 255, 255, 255);
        audio.Play();
        StartCoroutine(waiter());
    }

    private void setDefaults()
    {
        image.sprite = defaultSprite;
        image.color = new Color32(red, green, blue, 255);
    }
    
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.25f);
        setDefaults();
    }
}
