using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJoueur : MonoBehaviour
{

    [SerializeField]
    private Personnage joueur;

    [SerializeField]
    private float sensibilite = 2f;

    float cameraVerticalRotation = 0f;

    void Update()
    {
        //Bloquer le curseur au centre de l'écran
        Cursor.lockState = CursorLockMode.Locked;

        BougerCamera();
    }

    void BougerCamera()
    {
        //Lire les mouvements du curseur
        float inputX = Input.GetAxis("Mouse X") * sensibilite;
        float inputY = Input.GetAxis("Mouse Y") * sensibilite;

        // Rotate the Camera around its local X axis
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //Tourner le joueur avec la caméra
        joueur.transform.Rotate(Vector3.up * inputX);
    }
}

//Réferences:
//1. https://stackoverflow.com/questions/71972222/fps-unity-camera
//2. https://www.reddit.com/r/Unity3D/comments/vljtba/i_need_help_with_a_first_person_cameramouse/
//3. https://www.youtube.com/watch?v=5Rq8A4H6Nzw&t=249s

//Incrémentations:
//Sachant que j'ai utilisé la réference 1 pour m'aider à faire la caméra, j'ai du changer dans mes configurations dans unity 
//le Active Input Handling dans Project Settings/ Player/ Other Settings, de Input System Package à Both.
//(J'ai utilisé ChatGPT pour compreendre pourquoi j'avais une erreur. Raison: Parce que sans mettre en Both, UnityEngine.Input ne fonctionnais pas.)
