using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MiniCubeManger : MonoBehaviour
{
    private static MiniCubeManger _instance;
    public static MiniCubeManger Instance { get => _instance; private set => _instance = value; }

    private List<BaseMagicCube> baseMagicCubes = new List<BaseMagicCube>();
    [Header("��ת�Ĳ���")]
    public float rotateTime = 2f;
    public float cubeWidth = 1;
    public Transform rotateParent; //Ҫ��ת�ķ���ĸ�����
    public bool rotateOver = true;

    [Header("���������")]
    public Camera miniCamera;
    public Transform player;    
    public float distance;
    public Vector3 playerPos;//playerʵ�ʵ�λ��
    public Vector3 cubeCenter;//ħ������
    public float moveTime = 2f;
    public BaseMagicCube currentCube;
    public Vector3 offset=Vector3.zero;//player��miniCube�е�λ��
    private bool haveRotate = true;
    private void Awake()
    {

        Instance = this;
        for (int i = 0; i < 8; i++)
        {
            baseMagicCubes.Add(transform.GetChild(i).GetComponent<BaseMagicCube>());
            cubeCenter += baseMagicCubes[i].transform.position;
        }
        cubeCenter /= 8;
        //miniCamera = transform.parent.GetComponentInChildren<Camera>();
        distance = Vector3.Distance(transform.position, miniCamera.transform.position);
        
    }
    private void Start()
    {
        playerPos.x = Mathf.RoundToInt(player.position.x / MagicCubeManger.Instance.cubeWidth);
        playerPos.y = Mathf.RoundToInt(player.position.y / MagicCubeManger.Instance.cubeWidth);
        playerPos.z = Mathf.RoundToInt(player.position.z / MagicCubeManger.Instance.cubeWidth);
        
    }

    private void Update()
    {
        CameraMove();
    }
    //ͨ����Ҫ��ת���������һ�������壬Ȼ���ø�������ת
    //ǰ
    //x =1
    public void RotateForward(float angle = 90)
    {
        BaseRotate(RotateType.Forward, angle);
    }
    //��
    public void RotateBack( float angle = 90)
    {
        BaseRotate(RotateType.Back, angle);
    }
    //��
    public void RotateLeft(float angle = 90)
    {
        BaseRotate(RotateType.Left, angle);
    }
    //��
    public void RotateRight( float angle = 90)
    {
        BaseRotate(RotateType.Right, angle);
    }
    //��
    public void RotateUp(float angle = 90)
    {
        BaseRotate(RotateType.Up, angle);
    }
    //��
    public void RotateDown(float angle = 90)
    {
        BaseRotate(RotateType.Down, angle);
    }
    enum RotateType
    {
        Forward,
        Back,
        Left,
        Right,
        Up,
        Down,
    }
    /// <summary>
    /// ������ת
    /// </summary>
    /// <param name="rotateType">��ת��ʽ</param>
    /// <param name="angle">��ת�Ƕ�</param>
    private void BaseRotate(RotateType rotateType, float angle = 90)
    {
        if (!rotateOver)
        {
            //StartCoroutine(DelayRotate(rotateType, angle));
            return;
        }
        rotateOver = false;
        //��ȡҪ��ת�ķ���
        List<BaseMagicCube> rotateCubes = new List<BaseMagicCube>();
        Vector3 centerPosition = Vector3.zero;//��ת����
        Vector3 currentCubeStartPos = currentCube.transform.localPosition;
        Vector3 dir = Vector3.one;//����
        for (int i = 0; i < baseMagicCubes.Count; i++)
        {
            switch (rotateType)
            {
                case RotateType.Forward:
                    
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.x / cubeWidth) == 1)
                    {
                        rotateCubes.Add(baseMagicCubes[i]);
                        centerPosition += baseMagicCubes[i].transform.position;
                    }
                    break;
                case RotateType.Back:
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.x / cubeWidth) == 1)
                    {
                        rotateCubes.Add(baseMagicCubes[i]);
                        centerPosition += baseMagicCubes[i].transform.position;
                    }
                    break;
                case RotateType.Left:
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.z / cubeWidth) == 1)
                    {
                        rotateCubes.Add(baseMagicCubes[i]);
                        centerPosition += baseMagicCubes[i].transform.position;
                    }
                    break;
                case RotateType.Right:
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.z / cubeWidth) == 1)
                    {
                        rotateCubes.Add(baseMagicCubes[i]);
                        centerPosition += baseMagicCubes[i].transform.position;
                    }
                    break;
                case RotateType.Up:                    
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.y / cubeWidth) == 1)
                    {
                        rotateCubes.Add(baseMagicCubes[i]);
                        centerPosition += baseMagicCubes[i].transform.position;
                    }
                    break;
                case RotateType.Down:
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.y / cubeWidth) == 1)
                    {
                        rotateCubes.Add(baseMagicCubes[i]);
                        centerPosition += baseMagicCubes[i].transform.position;
                    }
                    break;
            }
        }
        centerPosition /= 4;
        rotateParent.transform.position = centerPosition;
        for (int i = 0; i < rotateCubes.Count; i++)
        {
            rotateCubes[i].transform.SetParent(rotateParent);
        }
        Tween tween = null;
        switch (rotateType)
        {
            case RotateType.Forward:
                tween = rotateParent.transform.DOLocalRotate(new Vector3(angle, 0, 0), rotateTime);
                break;
            case RotateType.Back:
                tween = rotateParent.transform.DOLocalRotate(new Vector3(-angle, 0, 0), rotateTime);
                break;
            case RotateType.Left:
                tween = rotateParent.transform.DOLocalRotate(new Vector3(0, 0, -angle), rotateTime);
                break;
            case RotateType.Right:
                tween = rotateParent.transform.DOLocalRotate(new Vector3(0, 0, angle), rotateTime);
                break;
            case RotateType.Up:
                tween = rotateParent.transform.DOLocalRotate(new Vector3(0, angle, 0), rotateTime);
                break;
            case RotateType.Down:
                tween = rotateParent.transform.DOLocalRotate(new Vector3(0, -angle, 0), rotateTime);
                break;
        }

        tween.OnComplete(() =>
        {
            for (int i = 0; i < rotateCubes.Count; i++)
            {
                rotateCubes[i].transform.SetParent(transform);
            }
            rotateParent.SetAsLastSibling();
            rotateParent.rotation = new Quaternion();
            rotateOver = true;

            haveRotate = true;
        });
    }
    IEnumerator DelayRotate(RotateType rotateType, float angle)
    {
        yield return null;
        BaseRotate(rotateType, angle);
    }
    //Mini��������ƶ�
    private void CameraMove()
    {
        //Vector3 tempPlayerPos;//Playerʵ��λ��
        //tempPlayerPos.x = Mathf.RoundToInt(player.position.x / MagicCubeManger.Instance.cubeWidth);
        //tempPlayerPos.y = Mathf.RoundToInt(player.position.y / MagicCubeManger.Instance.cubeWidth);
        //tempPlayerPos.z = Mathf.RoundToInt(player.position.z / MagicCubeManger.Instance.cubeWidth);
        
        //if (Vector3.Distance(tempPlayerPos, playerPos) < 0.05f && !haveRotate)//�ж�����Ƿ��˸���
        //{
        //    return;
        //}
        //else
        //{
        //    playerPos = tempPlayerPos;
            
        //}

        miniCamera.transform.LookAt(cubeCenter);
        if(currentCube.ID==MagicCubeManger.Instance.currentCube.ID && !haveRotate)
        {
            return;
        }
        
        for (int i=0;i<baseMagicCubes.Count;i++)
        {
            if(baseMagicCubes[i].ID==MagicCubeManger.Instance.currentCube.ID)
            {
                currentCube = baseMagicCubes[i];
                break;
            }
        }
        miniCamera.transform.DOLocalMove(( currentCube.transform.position -cubeCenter).normalized * distance, moveTime);
        haveRotate = false;
    }

    
}
