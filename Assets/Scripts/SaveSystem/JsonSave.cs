using System.IO;
using UnityEngine;

public class JsonSave : MonoBehaviour
{
    public static JsonSave Instance;
    public GameData currentData = new GameData();
    private string path;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            path = Application.persistentDataPath + "/savefile.json";
            LoadGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SaveGame()
    {
        string json = JsonUtility.ToJson(currentData,true);
        File.WriteAllText(path, json);
        Debug.Log("Game saved to: " + path);
    }
    public void LoadGame()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            currentData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game loaded from: " + path);
        }
        else
        {
            currentData = new GameData(); 
            Debug.LogWarning("No save file found at: " + path);
            SaveGame();
        }
    }
    public void DeleteGame()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        currentData = new GameData();
        SaveGame();
        Debug.Log("Game data reset and new save file created at: " + path);
    }
}
