using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string scoreName;
    public int highestScore;
    public string currentName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScoreName();
    }

    public void NewScoreName(string name, int score)
    {
        ScoreManager.Instance.scoreName = name;
        ScoreManager.Instance.highestScore = score;
    }

    [System.Serializable]
    class SaveData
    {
        public string scoreName;
        public int highestScore;
    }

    public void SaveScoreName()
    {
        SaveData data = new SaveData();
        data.scoreName = scoreName;
        data.highestScore = highestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadScoreName()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            scoreName = data.scoreName;
            highestScore = data.highestScore;
        }
    }

    public bool CheckScore(int score)
    {
        if(score > highestScore)
        {
            highestScore = score;
            scoreName = currentName;
            NewScoreName(currentName, score);
            SaveScoreName();
            return true;
        }
        return false;
    }

    public void SetCurrentName(string name)
    {
        currentName = name;
    }
}
