using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// Le script qui va gérer la pouleTourelle
/// </summary>
public class PouleTourelle : MonoBehaviour
{
    [SerializeField]
    private float vie;

    [SerializeField]
    private float tempsAvantProchainTire;

    [SerializeField]
    private Transform pivotPoule;

    [SerializeField]
    private float vitesseRotation;

    [SerializeField]
    private Transform balleSpawner;

    [SerializeField]
    private Balle prefabBalle;

    [SerializeField]
    private float balleVitesse;

    [SerializeField]
    private List<Ennemi> cibles = new List<Ennemi>();

    private Ennemi cibleActive;
    private bool peutTirer = true;

    void Update()
    {
        RegarderCible();


        if (cibleActive != null && peutTirer)
        {
            StartCoroutine(TirerEnBoucle());
        }
    }

    private Ennemi PrendreProchaineCible()
    {
        if (cibles.Count > 0)
        {
            Ennemi cible = cibles[0];
            cibles.RemoveAt(0);
            return cible;
        }
        return null;

    }

    private void RegarderCible()
    {
        if (cibleActive == null)
        {
            cibleActive = PrendreProchaineCible();
        }
        if (cibleActive)
        {
            Vector3 direction = cibleActive.transform.position - pivotPoule.position;
            quaternion lookRotation = Quaternion.LookRotation(direction);

            Vector3 cibleRotation = Quaternion.Slerp(pivotPoule.rotation, lookRotation, vitesseRotation * Time.deltaTime).eulerAngles;
            pivotPoule.rotation = Quaternion.Euler(Vector3.Scale(cibleRotation, pivotPoule.up));
        }
    }

    public void TirerEnBoucle()
    {
        peutTirer = false;

        Tirer();

        StartCoroutine(Tirer());

        peutTirer = true;
    }

    private IEnumerator Tirer()
    {
        Balle balle = Instantiate(prefabBalle, balleSpawner.position, balleSpawner.rotation);
        balle.GetComponent<Rigidbody>().linearVelocity = balleSpawner.forward * (balleVitesse * 2) * Time.deltaTime;
        yield return new WaitForSeconds(tempsAvantProchainTire);

        Destroy(balle, 2f);
    }
}

//Réferences:
//1. https://cours-alexandre-ouellet.github.io/jeux-3d/programmer/machine-etats/