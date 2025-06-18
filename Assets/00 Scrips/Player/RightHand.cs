using UnityEngine;

public class RightHand : NewMonoBehaviour
{
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.ResetTransform();
    }
    private void ResetTransform()
    {
        this.transform.GetChild(0).transform.position = new Vector3(0.222f, 1.579f, 0.09f);
        this.transform.GetChild(0).transform.rotation = new Quaternion(0.0371113f, -0.7169941f, -0.6946791f, -0.04430985f);
        this.transform.GetChild(1).transform.position = new Vector3(0.646f, 1.669f, -0.53f);
        this.transform.GetChild(1).transform.rotation = new Quaternion(3.725291e-09f, 4.365575e-10f, 1.280569e-09f, 1);
    }
}
