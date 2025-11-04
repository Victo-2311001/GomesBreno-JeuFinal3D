using System;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(Animator))]
public class Ennemi : MonoBehaviour, TuableParBalle
{

    private NavMeshAgent agent;

    private Animator controleurAnimation;

    [SerializeField, Tooltip("La vie de l'ennemi")]    
    private float vie;

    [SerializeField, Tooltip("La vitesse de l'ennemi")]
    private float vitesse;

    [SerializeField, Tooltip("La destination que l'ennemi vas se déplacer")]
    private GameObject Destination;

   

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        agent.speed = vitesse;
        agent.SetDestination(Destination.transform.position);
    }

    public void RecevoirBalle(Balle balle)
    {
        vie -= balle.Degat;
        Debug.Log("Ayoye vie =" + vie);

        if (vie < 0)
        {
            Debug.Log("Ennemi mort");
            Destroy(gameObject);
        }
    }
}
