using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float _MovementSpeed = 5.0f;
    [SerializeField] private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * movY + transform.right * movX;
        _characterController.Move(dir * _MovementSpeed * Time.deltaTime);
    }
}
