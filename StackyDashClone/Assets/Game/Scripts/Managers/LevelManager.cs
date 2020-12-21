using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Array2D[] Levels; 
    public GameObject[] GridPrefabs;
    public Vector3 BaseScale;
    public GameObject CharacterPrefab;




        
    void Start()
    {
        
//        BasePrefab.transform.localScale=BaseScale;
       // Instantiate(BasePrefab,Vector3.zero+Vector3.down/10,Quaternion.identity);
        ArraySpawner.Spawn("Grid1",GridPrefabs,Levels[0],1,Vector3.down*0.1f,transform);
        ArraySpawner.Spawn("Grid",GridPrefabs,Levels[1],1,Vector3.zero,transform);
        Instantiate(CharacterPrefab,Vector3.zero,Quaternion.Euler(Vector3.right));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
