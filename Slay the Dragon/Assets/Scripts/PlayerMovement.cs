using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float characterSpeed = 10f;

    private CharacterController character;
    private Vector3 moveVector;

    private void Awake() {
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
