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
            Ray ray = new Ray(transform.position, Vector3.forward);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, maxRayDistance);
            
                
                transform.DOLocalMove( hit.transform.position-Vector3.forward,passTime );
                Debug.Log("fORWARD");
                Debug.Log(hit.collider.gameObject.name);
           
        }
        else if(isMovingBack)
        {
            Ray ray = new Ray(transform.position, Vector3.back);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, maxRayDistance);
           
                
                transform.DOLocalMove( hit.transform.position-Vector3.back,passTime );
                Debug.Log("Back");
                Debug.Log(hit.collider.gameObject.name);
            
        }
        else if (isMovingRight)
        {
            Ray ray = new Ray(transform.position, Vector3.right);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, maxRayDistance);
            
            
                
                transform.DOLocalMove( hit.transform.position-Vector3.right,passTime );
                Debug.Log("Right");
                Debug.Log(hit.collider.gameObject.name);
           
        }
        else if(isMovingLeft)
        {
           Ray ray = new Ray(transform.position, Vector3.left);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, maxRayDistance);
           
                
                transform.DOLocalMove( hit.transform.position-Vector3.left,passTime );
                Debug.Log("Left");
                Debug.Log(hit.collider.gameObject.name);
            
        }

        
    }

     private void StopMovement()
    {
        
        isMovingForward=false;
        isMovingBack=false;
        isMovingLeft=false;
        isMovingRight=false;
        
    }

    
        private void OnTriggerEnter(Collider other) {
        
   
        
        count=transform.childCount;
        if(other.gameObject.tag=="CollectibleStack")
        {
            
            other.transform.position=new Vector3(transform.position.x,transform.position.y+transform.localScale.y*count,transform.position.z);
            other.transform.parent=transform;
            
            

          
        }

        if(other.gameObject.tag=="Obstacle")
        {
            StopMovement();
        }
    }

   
}
