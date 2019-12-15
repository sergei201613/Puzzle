using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonScript : MonoBehaviour
{
    public Sprite spriteWhenIsOpen;
    public Sprite spriteWhenIsClose;

    public Text numberTextComp;

    [SerializeField]
    private bool isOpen = false;
    [SerializeField]
    private int number = 1;

    private Image imgComp;
    private Button btn;

    private void Awake()
    {
        imgComp = GetComponent<Image>();
        btn = GetComponent<Button>();
    }

    private void Start()
    {
        SetIsOpen(isOpen);
        // Bad guy.
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void SetIsOpen(bool open)
    {
        isOpen = open;
        imgComp.sprite = open ? spriteWhenIsOpen : spriteWhenIsClose;
        btn.enabled = open;
        numberTextComp.text = open ? number.ToString() : " ";
    }

    public void SetNumber(int newNumber)
    {
        number = newNumber;
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(number);
        DataManager.instance.data.lastLevel = number;
    }
}
