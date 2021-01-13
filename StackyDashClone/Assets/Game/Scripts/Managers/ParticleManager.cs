using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : Singleton <ParticleManager>
{
    public GameObject Confeti;
    public GameObject WaterParticle;
    public GameObject SandTrail;
    
    private void OnEnable() 
    {
        EventManager.OnStop.AddListener(PlayRingEffect);
        EventManager.OnUnStack.AddListener(PlayConfeti);
       

    }

    private void OnDisable() 
    {
        EventManager.OnStop.RemoveListener(PlayRingEffect);
        EventManager.OnUnStack.RemoveListener(PlayConfeti);

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

    private void PlayConfeti()
    {
        Instantiate(Confeti , FindObjectOfType<StackController>().transform.position + Vector3.left *2 , Quaternion.identity);
        Instantiate(Confeti , FindObjectOfType<StackController>().transform.position + Vector3.right*2 , Quaternion.identity);
    }
}
