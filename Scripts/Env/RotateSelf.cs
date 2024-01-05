using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RotateSelf : MonoBehaviour
{
    public float rotateTime=5;
    public float rotateAngle=30;
    private void Start()
    {
        Rotate(true);
    }
    private void Rotate(bool isAdd)
    {
        float mRotateAngle = isAdd ? rotateAngle : -rotateAngle;
        Vector3 dir = new Vector3(0, 18, mRotateAngle);
        transform.DOLocalRotate(dir, rotateTime).OnComplete(() => { Rotate(!isAdd); });
    }
}
