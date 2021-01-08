using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class Cam2 : MonoBehaviour
{
 
 
    
    private GameObject tFollowTarget;
    private CinemachineVirtualCamera vcam;
    private  Transform cam;

    private void OnEnable() 
    {
        EventManager.OnGameStart.AddListener(()=> GetComponent<CinemachineVirtualCamera>().Follow = FindObjectOfType<StackController>().transform);
        
    }
    private void OnDisable() 
    {
        EventManager.OnGameStart.RemoveListener(()=> GetComponent<CinemachineVirtualCamera>().Follow = FindObjectOfType<StackController>().transform);
        
    
    }
    void Start()
    {
        
        
        
    }
 
   
}