using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public InputField playerName;
    public Text bestScoreInfo;

    private void Start()
    {
        bestScoreInfo.text = $"Best Score : {PersistentDataManager.Instance.bestPlayerName} : {PersistentDataManager.Instance.bestScore}";
        playerName.text = PersistentDataManager.Instance.bestPlayerName;        
    }

    public void StartGame()
    {
        PersistentDataManager.Instance.currentPlayerName = playerName.text.Trim();
        SceneManager.LoadScene(1);
    }

    public void ExitApp()
    {        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
