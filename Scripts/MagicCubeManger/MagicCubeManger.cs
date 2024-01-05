using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ħ���Ŀ��ƺͲ�����
/// </summary>
public class MagicCubeManger : MonoBehaviour
{
    private static MagicCubeManger _instance;
    public static MagicCubeManger Instance { get => _instance; private set => _instance = value; }

    private List<BaseMagicCube> baseMagicCubes = new List<BaseMagicCube>();
    [Header("��ת�Ĳ���")]
    public float rotateTime=2f;
    public float cubeWidth = 1;
    public Transform rotateParent; //Ҫ��ת�ķ���ĸ�����
    public bool rotateOver = true;
    public BaseMagicCube currentCube;
    public Transform player;
    public GameObject wd;
    public GameObject mt;
    private Vector3 playerPos;
    private void Awake()
    {
        Instance = this;
        for(int i=0;i<8;i++)
        {
            baseMagicCubes.Add(transform.GetChild(i).GetComponent<BaseMagicCube>());
        }
    }
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        SelectCurrentCube();
        changeShow();
    }
    private void SelectCurrentCube()
    {
        Vector3 tempPlayerPos;//Playerʵ��λ��
        tempPlayerPos.x = Mathf.RoundToInt(player.position.x / cubeWidth);
        tempPlayerPos.y = Mathf.RoundToInt(player.position.y / cubeWidth);
        tempPlayerPos.z = Mathf.RoundToInt(player.position.z / cubeWidth);

        if (Vector3.Distance(tempPlayerPos, playerPos) < 0.05f)//�ж�����Ƿ��˸���
        {
            return;
        }
        else
        {
            playerPos = tempPlayerPos;
        }
        for(int i=0;i<baseMagicCubes.Count;i++)
        {
            if(Vector3.Distance(playerPos, baseMagicCubes[i].transform.localPosition/cubeWidth) < 0.05f)
            {
                currentCube = baseMagicCubes[i];
                break;
            }
        }
    }
    private void changeShow()
    {
        //Debug.Log(currentCube.ID);
        if (currentCube.ID > 0)
        {
            wd.GetComponent<WordsController>().show(currentCube.ID - 1);
            mt.GetComponent<MonsterController>().show((currentCube.ID - 1) % 2);
            //WordsController.Instance.show(currentCube.ID - 1);
            //MonsterController.Instance.show((currentCube.ID - 1) % 2);
        }
    }
    //ͨ����Ҫ��ת���������һ�������壬Ȼ���ø�������ת
    //ǰ
    //x =1
    public void RotateForward(float angle)
    {
        BaseRotate(RotateType.Forward, angle);

    }
    //��
    public void RotateBack(float angle )
    {
        BaseRotate(RotateType.Back,angle);
    }
    //��
    public void RotateLeft(float angle )
    {
        BaseRotate(RotateType.Left,angle);
    }
    //��
    public void RotateRight(float angle )
    {
        BaseRotate(RotateType.Right,angle);
    }
    //��
    public void RotateUp(float angle )
    {
        BaseRotate(RotateType.Up,angle);
    }
    //��
    public void RotateDown(float angle)
    {
        BaseRotate(RotateType.Down,angle);
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
    private void BaseRotate(RotateType rotateType,float angle=90)
    {
        if (!rotateOver)
        {
            return;
        }
        rotateOver = false;
        //��ȡҪ��ת�ķ���
        List<BaseMagicCube> rotateCubes = new List<BaseMagicCube>();
        Vector3 centerPosition = Vector3.zero;//��ת����

        rotateParent.transform.SetParent(transform);
        for (int i = 0; i < baseMagicCubes.Count; i++)
        {
            switch (rotateType)
            {
                case RotateType.Forward:
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.x/cubeWidth) ==1 )
                    {
                        rotateCubes.Add(baseMagicCubes[i]);
                        centerPosition += baseMagicCubes[i].transform.position;
                    }
                    break;
                case RotateType.Back:
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.x/cubeWidth) == 0)
                    {
                        rotateCubes.Add(baseMagicCubes[i]);
                        centerPosition += baseMagicCubes[i].transform.position;
                    }
                    break;
                case RotateType.Left:
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.z / cubeWidth) == 0)
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
                    if (Mathf.RoundToInt(baseMagicCubes[i].transform.localPosition.y / cubeWidth) == 0)
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

        Tween tween=null;
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
        });
    }
}
