using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCIrcle : MonoBehaviour
{
    private Transform ringTransform;
    private Transform leftTransform;
    private Transform topTransform;
    private Transform rightTransform;
    private Transform bottomTransform;

    private void Awake()
    {
        ringTransform = transform.Find("Ring");
        leftTransform = transform.Find("Left");
        topTransform = transform.Find("Top");
        rightTransform = transform.Find("Right");
        bottomTransform = transform.Find("Bottom");

        SetRingSize(new Vector3(20, 20));
    }

    private void SetRingSize(Vector3 size)
    {
        ringTransform.localScale = size;
    }
}
