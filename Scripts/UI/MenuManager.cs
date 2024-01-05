using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject video;
    public AudioSource menuaudio;
    public VideoPlayer developer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("manage");
    }
    public void kaishi()
    {
        SceneManager.LoadScene(1);
    }
    public void tuichu()
    {
        Application.Quit();
    }
    public void zhizuozhe()
    {
        video.SetActive(false);
        developer.gameObject.SetActive(true);
        developer.Play();
        
    }
    public void chongkai()
    {
        SceneManager.LoadScene(0);
    }
}
