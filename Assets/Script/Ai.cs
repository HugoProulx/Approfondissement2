using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    public float vitesseDeMouvement = 3f;
    public float vitesseDeRotation = 2f;

    private bool marche = false;
    private bool tourneGaucheGlobal = false;
    private bool tourneDroiteGlobal = false;
    private bool entrainDeMarcher = false;




    public Transform verificateurDeMur;
    public float verificateurDistance = 0.4f;

    RaycastHit hit;
    public LayerMask murMask;
    bool touchMur;





    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(verificateurDeMur.transform.position, verificateurDeMur.transform.forward, out hit, 100f))
        {
            if (hit.transform.gameObject.layer == 8)
            {
                StartCoroutine(Tourne());

            }

        }


        if (!marche)
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
