using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    Conductor conductor;

    // Start is called before the first frame update
    void Start()
    {
        conductor = GetComponent<Conductor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!conductor.isConducting)
        {
            int songLength = conductor.ghostSong.Count;
        }
    }
}
