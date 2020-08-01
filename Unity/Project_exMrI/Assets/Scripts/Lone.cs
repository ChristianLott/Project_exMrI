using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lone : MonoBehaviour
{
    [SerializeField, ]
    private float mul = 0f;
    private float multiplier = 0f;

    [SerializeField]
    private Transform rotationJoint, helperJoint;

    private Vector3 startPosition;
    private float startRotationAngle;

    private void OnValidate()
    {
        if (helperJoint)
            startPosition = helperJoint.position;
        if (rotationJoint)
            startRotationAngle = rotationJoint.localRotation.x;
        mul = Mathf.Clamp(mul, 0, 2);
        multiplier = mul / 100;

    }

    private void Awake()
    {
        OnValidate();
    }

    private void FixedUpdate()
    {
        mul = Mathf.Clamp(mul, 0, 2);
        multiplier = mul / 100;

        float rotationAngle = rotationJoint.localRotation.x - startRotationAngle;
        Vector3 movement = -helperJoint.forward * rotationAngle * mul;

        startRotationAngle = rotationJoint.localRotation.x;


        helperJoint.position += movement;

    }

}

