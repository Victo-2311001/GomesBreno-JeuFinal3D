using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private bool estOuverte = false;
    public void OnToggleFenetre(InputAction.CallbackContext context)
    {
        estOuverte = !estOuverte;

        if (estOuverte == true)
        {
            gameObject.SetActive(true);
        }
            

        if(estOuverte == false)
        {
            gameObject.SetActive(false);
        }
        
    }
}
