using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class CineMachineController : MonoBehaviour
{
 
 
    
    private GameObject tFollowTarget;
    private CinemachineVirtualCamera vcam;
    private  Transform cam;

    private void OnEnable() 
    {
        EventManager.OnGameStart.AddListener(()=> GetComponent<CinemachineVirtualCamera>().Follow = FindObjectOfType<StackController>().transform);
        EventManager.OnLevelEnd.AddListener(()=> GetComponent<CinemachineVirtualCamera>().enabled=false);    
    }

    private void OnDisable() 
    {
        EventManager.OnGameStart.RemoveListener(()=> GetComponent<CinemachineVirtualCamera>().Follow = FindObjectOfType<StackController>().transform);
        EventManager.OnLevelEnd.RemoveListener(()=> GetComponent<CinemachineVirtualCamera>().enabled=false);    
    }
    
 
    void Start()
    {
        
        
        
    }
 
   
}