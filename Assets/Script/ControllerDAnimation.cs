using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDAnimation : MonoBehaviour
{
    private Animator animator;
	
	
    // Start est appeler lors du lancement du jeu.
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update est la méthode qui est appelée à chaque itération du jeu, plus communément appeler "frame".
    void Update()
    {
		//Toute le code si-dessous prermet au joueur d'avoir des animations, lors de ces actions.
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") )
            {
            animator.SetBool("marche", true);
        }
        else
        {
            animator.SetBool("marche", false);
        }
        
    }
}
