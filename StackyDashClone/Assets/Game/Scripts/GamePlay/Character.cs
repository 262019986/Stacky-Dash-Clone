using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    private GameObject stack;

    

    private void OnEnable() 
    {
        
    }

    // Update is called once per frame
    private void OnDisable() 
    {
        
    }

    private void Start() 
    {
        
        
        transform.parent = GameObject.FindWithTag("Player").transform;
        

    }
    private void Update() 
    {
        
        AdjustCharaterPos();
    }

    private void FinishSection()
    {

    }

    public void AdjustCharaterPos()
    {
        transform.position=new Vector3(GameObject.FindWithTag("Player").transform.position.x , (GameManager.Instance.CharacterCount)*0.1f + 5.05f  , GameObject.FindWithTag("Player").transform.position.z);
        
    }


}
