using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public void Down()
    {
        GameManager.instance.MoveAllBoxesDown();
    }

    public void Up()
    {
        GameManager.instance.MoveAllBoxesUp();
    }

    public void Left()
    {
        GameManager.instance.MoveAllBoxesLeft();
    }
    
    public void Right()
    {
        GameManager.instance.MoveAllBoxesRight();
    }

    public void Menu()
    {
        MenuManager.instance.SwitchActivePanel(MenuManager.instance.stopMenuPanel);
    }
}
