using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class CineMachineController : MonoBehaviour
{
 
 
    
    private GameObject tFollowTarget;
    private CinemachineStateDrivenCamera StateDrivenCamera;
    private CinemachineStateDrivenCamera stateDrivenCamera
    {
        get
        {
            if(StateDrivenCamera == null)
            {
                StateDrivenCamera = GetComponent<CinemachineStateDrivenCamera>();
            }
            return StateDrivenCamera;
        }
    }

    private void OnEnable() 
    {
        EventManager.OnGameStart.AddListener(SetStateDrivenCam );
         
        
    }

    private void OnDisable() 
    {
        EventManager.OnGameStart.RemoveListener(SetStateDrivenCam); 
           
    }
    
 
    void Start()
    {
        
        
        
    }

    private void SetStateDrivenCam()
    {
        stateDrivenCamera.Follow = FindObjectOfType<StackController>().transform;
        stateDrivenCamera.m_AnimatedTarget = FindObjectOfType<Character>().GetComponent<Animator>();
    }
 
   
}