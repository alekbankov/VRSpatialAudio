using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private InputActionProperty walkButton;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float m_StepInterval;
    [SerializeField] public List<AudioClip> m_FootstepSounds = new List<AudioClip>();
    [SerializeField] public AudioClip m_jumpSound;
    [SerializeField] public AudioClip m_landSound;
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    private float speed = 3f;
    private AudioSource m_AudioSource;
    private FootstepsSwapper _footstepsSwapper;
    private float gravity = Physics.gravity.y;
    private string currentLayer;
    private Vector3 movement;
    private float m_StepCycle;
    private float m_NextStep;
    private bool m_PreviouslyGrounded = true;

    private void Awake()
    {
        _footstepsSwapper = GetComponent<FootstepsSwapper>();
        m_AudioSource = GetComponent<AudioSource>();
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle/2f;
    }
    
    public void PlayLandingSound() {
        _footstepsSwapper.CheckLayers();
        m_AudioSource.clip = m_landSound;
        m_AudioSource.Play();
        m_NextStep = m_StepCycle + .5f;
    }

    public void PlayJumpSound() {
        _footstepsSwapper.CheckLayers();
        m_AudioSource.clip = m_jumpSound;
        m_AudioSource.Play();
    }

    public void PlayFootStepAudio() {
        _footstepsSwapper.CheckLayers();
        int n = Random.Range(1, m_FootstepSounds.Count);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }

    private void Update()
    {
        
        if (jumpButton.action.WasPerformedThisFrame() && IsGrounded())
        {
            Jump();
            PlayJumpSound();
        }
        
        if(!m_PreviouslyGrounded && _characterController.isGrounded) PlayLandingSound();
        movement.y += gravity * Time.deltaTime;
        _characterController.Move(movement * Time.deltaTime);
        m_PreviouslyGrounded = _characterController.isGrounded;
    }

    private void FixedUpdate()
    {
    
        ProgressStepCycle(speed);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        
    }
    
    public bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }
    
    private void ProgressStepCycle(float speed)
    {
        if (_characterController.velocity.sqrMagnitude >  0 && isWalking())
        {
            m_StepCycle += (_characterController.velocity.magnitude + (speed*(isWalking() ? 1f : m_RunstepLenghten)))*
                           Time.fixedDeltaTime;
        }
    
        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }
    
        m_NextStep = m_StepCycle + m_StepInterval;
        
        PlayFootStepAudio();
    }

    private bool isWalking()
    {
        return walkButton.action.IsPressed() && IsGrounded();
    }
    
    public void SwapFootsteps(FootstepCollection collection) {
        m_FootstepSounds.Clear();
        for(int i = 0; i < collection.footstepSounds.Count; i++){
            m_FootstepSounds.Add(collection.footstepSounds[i]);
        }        
        m_jumpSound = collection.jumpSound;
        m_landSound = collection.landSound;
    } 
}
