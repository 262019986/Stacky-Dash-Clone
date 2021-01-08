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
    public Array2D Level1_1;
    public Array2D Level1_2;
    public Array2D Level1_3;

    public int PlatformLength;

    
    


        private void Awake() 
        {
            

        }
        private void OnEnable() 
        {
            
        }

        private void OnDisable() 
        {
            
        }
    void Start()
    {   
       
       
        
//        BasePrefab.transform.localScale=BaseScale;
       // Instantiate(BasePrefab,Vector3.zero+Vector3.down/10,Quaternion.identity);
        ArraySpawner.Spawn("Grid1" , GridPrefabs , Level1[0] , 1 , Vector3.down * 0.1f , transform);
        ArraySpawner.Spawn("Grid2" , GridPrefabs , Level1[1] , 1 , Vector3.up * Length1 +  Vector3.forward * 15 , transform);
        ArraySpawner.Spawn("Grid2" , GridPrefabs , Level1[2] , 1 , Vector3.up * (Length1+ Length2)  +  Vector3.forward * 30 , transform);
        ArraySpawner.Spawn("Grid2" , GridPrefabs , Level1[3] , 1 , Vector3.up * (Length1+ Length2 )  +  Vector3.forward * 51.5f , transform);


       // ArraySpawner.Spawn("Grid",GridPrefabs,Levels[1],1,Vector3.zero,transform);
        Instantiate(CharacterPrefab,Vector3.zero,Quaternion.Euler(Vector3.right));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private float DetectAltitude(float Altitude , Array2D LevelSection )
    {
        int [,] values= LevelSection.GetCells();
        
        for (int i = 0; i< LevelSection.GetCells().Length; i++)
        {
            for(int j=0; j<LevelSection.GetCells().Length; j++)
            {
                if(values[i,j] == 1)
                {
                    Altitude ++;
                    PlatformLength = j;
                }
            }    
        }
        return Altitude * 0.1f ;
    }
}
