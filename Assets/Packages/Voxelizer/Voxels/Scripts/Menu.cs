using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SFB;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject Voxelization_Vector;
    

    public void Play()
    {
        


        SceneManager.LoadScene(1);
        //menu.SetActive(false);
        //Voxelization_Start.SetActive(true);       
    }
    public void Choice()
    {        
        SceneManager.LoadScene(2);       
    }
    public void Choice_1()
    {
        SceneManager.LoadScene(3);
        
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    void Update()
    {        
        Cursor.lockState = CursorLockMode.None;
        if (Input.GetKey("escape")) Application.Quit();
    }    
}
