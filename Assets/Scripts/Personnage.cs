using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Personnage : MonoBehaviour
{
    //Dernière valeur saisie dans les contrôles de déplacement
    private Vector2 controleDeplacement;

    [SerializeField, Tooltip("La vitesse du personnage en m/s")]
    private float vitesse;

    public void OnDeplacement(InputAction.CallbackContext context)
    {
        controleDeplacement = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 deplacement = controleDeplacement.y * transform.forward + controleDeplacement.x * transform.right;
        deplacement = vitesse * Time.deltaTime * deplacement.normalized;
        transform.position += deplacement;
        //Quaternium rotation = Quaternium.Euler(0.0f, controleRotation * Time.deltaTime * vitesseRotation, 0.0f);
    }
}
