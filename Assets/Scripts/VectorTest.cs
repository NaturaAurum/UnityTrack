using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VectorTestType
{
    BezierCurve,
    Linear,
}

public enum LinearType
{
    Plus,
    Minus,
}

public class VectorTest : MonoBehaviour
{
    public VectorTestType TestType;
    public LinearType LinearType;

    public Transform ShowingObject1;

    public List<Transform> BezierCurvePointList = new List<Transform>();

    [Range(0, 1)]
    public float CurveT;

    public Transform p1;
    public Transform p2;

    private Vector3 linearResult;
    private Vector3 curveResult;

    private void Update()
    {
        if (TestType == VectorTestType.Linear)
        {
            LinearUpdate();
        }
        else if (TestType == VectorTestType.BezierCurve)
        {
            CurveUpdate();
        }
    }

    private void LinearUpdate()
    {
        if (LinearType == LinearType.Minus)
        {
            linearResult = p1.position - p2.position;
        }
        else if (LinearType == LinearType.Plus)
        {
            linearResult = p1.position + p2.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(p1.position, p2.position);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(p1.position + linearResult, p2.position);
    }

    private void CurveUpdate()
    {
        var q1 = Vector3.Lerp(BezierCurvePointList[0].position, BezierCurvePointList[1].position, CurveT);
        var q2 = Vector3.Lerp(BezierCurvePointList[1].position, BezierCurvePointList[2].position, CurveT);
        var B = Vector3.Lerp(q1, q2, CurveT);
        ShowingObject1.position = B;
    }
}
