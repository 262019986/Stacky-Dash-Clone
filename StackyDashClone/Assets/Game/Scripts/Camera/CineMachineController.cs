using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class CineMachineController : MonoBehaviour
{
 
 
    
    private GameObject tFollowTarget;
    private CinemachineVirtualCamera vcam;
    private  Transform cam;
 
    void Start()
    {
        
        GetComponent<CinemachineVirtualCamera>().Follow=GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<CinemachineVirtualCamera>().LookAt=GameObject.FindGameObjectWithTag("Player").transform;
    }
 
   
}