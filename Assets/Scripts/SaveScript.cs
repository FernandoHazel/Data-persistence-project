using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    GameManager gameManager;
    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Save()
    {
        gameManager.SaveGame();
    }
}
