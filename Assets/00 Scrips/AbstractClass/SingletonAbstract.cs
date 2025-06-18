using UnityEngine;

public class Singleton<T> : NewMonoBehaviour where T : NewMonoBehaviour
{
  private static T instance;    
    public static T Instance=> instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            return;
        }
        if (instance.GetInstanceID() != this.GetInstanceID())
        {
            Destroy(this);
        }
    }
}
