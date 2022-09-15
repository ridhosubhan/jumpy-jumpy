using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPanel;
    public void PauseGame(){
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
    }

    public void RestartGame(){
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
