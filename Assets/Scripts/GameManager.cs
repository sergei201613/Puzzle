using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Box> boxes = new List<Box>();

    public bool boxControllEnabled = true;

    public AudioSource winSound;

    void Awake()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        #endregion

    }

    private void Start()
    {
        MenuManager.instance.SwitchActivePanel(null);
    }

    public void MoveAllBoxesUp()
    {
        if (boxControllEnabled)
        {
            foreach (Box i in boxes)
            {
                i.MoveBox(Vector2.up);
            }
        }
    }

    public void MoveAllBoxesDown()
    {
        if (boxControllEnabled)
        {
            foreach (Box i in boxes)
            {
                i.MoveBox(Vector2.down);
            }
        }
    }

    public void MoveAllBoxesLeft()
    {
        if (boxControllEnabled)
        {
            foreach (Box i in boxes)
            {
                i.MoveBox(Vector2.left);
            }
        }
    }

    public void MoveAllBoxesRight()
    {
        if (boxControllEnabled)
        {
            foreach (Box i in boxes)
            {
                i.MoveBox(Vector2.right);
            }
        }
    }

    public IEnumerator PlayerWon()
    {
        print("Player is won.");
        int currentLevel = DataManager.instance.data.lastLevel;
        if (currentLevel < DataManager.instance.data.levelsOpennes.Count)
        {
            DataManager.instance.data.levelsOpennes[currentLevel] = true;
        }
        winSound.Play();

        yield return new WaitForSeconds(.5f);
        boxControllEnabled = false;
        MenuManager.instance.OpenWinPanel();
    }
}