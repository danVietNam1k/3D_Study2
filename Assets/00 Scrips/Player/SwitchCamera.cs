using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    
    [SerializeField] KeyCode _SwitchCamera = KeyCode.V;
    [SerializeField] GameObject _Camera1, _Camera3;
    void Start()
    {
        _Camera1= this.transform.GetChild(0).gameObject;
        _Camera3 = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        InputSwitch();
    }
    void InputSwitch()
    {
        if (Input.GetKeyUp(_SwitchCamera))
        {
            _Camera1.SetActive(!_Camera1.activeSelf);
            _Camera3.SetActive(!_Camera3.activeSelf);
        }

    }
        
}
