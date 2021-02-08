using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool jeuEnPause = false;
    public GameObject menuDePause;
    private int menuSceneID = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jeuEnPause)
            {
                Resumer();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resumer()
    {
        menuDePause.SetActive(false);
        Time.timeScale = 1f;
        jeuEnPause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        menuDePause.SetActive(true);
        Time.timeScale = 0f;
        jeuEnPause = true;
    } 
    public void MenuPrincipale()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneID);
    }
    public void QuitterJeu()
    {
        Debug.Log("Jeu Quitter");
        Application.Quit();
    }

}
