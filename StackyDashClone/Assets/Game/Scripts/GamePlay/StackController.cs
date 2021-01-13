using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{

    
  
    public Direction _direction=new Direction();
    
    public Vector3 PositionController;


    private void Start() 
    {
        EventManager.OnLevelStart.Invoke();
        transform.SetParent(null);
        
    }
    
    void OnEnable()
    {
        //Swipe events
        SwipeEvents.OnSwipeUp += OnSwipeUp;
        SwipeEvents.OnSwipeDown += OnSwipeDown;
        SwipeEvents.OnSwipeLeft += OnSwipeLeft;
        SwipeEvents.OnSwipeRight += OnSwipeRight;
        EventManager.OnGameStart.AddListener(() => transform.SetParent(null));
        EventManager.OnUnStack.AddListener (Unstack);
        EventManager.OnStop.AddListener( ()=> StartCoroutine(SwingOnStop())) ;
        EventManager.OnPass.AddListener (()=> transform.DOMove( new Vector3(transform.position.x , transform.position.y + GameManager.Instance.count * transform.localScale.y  , transform.position.z) , 0.1f ).OnComplete(()=> transform.DOMove(transform.position + Vector3.forward ,0.1F)));
        


        //Tap events
        
    }

    void OnDisable()
    {
        //! Always unsubscribe to events if you have subscribed to them
        //Swipe Events
        SwipeEvents.OnSwipeUp -= OnSwipeUp;
        SwipeEvents.OnSwipeDown -= OnSwipeDown;
        SwipeEvents.OnSwipeLeft -= OnSwipeLeft;
        SwipeEvents.OnSwipeRight -= OnSwipeRight;

        EventManager.OnGameStart.RemoveListener(() => transform.SetParent(null));
        EventManager.OnUnStack.RemoveListener (Unstack);
        EventManager.OnStop.RemoveListener( ()=> StartCoroutine(SwingOnStop())) ;
        EventManager.OnPass.RemoveListener (()=> transform.DOMove( new Vector3(transform.position.x , transform.position.y + GameManager.Instance.CharacterCount * transform.localScale.y  , transform.position.z) , 0.1f ).OnComplete(()=> transform.DOMove(transform.position + Vector3.forward ,0.1F)));
        
        

        //Tap Events
        

    }

   
   
     private void OnSwipeRight()
    {
        if(_direction.Right)
        {
            _direction.Right=false;
            
            Move(Vector3.right);
            
        }
    }

    private void OnSwipeUp()
    {
       if(_direction.Up)
       {
            _direction.Up=false;
            Move(Vector3.forward);
            
       }
    }



    private void OnSwipeDown()
    {
        if(_direction.Down)
        {
            _direction.Down=false;
             
             Move(Vector3.back);
        }
            
    }

    private void OnSwipeLeft()
    {
        if(_direction.Left) 
        {
            _direction.Left=false;
            
            Move(Vector3.left);
            Debug.Log("LEFT");
        }

    }

   
    private void Move(Vector3 direction)
    {
        EventManager.OnMove.Invoke();
        Vector3 rayStart=transform.position + Vector3.up  ;
        Debug.DrawRay(rayStart,direction,Color.red,5);
        RaycastHit hit;
        
        if(Physics.Raycast(rayStart , direction , out hit , 500.0f))
        {           
            Debug.Log(hit.transform.name);
            if(hit.transform.tag == " Pass")
            {
                transform.DOJump(hit.transform.position , 2f , 3 , 2);
                GameManager.Instance.count=0;
                return;    
               
            }

            if(hit.transform.tag == "Obstacle")
            {   
                
                  
                PositionController = hit.transform.position - direction;
                GameManager.Instance.passTime= Vector3.Distance (transform.position,hit.transform.position)/20;
                transform.DOMove( new Vector3(hit.transform.position.x , transform.position.y , hit.transform.position.z) -direction , GameManager.Instance.passTime ).OnComplete(()=> EventManager.OnStop.Invoke());
                
                
                CheckAvailableWays();

            }

            if(hit.transform.tag == "Final")
            {   
                Debug.Log("fİNAL");
                GameManager.Instance.passTime  =5;
                PositionController = hit.transform.position - direction;
                
                transform.DOMove( new Vector3(hit.transform.position.x , transform.position.y , hit.transform.position.z) -direction , GameManager.Instance.passTime ).OnComplete(()=> EventManager.OnStop.Invoke());
            }

            

        }
            
        
    }

    IEnumerator SwingOnStop()
    {
        
        
        transform.DORotate(new Vector3(0.4f,0,0.4f),0.1f);
        yield return new WaitForSeconds( 0.1f);
        transform.DORotate(new Vector3(-0.4f,0,-0.4f),0.1F);
        yield return new WaitForSeconds(0.1f);
        yield return transform.DORotate(new Vector3(0,0,0),0.1f);


        transform.rotation = Quaternion.Euler(0,0,0);

        for(int i=1; i< transform.childCount; i ++)
        {
             transform.GetChild(i).position = new Vector3(transform.position.x , transform.GetChild(i).transform.position.y , transform.position.z);
             transform.GetChild(i).rotation = transform.rotation;
        }
        
        
    }
   
    IEnumerator AutomaticMove(Vector3 direction)
    {
        yield return new WaitForSeconds(0.05f);
        Move(direction);
    }
    private void Unstack()
    {
        
        EventManager.OnLevelEnd.Invoke();
        Debug.Log("Unstack");
        for(int i=2;i<transform.childCount;i++)
        {
            transform.GetChild(i).transform.position = new Vector3(transform.position.x , transform.GetChild(i).transform.position.y -0.1f , transform.position.z);
        }

    }
    

    
    private void CheckAvailableWays()
    { 
        _direction.Left=WayRay(Vector3.forward);
        _direction.Right=WayRay(Vector3.back);
        _direction.Up=WayRay(Vector3.right);
        _direction.Down=WayRay(Vector3.left);
    }
    
    private bool WayRay(Vector3 dir )
    {
        Vector3 rayStart = transform.position + Vector3.up ;
        Debug.DrawRay(rayStart , dir , Color.red , 5);
        RaycastHit hit;
        
        if(Physics.Raycast(rayStart, dir,out hit, 1) && hit.transform.tag == "Obstacle" )
        {
            return true;
        }
        
        return true;
    }
        private void OnTriggerEnter(Collider other) 
        {
           
            if(other.tag == "CollectibleStacks")
            {
                Debug.Log("Collected");
                EventManager.OnStack.Invoke();
                GameManager.Instance.count++;
                GameManager.Instance.CharacterCount++;
                other.tag="Collected";  
                other.transform.position=new Vector3(transform.position.x , transform.position.y + transform.localScale.y * (GameManager.Instance.count) , transform.position.z);
                other.transform.parent=transform;
                



            }

            if(other.tag=="UnCollectible")
            {  
                other.tag="base";
                GameManager.Instance.count--;
                GameManager.Instance.CharacterCount--;
                EventManager.OnUnStack.Invoke();
                Transform UnStackObject = transform.GetChild(2);
                UnStackObject.DOMove(new Vector3(other.transform.position.x ,transform.position.y -0.1f , other.transform.position.z ) , 0.4f) ;
                UnStackObject.transform.SetParent(null);
                UnStackObject.tag = "Collected";

            }

            if(other.tag == "Obstacle")
            {
               
                
            }

            if(other.CompareTag("DownArrow"))
            {
                
                StartCoroutine(AutomaticMove(Vector3.left));
            }

            if(other.CompareTag("UpArrow"))
            {
                
                StartCoroutine(AutomaticMove(Vector3.right));
            }

            if(other.CompareTag("LeftArrow"))
            {
                
                StartCoroutine(AutomaticMove(Vector3.forward));
            }

            if(other.CompareTag("RightArrow"))
            {
                
               StartCoroutine(AutomaticMove(Vector3.back));
            }
            
        }

   
}

[System.Serializable]
public class Direction 
{
    public bool Up=true;
    public bool Down=true;
    public bool Right=true;
    public bool Left=true;
}
