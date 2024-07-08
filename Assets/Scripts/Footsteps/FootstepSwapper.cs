using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepsSwapper : MonoBehaviour
{
    //private TerrainChecker checker;
    private string currentLayer;
    private PlayerJump _playerJump;
    public FootstepCollection[] terrainFootstepCollection;
    private CharacterController _characterController;
    //private BasicMovement _movement;
    
    // Start is called before the first frame update
    void Start()
    {
        //checker = new TerrainChecker();
        _characterController = GetComponent<CharacterController>();
        _playerJump = GetComponent<PlayerJump>();
    }
    
    public void CheckLayers() {
        RaycastHit hit;
        if(Physics.Raycast(_characterController.transform.position + Vector3.up, Vector3.down, out hit, 2)){
            if(hit.collider.tag != null)
            {
                String tag = hit.collider.tag;
                if(currentLayer != tag){
                    currentLayer = tag;
                    foreach(FootstepCollection collection in terrainFootstepCollection){
                        if (currentLayer == collection.name){
                            _playerJump.SwapFootsteps(collection);
                        }
                    }
                }
            }
        }
    }
}
