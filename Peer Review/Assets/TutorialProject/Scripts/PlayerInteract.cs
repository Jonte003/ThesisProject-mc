using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class PlayerInteract : MonoBehaviour
{
    private Camera camera;
    [SerializeField] float InteractRange;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }


    void OnInteract()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, InteractRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {

                Debug.Log("target is interactable");

                interactable.Interact();

            }
        }


    }
}
