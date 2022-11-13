using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static string userName;
    public static int bestScore = 0;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        LoadGame();
    }
    

    // Called after editing the input field of the main menu.
    public void SaveName(string input)
    {
        userName = input;
        Debug.Log(userName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Called after the game over.
    public static void CheckBestScore(int points)
    {
        if (points > bestScore)
        {
            bestScore = points;
        }
    }
    public void SaveGame()
    {
        // Fill a new object of type data with our game info.
        Data data = new Data();
        data.userName = userName;
        data.bestScore = bestScore;

        // Create a string in json format.
        string json = JsonUtility.ToJson(data);

        // Save the file.
        File.WriteAllText(Application.persistentDataPath + "SaveFile.json", json);

        Debug.Log("Game saved");
    }
    public void LoadGame()
    {
        // Look for the file path.
        string path = Application.persistentDataPath + "SaveFile.json";

        if (File.Exists(path))
        {
            // Read the file and save it in a string.
            string json = File.ReadAllText(path);

            // Deserialize that info.
            Data data = JsonUtility.FromJson<Data>(json);

            // Assign that info in out game.
            userName = data.userName;
            bestScore = data.bestScore;

            Debug.Log("Game loaded");
        }
    }

    [System.Serializable]
    public class Data
    {
        public string userName;
        public int bestScore;
    }
}
