using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager InstanceData { get; private set; }

    private void Awake()
    {
        if (InstanceData != null && InstanceData != this)
        {
            Destroy(gameObject);
        }
        else
        {
            InstanceData = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int count;
    public string idCount = "coin";
    public TMP_Text text;
    public Map[] map;

    private void Start()
    {
        LoadCount();
        ApplyText();
        foreach (Map map in map)
        {
            map.LoadActive();
        }
    }

    public void SaveCount()
    {
        PlayerPrefs.SetInt(idCount, count);
        PlayerPrefs.Save();
    }
    public void LoadCount()
    {
        if (PlayerPrefs.HasKey(idCount))
        {
            count = PlayerPrefs.GetInt(idCount);
            ApplyText();
        }
    }
    public void ApplyText()
    {
        text.text = count.ToString();
    }
}