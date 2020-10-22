using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
    }
    void MoveToCursor()
    {
        Ray mouseClickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool hasHit = Physics.Raycast(mouseClickRay, out hitInfo);
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hitInfo.point;
        }
        else return;
    }

}
