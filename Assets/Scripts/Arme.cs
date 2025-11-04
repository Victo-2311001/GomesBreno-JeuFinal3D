using UnityEngine;
using UnityEngine.InputSystem;

public class Arme : MonoBehaviour
{
    [SerializeField]
    private Transform balleSpawner;

    [SerializeField]
    private GameObject ballePrefab;

    [SerializeField]
    private float balleVitesse;

    [SerializeField]
    private float degat;
    public float Degat => degat;

    private bool tirer = false;

    public void OnTirer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            tirer = true;
        }
    }

    void Update()
    {
        if (tirer)
        {
            tirer = false;

            var balle = Instantiate(ballePrefab, balleSpawner.position, balleSpawner.rotation);
            balle.GetComponent<Rigidbody>().linearVelocity = balleSpawner.forward * (balleVitesse * 2) * Time.deltaTime;

            Debug.Log("FEU");

            //Détruire la balle après 3 secondes
            Destroy(balle, 2f);
        }

    }
}

//Source:
//1. https://youtu.be/EwiUomzehKU?si=UsK2-PSOql0dr8jE
