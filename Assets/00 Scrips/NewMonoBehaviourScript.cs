using UnityEngine;

public class NewMonoBehaviour : MonoBehaviour
{
    public void Reset()
    {
        LoadInReset();
    }
    protected virtual void LoadInReset() { }
    public virtual void LoadInAwake() { }

}
