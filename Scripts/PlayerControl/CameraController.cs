using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private GameObject cameraHandle;
    private float tempEulerX;
    public GameObject model;
    private GameObject playerCamera;
    private Vector3 cameraDampVelocity;

    public PlayerInput pi;
    public float horizontalSpeed = 100f;
    public float verticalSpeed = 80f;
    public float cameraDampValue = 0.1f;
    

    private void Awake()
    {
        cameraHandle = transform.parent.gameObject;
        player = cameraHandle.transform.parent.gameObject;
        playerCamera = Camera.main.gameObject;
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerControl.isPause)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Vector3 tempModelEuler = model.transform.eulerAngles;

            player.transform.Rotate(Vector3.up, pi.Jright * horizontalSpeed * Time.fixedDeltaTime);
            tempEulerX -= pi.Jup * verticalSpeed * Time.fixedDeltaTime;
            tempEulerX = Mathf.Clamp(tempEulerX, -70, 70);
            cameraHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);

            model.transform.eulerAngles = tempModelEuler;

            playerCamera.transform.position = Vector3.SmoothDamp(playerCamera.transform.position, transform.position, ref cameraDampVelocity, cameraDampValue);
            //camera.transform.eulerAngles = transform.eulerAngles;
            playerCamera.transform.LookAt(cameraHandle.transform);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
