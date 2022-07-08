using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [Header("FPS counter")]
    /* Assign this script to any object in the Scene to display frames per second */

    public float updateInterval = 0.5f; //How often should the number update

    float accum = 0.0f;
    int frames = 0;
    float timeleft;
    float fps;

    GUIStyle textStyle = new GUIStyle();

    [Header("References")]
	public Transform bodyTransform;

	[Header("Sensitivity")]
	public float sensitivityMultiplier = 1f;
	public float horizontalSensitivity = 1f;
	public float verticalSensitivity   = 1f;

	[Header("Restrictions")]
	public float minYRotation = -90f;
	public float maxYRotation = 90f;
    public float minXRotation = -360f;
    public float maxXRotation = 360f;
    public bool canCameraMove = true;
    public bool useMaxY = false;

    //The real rotation of the camera without recoil
    private Vector3 realRotation;

	public Camera player_cam;

	public GameObject MainMenu;

	[Header("Aimpunch")]
	[Tooltip("bigger number makes the response more damped, smaller is less damped, currently the system will overshoot, with larger damping values it won't")]
	public float punchDamping = 9.0f;

	[Tooltip("bigger number increases the speed at which the view corrects")]
	public float punchSpringConstant = 65.0f;

	[HideInInspector]
	public Vector2 punchAngle;

	[HideInInspector]
	public Vector2 punchAngleVel;

	private void Start()
	{
        timeleft = updateInterval;

        textStyle.fontStyle = FontStyle.Bold;
        textStyle.normal.textColor = Color.white;

        sensitivityMultiplier = GameGlobal.Sensitivity / 100;
		// Lock the mouse
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible   = false;
		GameGlobal.canUseMenus = true;
		MainMenu.SetActive(false);

		if(GameGlobal.FOV < 60 || GameGlobal.FOV > 120){
			GameGlobal.FOV = 90;
		}
        player_cam.fieldOfView = GameGlobal.FOV;
	}

	private void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        // Interval ended - update GUI text and start new interval
        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            fps = (accum / frames);
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }



#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F5))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
		if(Input.GetKeyDown(KeyCode.Escape) && GameGlobal.canUseMenus && MainMenu != null)
		{
			MainMenu.SetActive(!MainMenu.activeSelf);
			if(MainMenu.activeSelf){
				MainMenu.GetComponent<MainMenuScript>().onEnable();
			}else{
				MainMenu.GetComponent<MainMenuScript>().onDisable();
			}
		}
		
        if (canCameraMove)
        {
            // Fix pausing
            if (Mathf.Abs(Time.timeScale) <= 0)
                return;

            DecayPunchAngle();

            // Input
            float xMovement = Input.GetAxisRaw("Mouse X") * horizontalSensitivity * sensitivityMultiplier;
            float yMovement = -Input.GetAxisRaw("Mouse Y") * verticalSensitivity * sensitivityMultiplier;

            // Calculate real rotation from input
            realRotation = new Vector3(Mathf.Clamp(realRotation.x + yMovement, minYRotation, maxYRotation), realRotation.y + xMovement, realRotation.z);
            realRotation.z = Mathf.Lerp(realRotation.z, 0f, Time.deltaTime * 3f);

            if (useMaxY)
            {
                if (realRotation.y < minXRotation)
                {
                    realRotation.y = minXRotation;
                }

                if (realRotation.y > maxXRotation)
                {
                    realRotation.y = maxXRotation;
                }
            }
            //Apply real rotation to body
            bodyTransform.eulerAngles = Vector3.Scale(realRotation, new Vector3(0f, 1f, 0f));

            //Apply rotation and recoil
            Vector3 cameraEulerPunchApplied = realRotation;
            cameraEulerPunchApplied.x += punchAngle.x;
            cameraEulerPunchApplied.y += punchAngle.y;

            transform.eulerAngles = cameraEulerPunchApplied;
        }
	}

	public void ViewPunch(Vector2 punchAmount)
	{
		//Remove previous recoil
		punchAngle = Vector2.zero;

		//Recoil go up
		punchAngleVel -= punchAmount * 20;
	}

	private void DecayPunchAngle()
	{
		if (punchAngle.sqrMagnitude > 0.001 || punchAngleVel.sqrMagnitude > 0.001)
		{
			punchAngle += punchAngleVel * Time.deltaTime;
			float damping = 1 - (punchDamping * Time.deltaTime);

			if (damping < 0)
				damping = 0;

			punchAngleVel *= damping;

			float springForceMagnitude = punchSpringConstant * Time.deltaTime;
			punchAngleVel -= punchAngle * springForceMagnitude;
		}
		else
		{
			punchAngle    = Vector2.zero;
			punchAngleVel = Vector2.zero;
		}
	}

    void OnGUI()
    {
        //Display the fps and round to 2 decimals
        GUI.Label(new Rect(5, 5, 100, 25), fps.ToString("F2") + "FPS", textStyle);
    }
}
