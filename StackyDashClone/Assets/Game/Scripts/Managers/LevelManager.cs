using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Array2D[] Level1; 
    
    public GameObject[] GridPrefabs;
    public GameObject[] GridPrefabs2;

    public Vector3 BaseScale;
    public GameObject CharacterPrefab;
    public float Length1;
    public float Length2;
    public float Length3;
    


    
        
    void Start()
    {
        
//        BasePrefab.transform.localScale=BaseScale;
       // Instantiate(BasePrefab,Vector3.zero+Vector3.down/10,Quaternion.identity);
        ArraySpawner.Spawn("Grid1" , GridPrefabs , Level1[0] , 1 , Vector3.down * 0.1f , transform);
        ArraySpawner.Spawn("Grid2" , GridPrefabs , Level1[1] , 1 , Vector3.up * Length1 +  Vector3.forward * 15 , transform);
        ArraySpawner.Spawn("Grid2" , GridPrefabs , Level1[1] , 1 , Vector3.up * Length2 +  Vector3.forward * 15 , transform);

       // ArraySpawner.Spawn("Grid",GridPrefabs,Levels[1],1,Vector3.zero,transform);
        Instantiate(CharacterPrefab,Vector3.zero,Quaternion.Euler(Vector3.right));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
