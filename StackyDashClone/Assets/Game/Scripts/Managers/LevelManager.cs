using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Array2D[] Levels; 
    public GameObject[] GridPrefabs;
    public GameObject BasePrefab;
    public Vector3 BaseScale;




        
    void Start()
    {
        
        BasePrefab.transform.localScale=BaseScale;
        Instantiate(BasePrefab,Vector3.zero+Vector3.down/10,Quaternion.identity);
        ArraySpawner.Spawn("Grid",GridPrefabs,Levels[0],1,Vector3.zero,transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
