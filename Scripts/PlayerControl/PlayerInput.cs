using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("===== Key settings =====")]
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";
    public string keyA = "left shift";
    public string keyB = "space";
    //public string keyC = "f";

    [Header("===== Output signals =====")]
    public float Dup;
    public float Dright;
    public float Dmag;
    public Vector3 Dvec;

    public bool run;
    public bool jump;
    //public bool action;
    public float Jup;
    public float Jright;

    [Header("===== Others =====")]
    public bool InputEnabled = true;
    private float targetDup;
    private float targetDright;
    private float velocityDup;
    private float velocityDright;
    public float mouseSensitivityX = 5.0f;
    public float mouseSensitivityY = 3.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!PlayerControl.isPause)//使鼠标脱离
        {
            Cursor.visible = false;
            //Debug.Log("进入了");

            //Jup = (Input.GetKey(keyJUp) ? 1.0f : 0) - (Input.GetKey(keyJDown) ? 1.0f : 0);
            //Jright = (Input.GetKey(keyJRight) ? 1.0f : 0) - (Input.GetKey(keyJLeft) ? 1.0f : 0);
            Jup = Input.GetAxis("Mouse Y") * mouseSensitivityY;
            Jright = Input.GetAxis("Mouse X") * mouseSensitivityX;

            //实现Input.GetAxisRaw功能
            targetDup = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);
            targetDright = (Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0);
            if (InputEnabled == false)
            {
                targetDup = 0;
                targetDright = 0;
            }
            Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
            Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

            Vector2 tempDAxis = SquareToCircle(new Vector2(Dright, Dup));
            float Dright2 = tempDAxis.x;
            float Dup2 = tempDAxis.y;
            Dmag = Mathf.Sqrt(Dup2 * Dup2 + Dright2 * Dright2);
            Dvec = Dright2 * transform.right + Dup2 * transform.forward;

            run = Input.GetKey(keyA);
            jump = Input.GetKeyDown(keyB);
            //action = Input.GetKeyDown(keyC);
        }
        else
        {
            Cursor.visible = true;
            //Debug.Log("脱离了");
        }
    }

    private Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 outPut = Vector2.zero;
        outPut.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) * 0.5f);
        outPut.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) * 0.5f);
        return outPut;
    }
}
