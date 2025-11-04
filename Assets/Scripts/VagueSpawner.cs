using System.Collections;
using UnityEngine;

public class VagueSpawner : MonoBehaviour
{
    [SerializeField]
    private Vague[] vagues;

    [SerializeField]
    private Transform pointDeSpawn;

    [SerializeField]
    private float delaiEntreVagues;

    private int vagueActuelle;

    private void Start()
    {
        StartCoroutine(CommencerVagues());
    }

    private IEnumerator CommencerVagues()
    {
        while (vagueActuelle < vagues.Length)
        {
            yield return StartCoroutine(LancerVague(vagues[vagueActuelle]));

            vagueActuelle++;

            yield return new WaitForSeconds(delaiEntreVagues);

            if (vagueActuelle == vagues.Length)
            {
                Debug.Log("Dernière vague");
            }

        }
    }

    private IEnumerator LancerVague(Vague vague)
    {
        foreach(Ennemi ennemi in vague.ennemis)
        {
            SpawnEnnemi(ennemi);
            yield return new WaitForSeconds(vague.delaiEntreSpawn);
        }   
    }

    private void SpawnEnnemi(Ennemi ennemi)
    {
        if (ennemi == null) return;
        Instantiate(ennemi, pointDeSpawn.position, pointDeSpawn.rotation);
    }
}

//Réferences:
//1. https://www.youtube.com/watch?v=duo45NjwZ78&t=308s
//2. https://cours-alexandre-ouellet.github.io/jeux-3d/programmer/coroutines/
