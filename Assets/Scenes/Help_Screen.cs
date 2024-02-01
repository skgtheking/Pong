using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help_Screen : MonoBehaviour
{
    public GameObject helpPanel;
    public bool isPaused;
    void Start()
    {
        helpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            if(isPaused){
                ResumeGame();                
            }
            else {
                PauseGame();                
            }
            
        }
    }

    public void PauseGame(){
        helpPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        helpPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
