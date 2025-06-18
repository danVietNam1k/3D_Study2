using UnityEngine;

public class LeftHand : NewMonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.ResetTransform();
    }
    private void ResetTransform()
    {
        this.transform.GetChild(0).transform.position = new Vector3(0.027f, 1.636f, 0.384f);
        this.transform.GetChild(0).transform.rotation = new Quaternion(0.02132175f, 0.1022764f, 0.6904203f, -0.7158245f);
        this.transform.GetChild(1).transform.position = new Vector3(-0.38f, 1.83f, 0.357f);
        this.transform.GetChild(1).transform.rotation = new Quaternion(3.725291e-09f, 4.365575e-10f, 1.280569e-09f, 1);
    }
}
