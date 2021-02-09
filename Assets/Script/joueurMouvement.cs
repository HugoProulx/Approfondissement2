using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueurMouvement : MonoBehaviour
{
	//Déclaration des variables pour tout ce qui influence le mouvement du personnage.
    public float vitesse = 12f; //La vitesse à laquelle le personnage va pourvoir ce déplacé.
    public float graviter = -20f; //La graviter est la force qui est appliquée au joueur lorsque celui-ci ne touche pas le sol.
    public float sautPuissance = 3f; //La puissance de saut est la force avec laquelle le joueur peut sauter.
    Vector3 velocity;

	//Ici, nous vérifions la distance entre le sol et le joueur, pour ainsi nous assurer que la force qui est appliquée au joueur, lorsque celui-ci touche le sol, soit réinitialisée.
    public Transform verificateurDeSol;
    public float verificateurDistance = 0.4f;
    public LayerMask solMask; //Le layer mask est ce qui permet de différencier les différentes partie du jeu. 
    bool touchSol;
	

	//Cette variable est la variable qui exécute les mouvements pour faire bouger le joueur.
    public CharacterController controller;

        // Update est la méthode qui est appelée à chaque itération du jeu, plus communément appeler "frame".
        void Update()
    {

		//Vérificateur de toucher au sol
        touchSol = Physics.CheckSphere(verificateurDeSol.position, verificateurDistance, solMask);
		
		//Réinisialisateur de vélocité en y, lorsque le joueur touche le sol.
        if (touchSol && velocity.y < 0)
		{
            velocity.y = -1f; 
		}
		
		//Gestion des entrées ('W', 'A', 'S' et 'D')
		//Ces entrées sont des touches pré déterminées dans les paramètres de Unity.
        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical");

		//Cette variable permet d'exécuter le mouvement pour sur les personnages.
        Vector3 mouvement = transform.right * h + transform.forward * v;
		
		//Ici, à l'aide du "CharacterController", nous faisons bouger le joueur. (Selon les entrées précédentes.)
        controller.Move(mouvement * vitesse * Time.deltaTime);

		
		//Vérificateur d'entrée permettant au joueur de sauter dans les aires, si les conditions sont remplies.
        if (Input.GetButtonDown("Jump") && touchSol)
        {
            velocity.y = Mathf.Sqrt(sautPuissance * -2f * graviter);
        }


		//Cette méthode permet d'appliquer une force au joueur de manière plus réaliste.
        velocity.y += graviter * Time.deltaTime;

		//L'application de ce mouvement sur le joueur.
        controller.Move(velocity * Time.deltaTime);
        
         


    }
}
