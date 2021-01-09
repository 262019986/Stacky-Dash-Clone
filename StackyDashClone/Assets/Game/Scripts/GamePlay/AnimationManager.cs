using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : Singleton<AnimationManager>
{
    private Animator animator;
    public Animator Animator

    {
        get
        {
            if(animator == null)
            {
                animator=GetComponent<Animator>();
            }
            return animator;
        }
    }


    
    private void OnEnable() 
    {
        EventManager.OnLevelEnd.AddListener(() => Animator.SetTrigger("StopMovement"));
        
    }

    private void OnDisable() 
    {
        EventManager.OnLevelEnd.RemoveListener(() => Animator.SetTrigger("StopMovement"));
    }
    
}
