using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject menuOptions;
    public GameObject gameCoordinatorObject;

    private Dictionary<string, MenuButton> buttons = new Dictionary<string, MenuButton>();
    private GameCoordinator gameCoordinator;

    // Start is called before the first frame update
    void Start()
    {
        getButtons();
        gameCoordinator = gameCoordinatorObject.GetComponent<GameCoordinator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (buttons["start"].isActive)
        {
            activateStart();
        }
        else if (buttons["options"].isActive)
        {
            activateOption();
        }
        else if (buttons["exit"].isActive)
        {
            activateExit();
        }
    }
    

    void getButtons()
    {
        foreach(Transform child in menuOptions.transform)
        {
            if(child.tag == "button")
            {
                MenuButton button = child.GetComponent<MenuButton>();
                buttons[button.name] = button;
            }
        }
    }


    void activateStart()
    {
        if (Input.GetMouseButton(0))
        {
            gameCoordinator.activateGame = true;
        }
    }

    void activateOption()
    {
        if (Input.GetMouseButton(0))
        {
            return;
        }
    }

    void activateExit()
    {
        if (Input.GetMouseButton(0))
        {
            return;
        }
    }
}
