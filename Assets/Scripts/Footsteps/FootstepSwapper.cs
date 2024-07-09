using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootstepsSwapper : MonoBehaviour
{
    private TerrainChecker checker;
    private string currentLayer;
    private PlayerJump _playerJump;
    public FootstepCollection[] terrainFootstepCollection;
    private CharacterController _characterController;
    //private BasicMovement _movement;
    
    // Start is called before the first frame update
    void Start()
    {
        checker = new TerrainChecker();
        _characterController = GetComponent<CharacterController>();
        _playerJump = GetComponent<PlayerJump>();
    }
    
    public void CheckLayers() {
        RaycastHit hit;
        if(Physics.Raycast(_characterController.transform.position + Vector3.up, Vector3.down, out hit, 2)){
            if(hit.transform.GetComponent<Terrain>() != null)
            {
                Terrain t = hit.transform.GetComponent<Terrain>();
                if(currentLayer != checker.GetLayerName(_characterController.transform.position, t)){
                    currentLayer = checker.GetLayerName(_characterController.transform.position, t);
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
