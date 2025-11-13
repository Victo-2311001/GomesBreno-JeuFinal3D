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
    private float vieMaximale;

    private float vie;

    [SerializeField]
    private float niveauPoule;

    [SerializeField]
    private float tempsAvantProchainTire;

    [SerializeField]
    private Transform pivotPoule;

    [SerializeField]
    private float vitesseRotation;

    [SerializeField]
    private Balle prefabBalle;

    [SerializeField]
    private float balleVitesse;

    [SerializeField]
    private List<Ennemi> cibles = new List<Ennemi>();

    [SerializeField]
    private GameObject arme1;

    [SerializeField]
    private Transform balleSpawnerArme1;

    [SerializeField]
    private GameObject arme2;

    private string armeActif = "Arme1";
    private Transform balleSpawnerActif;

    [SerializeField]
    private Transform balleSpawnerArme2;

    private Ennemi cibleActive;
    private bool peutTirer = true;

    private EtatPoule etatPrecedent;
    private EtatPoule prochainEtat;
    private bool executerEtat;


    private void Awake()
    {
        etatPrecedent = null;
        prochainEtat = new EtatPatrouille();
        executerEtat = true;

        arme2.SetActive(false);

        vie = vieMaximale;
    }
    void Update()
    {
        RegarderCible();


        if (cibleActive != null && peutTirer)
        {
            DemarrerTire();
        }
        
        ChangerArme();
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

    public void DemarrerTire()
    {
        StartCoroutine(Tirer());
    }

    private IEnumerator Tirer()
    {
        peutTirer = false;

        if (armeActif == "Arme1")
        {
            balleSpawnerActif = balleSpawnerArme1;
        }
        else
        {
            balleSpawnerActif = balleSpawnerArme2;
        }

        Balle balle = Instantiate(prefabBalle, balleSpawnerActif.position, balleSpawnerActif.rotation);
        balle.GetComponent<Rigidbody>().linearVelocity = balleSpawnerActif.forward * (balleVitesse * 2) * Time.deltaTime;


        yield return new WaitForSeconds(tempsAvantProchainTire);

        peutTirer = true;

        Destroy(balle, 2f);
    }

    private void ChangerArme()
    {
        if (niveauPoule == 3)
        {
            arme1.SetActive(false);
            arme2.SetActive(true);
            armeActif = "Arme2";
        }
    }
}

//Réferences:
//1. https://cours-alexandre-ouellet.github.io/jeux-3d/programmer/machine-etats/