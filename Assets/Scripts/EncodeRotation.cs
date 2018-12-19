using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncodeRotation : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        var targetRot = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, speed * Time.deltaTime);
    }
}
