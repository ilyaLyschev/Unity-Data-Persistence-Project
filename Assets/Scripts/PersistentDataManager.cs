using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager Instance;
    private string saveDataPath;

    public string currentPlayerName = null;
    public string bestPlayerName = null;
    public int bestScore = 0;

    private void Awake()
    {
        this.saveDataPath = Application.persistentDataPath + "saveData.json";

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        this.LoadData();
    }

    public void SaveData()
    {
        var data = new SaveData();
        data.bestPlayerName = this.bestPlayerName;
        data.bestScore = this.bestScore;

        File.WriteAllText(saveDataPath, JsonUtility.ToJson(data));
    }

    public void LoadData()
    {
        if (File.Exists(saveDataPath))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveDataPath));
            this.bestPlayerName = data.bestPlayerName;
            this.bestScore = data.bestScore;
        }
    }
}
