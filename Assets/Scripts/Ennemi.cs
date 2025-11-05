using System;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(Animator))]
public class Ennemi : MonoBehaviour, TuableParBalle
{

    private NavMeshAgent agent;

    private Animator controleurAnimation;

   
    [SerializeField, Tooltip("La vitesse de l'ennemi")]
    private float vitesse;

    [SerializeField, Tooltip("La destination que l'ennemi vas se déplacer")]
    private GameObject Destination;

    [SerializeField, Tooltip("Gère l'affichage de la vie du monstre.")]
    private BarreVie barreVie;

    [SerializeField, Tooltip("Vie maximale (et initiale) du monstre.")]
    private float vieMaximale;

    private float vie;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        controleurAnimation = GetComponent<Animator>();
        agent.speed = vitesse;
        agent.SetDestination(Destination.transform.position);
    }

    public void RecevoirBalle(Balle balle)
    {
        vie -= balle.Degat;
        //controleurAnimation = "take damage";
        barreVie.SetProgression(vie / vieMaximale);
        Debug.Log("Ayoye vie =" + vie);

        if (vie < 0)
        {
            Debug.Log("Ennemi mort");
            Destroy(gameObject);
        }
    }
}
