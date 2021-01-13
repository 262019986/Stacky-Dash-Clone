using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class CineMachineController : MonoBehaviour
{
 
 
    
    private GameObject tFollowTarget;
    public CinemachineVirtualCamera vCam1;
    public CinemachineVirtualCamera vCam2;
    

    private void OnEnable() 
    {
        EventManager.OnGameStart.AddListener(SetVirtualCam );
        EventManager.OnLevelEnd.AddListener(()=> vCam1.enabled=false);
         
        
    }

    private void OnDisable() 
    {
        EventManager.OnGameStart.RemoveListener(SetVirtualCam); 
        EventManager.OnLevelEnd.RemoveListener(()=> vCam1.enabled=false);
           
    }
    
 
    void Start()
    {
        
        
        
    }

    private void SetVirtualCam()
    {
        vCam1.Follow = FindObjectOfType<Character>().transform;
        vCam2.Follow = FindObjectOfType<Character>().transform;
        
    }
 
   
}