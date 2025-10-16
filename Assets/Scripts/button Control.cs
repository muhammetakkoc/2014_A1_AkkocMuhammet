using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonControl : MonoBehaviour
{

    public GameObject menuPanel;
    public GameObject instructionPanel;
    
    void Start()
    {
        menuPanel.SetActive(true);
        instructionPanel.SetActive(false);
    }
   public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ShowInstructionPanel()
    {
        instructionPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void Backbutton()
    {
        menuPanel.SetActive(true);
        instructionPanel.SetActive(false);
    }

    public void QuitGame()
    {
        
        Application.Quit();

    }

    public void MuteMusic()
    {
        AudioListener.volume = 0f;
    }
}
