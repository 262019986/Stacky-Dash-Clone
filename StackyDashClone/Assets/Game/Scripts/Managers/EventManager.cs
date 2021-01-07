using UnityEngine.Events;

public static class EventManager 
{

  public static UnityEvent OnStack = new UnityEvent();
  public static UnityEvent OnUnStack = new UnityEvent();

  public static UnityEvent OnMove  = new UnityEvent();
  public static UnityEvent OnStop = new UnityEvent();
  public static UnityEvent OnGameStart = new UnityEvent();
  public static UnityEvent OnGameEnd = new UnityEvent();
  public static UnityEvent OnLevelStart = new UnityEvent();
  public static UnityEvent OnLevelEnd = new UnityEvent();
  public static UnityEvent OnPass = new UnityEvent();

 

}
