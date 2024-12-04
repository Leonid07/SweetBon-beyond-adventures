using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public static PanelManager InstancePanel { get; private set; }

    private void Awake()
    {
        if (InstancePanel != null && InstancePanel != this)
        {
            Destroy(gameObject);
        }
        else
        {
            InstancePanel = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ContinueLevel()
    {
        DataManager.InstanceData.count += 200;
        DataManager.InstanceData.SaveCount();
        DataManager.InstanceData.ApplyText();
    }
    public Button buttonPart_2;
    public Map mapPart_2;
    public GameObject level_33;
    public int priceLevel;

    public AudioSource mainMenu;
    public AudioSource gameMenu;

    private void Start()
    {
        buttonPart_2.onClick.AddListener(OpenLevelpart_2);
    }
    public void OpenLevelpart_2()
    {
        if (mapPart_2.isActive == 1)
        {
            level_33.SetActive(true);
            mainMenu.Stop();
            gameMenu.Play();
            return;
        }
        else
        {
            if (DataManager.InstanceData.count >= priceLevel)
            {
                DataManager.InstanceData.count -= priceLevel;
                DataManager.InstanceData.SaveCount();
                DataManager.InstanceData.ApplyText();
                mapPart_2.isActive++;
                mapPart_2.Check();
                mapPart_2.SaveActive();
                return;
            }
        }
    }
}
// 1.0775