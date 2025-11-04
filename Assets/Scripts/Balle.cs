using UnityEngine;

public class Balle : MonoBehaviour
{
    [SerializeField]
    private Arme armeDeLaBalle;

    public float Degat => armeDeLaBalle.Degat;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TuableParBalle ennemi))
        {
            Destroy(gameObject);
            ennemi.RecevoirBalle(this);
        }
    }
}
