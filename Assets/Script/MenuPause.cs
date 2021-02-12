using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Script qui gère tous ce qui est relier au menu de pause du jeu.
public class MenuPause : MonoBehaviour
{
	//Déclaration des variables.
    public static bool jeuEnPause = false;
    public GameObject menuDePause;
    private int menuSceneID = 0;
    // Update est la méthode qui est appelée à chaque itération du jeu, plus communément appeler "frame".
    void Update()
    {
		//Vérificateur d'entrée de la touche "Échapp."(ESC)
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

	//Méthode exécuter lors de l'appui du bouton "Résumer".
    public void Resumer()
    {
        menuDePause.SetActive(false);
        Time.timeScale = 1f;
        jeuEnPause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	//Méthode exécuter lorsque le joueur appuie sur la touche "Échapp.".
    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menuDePause.SetActive(true);
        Time.timeScale = 0f;
        jeuEnPause = true;
    } 
	//Méthode exécuter lors de l'appui du bouton "Menu principale".
    public void MenuPrincipale()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneID);
    }
	//Méthpde exécuter lors de l'appui du bouton "Quitter".
    public void QuitterJeu()
    {
        Debug.Log("Jeu Quitter");
        Application.Quit();
    }

}
