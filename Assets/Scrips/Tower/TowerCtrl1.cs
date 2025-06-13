using UnityEngine;

public class TowerCtrl : NewMonoBehaviour
{
    
    [SerializeField] Transform _model;
    public Transform Model => _model;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadModel();
       
    }
    void LoadModel()
    {
        _model = this.transform.GetChild(0).transform;

    }
    
}
