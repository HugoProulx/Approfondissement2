using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Script du menu principale
public class ControleMenu : MonoBehaviour
{
	
	//Lors de l'appui du bouton "Jouer"
    public void CommencerJeux()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
	//Lors de l'appui du bouton "Quitter"
    public void QuitterJeux()
    {
        Application.Quit();
    }
}
