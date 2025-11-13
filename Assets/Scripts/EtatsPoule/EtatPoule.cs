using UnityEngine;

public abstract class EtatPoule : MonoBehaviour
{
    public virtual void EntrerEtat(PouleTourelle poule)
    {
        Debug.Log($"Poule entre dans l'état {this.GetType().Name}");
    }

    public abstract EtatPoule ExecuterEtat(PouleTourelle poule);

    // Update is called once per frame
    public virtual void SortirEtat(PouleTourelle poule)
    {
        Debug.Log($"Poule sort de l'état {this.GetType().Name}");
    }
}
//Réference: https://github.com/Cours-Alexandre-Ouellet/demo-rpg
