using UnityEngine;
using System.Collections;
using UnityEngine.Animations.Rigging;

// AimBehaviour inherits from GenericBehaviour. This class corresponds to aim and strafe behaviour.
public class AimBehaviourBasic : GenericBehaviour
{
	public string aimButton = "Aim", shoulderButton = "Aim Shoulder";     // Default aim and switch shoulders buttons.
	public Texture2D crosshair;                                           // Crosshair texture.
	public float aimTurnSmoothing = 0.15f;                                // Speed of turn response when aiming to match camera facing.
	public Vector3 aimPivotOffset = new Vector3(0.5f, 1.2f,  0f);         // Offset to repoint the camera when aiming.
	public Vector3 aimCamOffset   = new Vector3(0f, 0.4f, -0.7f);         // Offset to relocate the camera when aiming.
	Rig _rig;
	[SerializeField] float _speedRigAnim = 10f;
	[SerializeField] bool _useAnimeRig=true;
	private int aimBool;                                                  // Animator variable related to aiming.
	private bool aim;                                                     // Boolean to determine whether or not the player is aiming.
	bool _stateAiming = false;
	// Start is always called after any Awake functions.
	void Start ()
	{
		// Set up the references.
		aimBool = Animator.StringToHash("Aim");
		_rig = this.PlayerCtrl.Rigging.GetComponent<Rig>();
    }

	// Update is used to set features regardless the active behaviour.
	void Update ()
	{	if(_useAnimeRig)
		AnimRig();
		//LookingTargerAim();
        // Activate/deactivate aim by input.
        if (Input.GetAxisRaw(CONSTANT.aimButton) != 0 && !aim)
		{
			StartCoroutine(ToggleAimOn());
			
            _stateAiming =true;
        }
		else if (aim && Input.GetAxisRaw(aimButton) == 0)
		{
			StartCoroutine(ToggleAimOff());
            _stateAiming = false;
        }

		// No sprinting while aiming.
		canSprint = !aim;

		// Toggle camera aim position left or right, switching shoulders.
		if (aim && Input.GetButtonDown (shoulderButton))
		{
			aimCamOffset.x = aimCamOffset.x * (-1);
			aimPivotOffset.x = aimPivotOffset.x * (-1);
		}

		// Set aim boolean on the Animator Controller.
		
		behaviourManager.GetAnim.SetBool (aimBool, aim);
        

    }
	void LookingTargerAim()
    {
		if(_stateAiming)
		this.transform.rotation = this.GetComponent<PlayerCtrl>().MainCam.rotation;
	}
    public bool CheckAiming()
	{
		return _stateAiming;
	}
	void AnimRig()
	{
      if  (Input.GetAxisRaw(aimButton) != 0)
            _rig.weight += Time.deltaTime * _speedRigAnim;
        else 
			_rig.weight -= Time.deltaTime * _speedRigAnim;
    }

    // Co-routine to start aiming mode with delay.
    private IEnumerator ToggleAimOn()
	{
		yield return new WaitForEndOfFrame();
		// Aiming is not possible.
		if (behaviourManager.GetTempLockStatus(this.behaviourCode) || behaviourManager.IsOverriding(this))
			yield return false;

		// Start aiming.
		else
		{
            aim = true;
			int signal = 1;
			aimCamOffset.x = Mathf.Abs(aimCamOffset.x) * signal;
			aimPivotOffset.x = Mathf.Abs(aimPivotOffset.x) * signal;
			yield return new WaitForEndOfFrame();
			behaviourManager.GetAnim.SetFloat(speedFloat, 0);
			// This state overrides the active one.
			behaviourManager.OverrideWithBehaviour(this);
		}
	}

	// Co-routine to end aiming mode with delay.
	private IEnumerator ToggleAimOff()
	{
        aim = false;
		yield return new WaitForSeconds(0.1f);
		behaviourManager.GetCamScript.ResetTargetOffsets();
		behaviourManager.GetCamScript.ResetMaxVerticalAngle();
		yield return new WaitForSeconds(0.05f);
		behaviourManager.RevokeOverridingBehaviour(this);
	}

	// LocalFixedUpdate overrides the virtual function of the base class.
	public override void LocalFixedUpdate()
	{
		// Set camera position and orientation to the aim mode parameters.
		if(aim)
			behaviourManager.GetCamScript.SetTargetOffsets (aimPivotOffset, aimCamOffset);
	}

	// LocalLateUpdate: manager is called here to set player rotation after camera rotates, avoiding flickering.
	public override void LocalLateUpdate()
	{
		AimManagement();
	}

	// Handle aim parameters when aiming is active.
	void AimManagement()
	{
		// Deal with the player orientation when aiming.
		Rotating();
	}

	// RotateHeadGunMachine the player to match correct orientation, according to camera.
	void Rotating()
	{
		Vector3 forward = behaviourManager.playerCamera.TransformDirection(Vector3.forward);
		// Player is moving on ground, Y component of camera facing is not relevant.
		forward.y = 0.0f;
		forward = forward.normalized;

		// Always rotates the player according to the camera horizontal rotation in aim mode.
		Quaternion targetRotation =  Quaternion.Euler(0, behaviourManager.GetCamScript.GetH, 0);

		float minSpeed = Quaternion.Angle(transform.rotation, targetRotation) * aimTurnSmoothing;

		// RotateHeadGunMachine entire player to face camera.
		behaviourManager.SetLastDirection(forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, minSpeed * Time.deltaTime);

	}

 	// Draw the crosshair when aiming.
	void OnGUI () 
	{
		if (crosshair)
		{
			float mag = behaviourManager.GetCamScript.GetCurrentPivotMagnitude(aimPivotOffset);
			if (mag < 0.05f)
				GUI.DrawTexture(new Rect(Screen.width / 2.0f - (crosshair.width * 0.5f),
										 Screen.height / 2.0f - (crosshair.height * 0.5f),
										 crosshair.width, crosshair.height), crosshair);
		}
	}
}
