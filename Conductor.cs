using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public bool isConducting;
    public int sequenceCounter = 0;

    private Dictionary<string, Ghost> ghostDict = new Dictionary<string, Ghost>();
    private List<string> ghostIds;
    private List<string> ghostSong;

    private int i = 1;
    private int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            Ghost ghost = child.GetComponent<Ghost>();
            ghostDict[ghost.id] = ghost;
        }

        ghostIds = new List<string>(this.ghostDict.Keys);
    }

    // Update is called once per frame
    void Update()
    {
        // We are looping by frame.  Originally I was looping by sequence but I think that may lead to bugs if the frames and loop get out of sync
        if(isConducting)
        {
            if(i < sequenceCounter)
            {
                randomNum = Random.Range(0, 4);
                string ghostId = ghostIds[randomNum];
                ghostSong.Add(ghostId);

                Ghost activeGhost = ghostDict[ghostId];
                activeGhost.activate();
                StartCoroutine(waiter());
                i++;
            }
            else
            {
                isConducting = false;
                sequenceCounter++;
            }
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.5f);
    }


}
