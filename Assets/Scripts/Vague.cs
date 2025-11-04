using UnityEngine;

public class Vague : MonoBehaviour
{
    [field : SerializeField]
    public Ennemi[] ennemis { get; private set; }

    [field: SerializeField]
    public float delaiEntreSpawn { get; private set; }
}
