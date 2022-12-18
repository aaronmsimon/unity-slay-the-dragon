using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private float characterSpeed = 10f;

    private CharacterController character;
    private InputAction movement;

    private Vector3 moveVector;

    private void Awake() {
        var inGameActionMap = playerControls.FindActionMap("InGame");

        movement = inGameActionMap.FindAction("Move");
        movement.performed += OnMovementChanged;
        movement.canceled += OnMovementChanged;
        movement.Enable();

        character = GetComponent<CharacterController>();
    }
    
    private void FixedUpdate() {
        character.Move(moveVector * characterSpeed * Time.fixedDeltaTime);
    }

    public void OnMovementChanged(InputAction.CallbackContext context) {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x,0,direction.y);
    }
}
