using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundController : MonoBehaviour
{
    [SerializeField] private InputActionProperty moveButton;
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float m_StepInterval;
    private PlayerJump _playerJumpReference;
    private FootstepsSwapper footstepsSwapper;


    private bool _isAirborn = false;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerJumpReference = GetComponent<PlayerJump>();
        footstepsSwapper = GetComponent<FootstepsSwapper>();
    }

    private bool isMoving()
    {
        return moveButton.action.IsPressed() && _playerJumpReference.IsGrounded();
    }

    private void Update()
    {
        while (isMoving())
        {
            
        }
        
    }
}
