using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameOver : MonoBehaviour
{
    public Text GameOverText;
    public Button RestartButton;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        RestartButton.onClick.AddListener(RestartGame);

        if (GameOverText == null)
        {
            Debug.LogError("gameOverText is not assigned!");
        }

        if (RestartButton == null)
        {
            Debug.LogError("restartButton is not assigned!");
        }
        
    }

    public void TriggerGameOver() 
    {
        Debug.Log("Setting gameOverText and restartButton active");
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
