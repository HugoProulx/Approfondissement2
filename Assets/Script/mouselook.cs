using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float sensibiliterDeSouris = 100f;
    public Transform corpJoueur;
    float rotationX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float sourisH = Input.GetAxis("Mouse X") * sensibiliterDeSouris * Time.deltaTime;
        float sourisV = Input.GetAxis("Mouse Y") * sensibiliterDeSouris * Time.deltaTime;

        rotationX -= sourisV;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        corpJoueur.Rotate(Vector3.up * sourisH);
    }
}
