using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IInteractable interractable = other.GetComponent<IInteractable>();

        if (interractable != null)
        {
            interractable.Interact();
        }
    }
}
