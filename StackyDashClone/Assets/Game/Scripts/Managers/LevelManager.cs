using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Array2D[] Levels; 
    public GameObject[] GridPrefabs;

        
    void Start()
    {
        ArraySpawner.Spawn("Grid",GridPrefabs,Levels[0],1,Vector3.zero,transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
