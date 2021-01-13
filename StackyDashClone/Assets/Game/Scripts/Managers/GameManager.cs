using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float count;
    public float CharacterCount;

    public int Score;
    public int CurrentLevelIndex;
    public int NextLevelIndex;
    public float passTime=1.5f;
    private void Awake() 
    {
        

    }
    private void Start() 
    {
        EventManager.OnGameStart.Invoke();
    }   

   
}
