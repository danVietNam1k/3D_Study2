

public abstract class ObjPooling<T> : NewMonoBehaviour where T : NewMonoBehaviour
{
 protected T GiveBack(T obj)
    {
        return obj;
    }
}
