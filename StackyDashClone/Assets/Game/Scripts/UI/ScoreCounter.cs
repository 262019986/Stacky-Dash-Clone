using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    
    public Text ScoreText;

    private void OnEnable() 
    {
        EventManager.OnStack.AddListener(UpdateScore); 
        EventManager.OnPass.AddListener(ResScore);   
    }

    private void OnDisable() 
    {
        EventManager.OnStack.RemoveListener(UpdateScore);    
        EventManager.OnPass.RemoveListener(ResScore);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "" + GameManager.Instance.Score;
    }
    

    private void UpdateScore()
    {
        GameManager.Instance.Score += 10;
    }  
    private void ResScore()
    {
        GameManager.Instance.Score = 0;
    }
    
}
