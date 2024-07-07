using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepsSwapper : MonoBehaviour
{
    //private TerrainChecker checker;
    private string currentLayer;
    public FootstepCollection[] terrainFootstepCollection;
    [SerializeField] private List<AudioClip> m_FootstepSounds = new List<AudioClip>();
    [SerializeField] private AudioClip m_jumpSound;
    [SerializeField] private AudioClip m_landSound;
    private AudioSource m_AudioSource;
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private float m_StepInterval;
    private float m_StepCycle;
    private float m_NextStep;
    //private BasicMovement _movement;
    
    // Start is called before the first frame update
    void Start()
    {
        //checker = new TerrainChecker();
        m_AudioSource = GetComponent<AudioSource>();
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle/2f;
        //_movement = GetComponent<BasicMovement>();
    }

    private void Update()
    {
        // while (_movement.isMoving())
        // {
        //     PlayFootStepAudio();
        // }
    }

    private void FixedUpdate()
    {
        // //jump and land occasion
        // if (_movement.isJumping)
        // {
        //     PlayJumpSound();
        //     if (_movement.IsGrounded())
        //     {
        //         PlayLandingSound();
        //     }
        // }
    }

    public void PlayLandingSound() {
        CheckLayers();
        m_AudioSource.clip = m_landSound;
        m_AudioSource.PlayOneShot(m_landSound);
    }

    public void PlayJumpSound() {
        CheckLayers();
        m_AudioSource.clip = m_jumpSound;
        m_AudioSource.Play();
    }

    public void PlayFootStepAudio() {
        CheckLayers();
        // if(!_movement.IsGrounded()){
        //     return;
        // }
        int n = Random.Range(1, m_FootstepSounds.Count);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }

    private void SwapFootsteps(FootstepCollection collection) {
        m_FootstepSounds.Clear();
        for(int i = 0; i < collection.footstepSounds.Count; i++){
            m_FootstepSounds.Add(collection.footstepSounds[i]);
        }        
        m_jumpSound = collection.jumpSound;
        m_landSound = collection.landSound;
    } 

    private void CheckLayers() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up + Vector3.up, Vector3.down, out hit, 5)){
            if(hit.collider.tag != null)
            {
                String tag = hit.collider.tag;
                if(currentLayer != tag){
                    currentLayer = tag;
                    foreach(FootstepCollection collection in terrainFootstepCollection){
                        if (currentLayer == collection.name){
                            SwapFootsteps(collection);
                        }
                    }
                }
            }
        }
    }
    
    // private void ProgressStepCycle(float speed)
    // {
    //     if (_richard.velocity.sqrMagnitude > 0)
    //     {
    //         m_StepCycle += (_richard.velocity.magnitude + (speed*((this.speed > 0) ? 1f : m_RunstepLenghten)))*
    //                        Time.fixedDeltaTime;
    //     }
    //
    //     if (!(m_StepCycle > m_NextStep))
    //     {
    //         return;
    //     }
    //
    //     m_NextStep = m_StepCycle + m_StepInterval;
    //     
    // }
}
