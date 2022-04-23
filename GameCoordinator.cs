using System.Collections;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject game;
    public int countDown;

    public bool activateGame;

    // Start is called before the first frame update
    void Start()
    {
        activateStartMenu();
        countDown = 2;
    }

    // Update is called once per frame
    void Update()
    {
        monitorStartMenuInput();

    }

    void activateStartMenu()
    {
        startMenu.SetActive(true);
        game.SetActive(false);
    }

    void monitorStartMenuInput()
    {

        if(activateGame)
        {
            startGame();
        }
        else
        {
            countDown = 2;
            activateStartMenu();
        }
    }

    void startGame()
    {
        startMenu.SetActive(false);
        game.SetActive(true);
        StartCoroutine(countDownLoop());
    }


    IEnumerator countDownLoop()
    {
        int i = 0;
        if (i <= countDown)
        {
            countDown -= i;
        }
       yield return new WaitForSeconds(0.5f);
    }

}
