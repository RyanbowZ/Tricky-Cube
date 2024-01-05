using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WordsController : MonoBehaviour
{
    public Texture[] words;
    public RawImage obj;
    private static WordsController _instance;
    public static WordsController Instance { get => _instance; private set => _instance = value; }
    // Start is called before the first frame update
    void Start()
    {
        //show(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show(int n)
    {
        obj.gameObject.SetActive(true);
        obj.texture = words[n];
    }
   
    public void showNull()
    {
        obj.gameObject.SetActive(false);
    }
}
