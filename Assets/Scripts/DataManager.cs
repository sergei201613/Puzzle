using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string path;

    [Serializable]
    public class Data
    {
        public List<bool> levelsOpennes = new List<bool>();
        public int lastLevel = 1;
    }
    public Data data;

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
        DontDestroyOnLoad(this.gameObject);
        path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (File.Exists(path))
        {
            data = LoadJSON.LoadObject<Data>(path);
        }
    }

    private void OnApplicationQuit()
    {
        SaveJSON.SaveObject(data, path);
    }
}
