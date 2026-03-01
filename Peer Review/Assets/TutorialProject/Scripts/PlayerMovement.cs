using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody characterRB;
    private Vector3 movementInput;
    public Vector3 movementVector;
    [SerializeField] float movementSpeed = 5f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue value)
    {
        movementInput = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
        animator.SetBool("IsMoving", true);
    }
    private void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
        animator.SetBool("IsMoving", false);

    }

    private void OnAttack()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        bool isMoving = state.IsName("Move");
        bool isSwinging = state.IsName("Attack");

        if (!isMoving && !isSwinging)
        {
            animator.SetTrigger("isSwinging");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementInput != Vector3.zero)
        {
            movementVector = movementInput.x * transform.right + movementInput.z * transform.forward;
            movementVector.y = 0;


        }

        characterRB.velocity = movementVector * Time.fixedDeltaTime * movementSpeed;
    }
}
