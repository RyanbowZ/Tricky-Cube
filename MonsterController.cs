using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    public Texture[] monsters;
    public RawImage obj;
    private static MonsterController _instance;
    public static MonsterController Instance { get => _instance; private set => _instance = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show(int n)
    {
        
        obj.gameObject.SetActive(true);
        obj.texture = monsters[n];
    }
    
    public void showNull()
    {
        //obj.texture = null;
        obj.gameObject.SetActive(false);
    }
}
