using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    public Transform target;
    public Vector3 targetPos;
    private float timer;
    public Text txt_time;
    private void Awake()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.destination = transform.position;
        
    }
    private void Update()
    {
        if(timer>0)
        {
            timer -= Time.deltaTime;
            int tempTime = (int)(timer * 10);
            txt_time.text = "" + tempTime / 10 + "." + tempTime % 10;
            return;
        }
        else
        {
            txt_time.text = "";
            meshAgent.updatePosition = true;
        }
        if(Vector3.Distance( transform.position,meshAgent.destination)<1f)
        {
            meshAgent.destination = target.position;
        }
        targetPos = meshAgent.destination;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag=="Player")
        //{
        //    meshAgent.destination = transform.position;
        //    meshAgent.updatePosition = false;
        //    timer = 5;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print(1);
            meshAgent.destination = transform.position;
            meshAgent.updatePosition = false;
            timer = 5;
        }
    }

}
