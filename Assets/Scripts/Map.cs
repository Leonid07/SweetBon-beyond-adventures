using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Button thisButton;
    public int isActive = 0;
    public string idActive = "thisButtnoLevel";

    [Header("Убрать блок")]
    public GameObject imageDown;
    public Image imageUp;
    public Sprite spriteUp;
    public TMP_Text textUp;
    private void Start()
    {
        thisButton = GetComponent<Button>();
        Check();
    }
    public void Check()
    {
        if (isActive == 0)
        {
            //thisButton.interactable = false;
        }
        else
        {
            //thisButton.interactable = true;
            if (imageDown != null)
            {
                imageDown.SetActive(false);
                imageUp.sprite = spriteUp;
                textUp.text = "Open";
                SaveActive();
            }
        }
    }
    public void SaveActive()
    {
        PlayerPrefs.SetInt(idActive, isActive);
        PlayerPrefs.Save();
    }
    public void LoadActive()
    {
        if (PlayerPrefs.HasKey(idActive))
        {
            isActive = PlayerPrefs.GetInt(idActive);
            Check();
        }
    }
}
