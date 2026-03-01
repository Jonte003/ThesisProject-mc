using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationArmorStand : MonoBehaviour , IInteractable
{
    // Start is called before the first frame update
    Animator animator;

    public void Interact()
    {
        animator.SetTrigger("Interact");
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
