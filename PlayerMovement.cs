using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    [SerializeField]
    private float forwardmoveSpeed = 7.5f;
    [SerializeField]
    private float backwardmoveSpeed = 3.5f;
    [SerializeField]
    private float turnSpeed = 5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? forwardmoveSpeed : backwardmoveSpeed;

            characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }

    }
}
