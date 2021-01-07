using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    private GameObject stack;

    

    private void OnEnable() 
    {
        EventManager.OnPass.AddListener(()=>  transform.parent = GameObject.FindWithTag("Player").transform);
    }

    // Update is called once per frame
    private void OnDisable() 
    {
        EventManager.OnPass.RemoveListener(()=>  transform.parent = GameObject.FindWithTag("Player").transform);
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
        transform.position=new Vector3(GameObject.FindWithTag("Player").transform.position.x , (GameManager.Instance.count+1)*0.1f + 5.05f , GameObject.FindWithTag("Player").transform.position.z);
        
    }


}
