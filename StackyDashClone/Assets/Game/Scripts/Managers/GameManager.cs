using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float count;
    public float CharacterCount;
   
    private void Awake() 
    {
        

    }
    private void Start() 
    {
        EventManager.OnGameStart.Invoke();
    }   

   
}
