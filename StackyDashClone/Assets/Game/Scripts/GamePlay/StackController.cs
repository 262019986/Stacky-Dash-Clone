using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{

    public bool isMovingForward; 
    public bool isMovingBack;
    public bool isMovingRight;
    public bool isMovingLeft;
    public int count;
    
    public float passTime=1.5f;
    public float maxRayDistance=50f;
    private Character characterScript;
    public  Vector3 characterPos;
  
    

    private void Awake() 
    {
       
    }

    void Start()
    {
       
    }

   
    void Update()
    {
        StartMovement();
    }

    public void StartMovement()
    {
        
        
        if( (Input.GetKey(KeyCode.W)))
        {
          
            
            isMovingForward=true;
            

        }
        else if( (Input.GetKey(KeyCode.S)))
        {
            
           
            isMovingBack=true;
            
        }
        else if( (Input.GetKey(KeyCode.A)))
        {
            
            
            isMovingLeft=true;
            
        }
        else if( (Input.GetKey(KeyCode.D)))
        {
            
           
            isMovingRight=true;
            
        }


        if(isMovingForward)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
            isMovingForward=false;
            for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if(hit.collider.gameObject.tag=="Obstacle")
            {
                transform.DOLocalMove(new Vector3(hit.collider.transform.position.x,transform.position.y,hit.collider.transform.position.z)-Vector3.forward,passTime );
                Debug.Log("fORWARD");
                Debug.Log(hit.collider.gameObject.name);
                break;
            }
            
        }
                
                
        }
        else if(isMovingBack)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward*-1, 100.0F);
            isMovingBack=false;
            for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if(hit.collider.gameObject.tag=="Obstacle")
            {
                transform.DOLocalMove( new Vector3(hit.collider.transform.position.x,transform.position.y,hit.collider.transform.position.z)-Vector3.back,passTime );
                Debug.Log("Back");
                Debug.Log(hit.collider.gameObject.name);
                break;
            }
            
        }
            
        }
        else if (isMovingRight)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.right, 100.0F);
            isMovingRight=false;
            for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if(hit.collider.gameObject.tag=="Obstacle")
            {
                transform.DOLocalMove( new Vector3(hit.collider.transform.position.x,transform.position.y,hit.collider.transform.position.z)-Vector3.right,passTime );
                Debug.Log("right");
                Debug.Log(hit.collider.gameObject.name);
                break;
            }
            
        }
           
        }
        else if(isMovingLeft)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.up*-1, 100.0F);
            isMovingLeft=false;
            for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if(hit.collider.gameObject.tag=="Obstacle")
            {
                transform.DOLocalMove( new Vector3(hit.collider.transform.position.x,transform.position.y,hit.collider.transform.position.z)-Vector3.left,passTime );
                Debug.Log("left");
                Debug.Log(hit.collider.gameObject.name);
                break;
            }
            
        }
            
        }

        
    }

    
        private void OnTriggerEnter(Collider other) 
        {
           
            if(other.tag=="CollectibleStacks")
            {
                Debug.Log("stack");
                other.transform.parent=transform;
                count=transform.childCount;
                other.transform.position=transform.position+count*Vector3.up*transform.localScale.y;

            }
        }

   
}
