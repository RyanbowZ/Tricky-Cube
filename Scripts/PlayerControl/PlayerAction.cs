using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject model;
    private PlayerInput pi;
    private Rigidbody rigid;
    //public CameraController cameraController;

    private Vector3 planarVec;
    private bool lockPlanar = false;
    private Vector3 thrustVec;
    private bool canAttack;
    private CapsuleCollider col;
    private float lerpTarget;
    private Vector3 deltaPos;

    private float walkSpeed = 3f;
    private float runSpeed = 1.8f;
    private float jumpVelocity = 4f;

    void Awake()
    {
        pi = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        /*if(pi.jump == true)
        {
            ani.SetTrigger("jump");
            canAttack = false;
        }*/

        if(pi.Dvec != Vector3.zero)
        {            
            model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.3f);
        }

        if(lockPlanar == false)
        {
            planarVec = pi.Dmag * model.transform.forward * walkSpeed * ((pi.run) ? runSpeed : 1.0f);
        }
    }

    private void FixedUpdate()
    {
        //rigid.position += deltaPos;
        rigid.velocity = new Vector3(planarVec.x, rigid.velocity.y, planarVec.z) + thrustVec;
        thrustVec = Vector3.zero;
        //deltaPos  = Vector3.zero;
    }
}
