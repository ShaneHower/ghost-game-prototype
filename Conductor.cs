using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public bool isConducting;
    public bool isPlaying;
    public List<string> ghostSong;

    private Dictionary<string, Ghost> ghostDict = new Dictionary<string, Ghost>();
    private List<string> ghostIds;

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
        bool play = isConducting && !isPlaying;
        if(play)
        {
            StartCoroutine(playGhostSong());
        }
    }

    IEnumerator playGhostSong()
    {
        isPlaying = true;
        int randomNum = Random.Range(0, 4);
        string ghostId = ghostIds[randomNum];
        ghostSong.Add(ghostId);

        foreach (string id in ghostSong)
        {
            Ghost activeGhost = ghostDict[id];
            activeGhost.activate();
            yield return new WaitForSeconds(0.5f);
        }

        isConducting = false;
        isPlaying = false;
    }


}
