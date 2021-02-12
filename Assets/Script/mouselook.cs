using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script qui gère toute les mouvements de la souris à l'extérieur des menus.
public class mouselook : MonoBehaviour
{
	//Déclaration des variables.
    public float sensibiliterDeSouris = 100f;
    public Transform corpJoueur;
    float rotationX = 0f;

    // Start est appeler lors du lancement du jeu.
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update est la méthode qui est appelée à chaque itération du jeu, plus communément appeler "frame".
    void Update()
    {
		//Détection des mouvements de la souris.
        float sourisH = Input.GetAxis("Mouse X") * sensibiliterDeSouris * Time.deltaTime;
        float sourisV = Input.GetAxis("Mouse Y") * sensibiliterDeSouris * Time.deltaTime;
		
        rotationX -= sourisV;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        corpJoueur.Rotate(Vector3.up * sourisH);
    }
}
