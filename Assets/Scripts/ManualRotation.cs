using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualRotation : MonoBehaviour
{

    [SerializeField]
    private Transform target; //Drugie działo
    [SerializeField]
    private float speed;



    // Update is called once per frame
    void Update()
    {

        //Utworzenie matrycy obrotu
        Vector3 targetAngles = target.eulerAngles;
        ManualRot.Matrix3x3 finale = ManualRot.Matrix3x3.Euler(targetAngles);

        //Wyliczenie nowego wektora i obrót
        Vector3 newUp = ManualRot.Matrix3x3.MatrixVector(finale, Vector3.up);
        Vector3 newForward = ManualRot.Matrix3x3.MatrixVector(finale, Vector3.forward);
        transform.LookAt(newForward + transform.position, newUp);
    }
}
