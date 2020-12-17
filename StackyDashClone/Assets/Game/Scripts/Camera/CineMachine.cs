using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class CineMachine : MonoBehaviour
{
 
 
    
    private GameObject tFollowTarget;
    private CinemachineVirtualCamera vcam;
   private  Transform cam;
 
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        tFollowTarget = GameObject.FindWithTag("Player");
         cam=vcam.Follow; 
         cam=tFollowTarget.GetComponent<Transform>();
        
    }
 
   
}