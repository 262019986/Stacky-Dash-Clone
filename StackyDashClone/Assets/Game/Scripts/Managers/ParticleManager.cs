using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : Singleton <ParticleManager>
{
    public GameObject WindTrail;
    public GameObject WaterParticle;
    public GameObject SandTrail;
    
    private void OnEnable() 
    {
        EventManager.OnStop.AddListener(PlayRingEffect);
       

    }

    private void OnDisable() 
    {
        EventManager.OnStop.RemoveListener(PlayRingEffect);

    }



  

    private void PlayRingEffect()
    {   
        Debug.Log("RingEffectPlayed");
        Instantiate( WaterParticle , GameObject.FindWithTag("Player").transform.position + Vector3.up/2 , Quaternion.identity , GameObject.FindWithTag("Player").transform );
    
    }

    private void TurnParticle(Vector3 direction)
    {
        GameObject.FindWithTag("Player").transform.GetChild(0).transform.rotation = Quaternion.Euler(direction);
    }
}
