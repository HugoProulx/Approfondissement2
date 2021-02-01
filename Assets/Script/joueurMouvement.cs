using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueurMouvement : MonoBehaviour
{
    public float vitesse = 12f;
    public float graviter = -20f;
    public float sautPuissance = 3f;


    public Transform verificateurDeSol;
    public float verificateurDistance = 0.4f;
    public LayerMask solMask;

    Vector3 velocity;
    bool touchSol;

    public CharacterController controller;

    // Update is called once per frame
    void Update()
    {

        touchSol = Physics.CheckSphere(verificateurDeSol.position, verificateurDistance, solMask);

        if (touchSol && velocity.y < 0)
            velocity.y = -1f;


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 mouvement = transform.right * h + transform.forward * v;

        controller.Move(mouvement * vitesse * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && touchSol)
        {
            velocity.y = Mathf.Sqrt(sautPuissance * -2f * graviter);
        }

        velocity.y += graviter * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
         


    }
}
