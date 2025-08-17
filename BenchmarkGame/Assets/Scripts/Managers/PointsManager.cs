using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerEconomyData
{
    public int points = 0;
}

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;
    private string savePath;

    public PlayerEconomyData data = new PlayerEconomyData();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Path.Combine(Application.persistentDataPath, "economy.json");
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int amount)
    {
        data.points += amount;
        SaveData();
    }

    public void SaveData()
    {
        File.WriteAllText(savePath, JsonUtility.ToJson(data, true));
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            data = JsonUtility.FromJson<PlayerEconomyData>(File.ReadAllText(savePath));
        }
        else
        {
            data = new PlayerEconomyData();
            SaveData();
        }
    }
}
