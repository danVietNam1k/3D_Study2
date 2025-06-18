using UnityEngine;

public class PlayerShooting : PlayerCtrAbstract
{
     
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PressAtkButton()
    {
        if(!this.PlayerCtrl.AimBehaviourBasic.CheckAiming()) return;

        if(this.PlayerCtrl.InputManager.PlayerAttack())
        {

        }
    }
   
}
