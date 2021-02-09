using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ce script permet au ai de bouger dans le monde et de ne pas percuter constament les murs.
public class Ai : MonoBehaviour
{
	//Déclaration des variables
    public float vitesseDeMouvement = 3f; //Vitesse de mouvements des AI.
    public float vitesseDeRotation = 2f; //Vitesse de rotation des AI.

	//Ici, sont une multitude de variables permetant de savoir le status des AI et agir en conséquence.
    private bool marche = false; 
    private bool tourneGaucheGlobal = false;
    private bool tourneDroiteGlobal = false;
    private bool entrainDeMarcher = false;

	//Vérification de si l'AI touche un mur ou un sol, pour s'assurer que celui est un mouvement plus adéquat.
    public Transform verificateurDeMur;
    public float verificateurDistance = 0.4f;

    RaycastHit hit;
    public LayerMask murMask;
    bool touchMur;

    // Update est la méthode qui est appelée à chaque itération du jeu, plus communément appeler "frame".
    void Update()
    {
		//Vérificateur de collision avec mur, si-dessous, l'AI envoie des RayCast permetant de voir ce qu'il y a devant lui et de réagir en conséquence de.
        if (Physics.Raycast(verificateurDeMur.transform.position, verificateurDeMur.transform.forward, out hit, 100f))
        {
			//Dans mon cas, les murs font parti du layer numéro 8, donc si l'AI détect un mur devant lui, celui-ci va tourner.
            if (hit.transform.gameObject.layer == 8)
            {
				//StartCoroutine est l'équivalent d'un multitread.
                StartCoroutine(Tourne());

            }

        }

		//Selon les condtion suivant, l'AI va agir en conséquence,
        if (!marche) //Si l'AI n'est pas en marche, celui-ci va exécuter le code si-dessous.
        {
            //En utilisant le "StratCoroutine" cette technique est telle utiliser un multitread
            //Ainsi, les mouvements de l'AI vont être plus fuild et non une constante activation de ces mouvements.
            StartCoroutine(Marche());
        }
        if (tourneGaucheGlobal)
        {
            transform.Rotate(transform.up * Time.deltaTime * vitesseDeRotation);
        }
        if (tourneDroiteGlobal)
        {
            transform.Rotate(transform.up * Time.deltaTime * -vitesseDeRotation);
        }
        if (marche)
        {
            transform.position+=(transform.forward * Time.deltaTime * vitesseDeMouvement);
        }
    }

	//Méthode prenant en considération les mouvements des AIs, si ceux-ci ne font pas face à un mur.
    IEnumerator Marche()
    {
        //Création de variable, ces variables ont pour utiliter de créer des valeurs aléatoires pour rendre les mouvements du personnages plus agérable visuellement grâce à l'aspect aléatoire.
        int tempsDeRotation = Random.Range(1, 2);
        int tempsEntreRotation = Random.Range(3, 5);
        bool tourneGauche = (1 == Random.Range(0, 1));
        int tempsDAttente = Random.Range(1, 4);
        int tempsDeMarche = Random.Range(1, 5);

        //En mettant "marche" à vrai, aucun autre "Tread" de marche va recommencer.
        //Cela tant que marche va rester vrai
        marche = true;

        //yield return new WaitForSeconds permet de faire attendre le programme pour un temps donner.
        yield return new WaitForSeconds(tempsDAttente);
        entrainDeMarcher = true;
        yield return new WaitForSeconds(tempsDeMarche);
        entrainDeMarcher = false;
        yield return new WaitForSeconds(tempsEntreRotation);

        if (tourneGauche)
        {
            tourneGaucheGlobal = true;
            yield return new WaitForSeconds(tempsDeRotation);
            tourneGaucheGlobal = false;
        }
        else
        {
            tourneDroiteGlobal = true;
            yield return new WaitForSeconds(tempsDeRotation);
            tourneDroiteGlobal = false;
        }
        marche = false;

    }
	//Cette méthode permet aux AIs, lorsqu'ils détectent un mur de l'éviter de manière aléatoire.
    IEnumerator Tourne()
    {
        //Création de variable, ces variables ont pour utiliter de créer des valeurs aléatoires pour rendre les mouvements du personnages plus agérable visuellement grâce à l'aspect aléatoire.
        int tempsDeRotation = Random.Range(1, 2);
        bool tourneGauche = 1 == Random.Range(1, 2);

        //En mettant "marche" à vrai, aucun autre "Tread" de marche va recommencer.
        //Cela tant que marche va rester vrai
        marche = true;

        //yield return new WaitForSeconds permet de faire attendre le programme pour un temps donner.
        if (tourneGauche)
        {
            tourneGaucheGlobal = true;
            yield return new WaitForSeconds(tempsDeRotation);
            tourneGaucheGlobal = false;
        }
        else
        {
            tourneDroiteGlobal = true;
            yield return new WaitForSeconds(tempsDeRotation);
            tourneDroiteGlobal = false;
        }
        marche = false;

    }
}
