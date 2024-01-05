using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    public GameObject tishi;
    public static bool isPause=false;
    public bool isP = false;
    public Button gamesize;
    public Transform objcheck;
    public LayerMask endMask;
    public VideoPlayer vd;
    float timer = 0;
    public AudioSource ad;
    private void Update()
    {
        ContorlMagicCube();
        if (!isP)
        {
            if (Input.GetKey(KeyCode.P)|| Input.GetKey(KeyCode.Escape))
            {
                isP = true;
                isPause = !isPause;
            }
        }
        else
        {
            timer += Time.unscaledDeltaTime;
            if (timer > 0.5f)
            {
                isP = false;
                timer = 0;
            }
        }
        if (isPause)
        {
            gamesize.gameObject.SetActive(true);
        }
        else
        {
            gamesize.gameObject.SetActive(false);
        }

        if (Physics.CheckSphere(objcheck.position, 0.8f, endMask))
        {
            //Debug.Log("end");
            vd.gameObject.SetActive(true);
            vd.Play();
        }
    }
    public void onGameSizeClick()
    {
        //Debug.Log("click");
        isPause = false;
    }
    private void ContorlMagicCube()
    {
        
        if(Input.GetKeyDown(KeyCode.Y))
        {
            ad.Play();
            if(Mathf.RoundToInt(transform.position.y/MagicCubeManger.Instance.cubeWidth)==1)
            {
                //needOffset = true;
                MagicCubeManger.Instance.RotateDown(90);
                //MiniCubeManger.Instance.RotateDown(false);
            }
            else
            {
                MagicCubeManger.Instance.RotateUp(90);
                //MiniCubeManger.Instance.RotateUp(false);
            }
            MiniCubeManger.Instance.RotateUp();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            ad.Play();
            if (Mathf.RoundToInt(transform.position.y / MagicCubeManger.Instance.cubeWidth) == 0)
            {
                //needOffset = true;
                MagicCubeManger.Instance.RotateUp(-90);
                //MiniCubeManger.Instance.RotateUp(false);
            }
            else
            {
                MagicCubeManger.Instance.RotateDown(-90);
                //MiniCubeManger.Instance.RotateDown(false);
            }
            MiniCubeManger.Instance.RotateDown();
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            ad.Play();
            if (Mathf.RoundToInt(transform.position.z / MagicCubeManger.Instance.cubeWidth) == 0)
            {
                //needOffset = true;
                MagicCubeManger.Instance.RotateRight(90);
                //MiniCubeManger.Instance.RotateRight(false);
            }
            else
            {
                MagicCubeManger.Instance.RotateLeft(90);
                //MiniCubeManger.Instance.RotateLeft(false);
            }
            MiniCubeManger.Instance.RotateRight();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            ad.Play();
            if (Mathf.RoundToInt(transform.position.z / MagicCubeManger.Instance.cubeWidth) == 1)
            {
                //needOffset = true;
                MagicCubeManger.Instance.RotateLeft(-90);
                //MiniCubeManger.Instance.RotateLeft(false);

            }
            else
            {
                MagicCubeManger.Instance.RotateRight(-90);
                //MiniCubeManger.Instance.RotateRight(false);
            }
            MiniCubeManger.Instance.RotateLeft();
        }
        else if (Input.GetKeyDown(KeyCode.K))//Ç°
        {
            ad.Play();
            if (Mathf.RoundToInt(transform.position.x / MagicCubeManger.Instance.cubeWidth) == 1)
            {
                //needOffset = true;
                MagicCubeManger.Instance.RotateBack(90);
                //MiniCubeManger.Instance.RotateBack(false);
            }
            else
            {
                MagicCubeManger.Instance.RotateForward(90);
                //MiniCubeManger.Instance.RotateForward(false);
            }
            MiniCubeManger.Instance.RotateForward();
        }
        else if (Input.GetKeyDown(KeyCode.H))//ºó
        {
            ad.Play();
            if (Mathf.RoundToInt(transform.position.x / MagicCubeManger.Instance.cubeWidth) == 0)
            {
                //needOffset = true;
                MagicCubeManger.Instance.RotateForward(-90);
                //MiniCubeManger.Instance.RotateForward(false);
            }
            else
            {
                MagicCubeManger.Instance.RotateBack(-90);
                //MiniCubeManger.Instance.RotateBack(false);
            }
            MiniCubeManger.Instance.RotateBack();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
        }
    }
    public void wenhao()
    {
        if (tishi.activeInHierarchy)
        {
            tishi.SetActive(false);
        }
        else
        {
            tishi.SetActive(true);

        }
    }
    public void chongkai()
    {
        SceneManager.LoadScene(1);
    }
    public void tuichu()
    {
        SceneManager.LoadScene(0);
    }
}
