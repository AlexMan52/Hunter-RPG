﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunter.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Vector3 offset;
        [SerializeField] float cameraRotSpeed;

        void LateUpdate()
        {
            transform.position = target.position;
            /*if (Input.GetMouseButton(1))
            {
                float xInput = Input.GetAxis("Mouse X");
                float yInput = Input.GetAxis("Mouse Y");
                transform.RotateAround(target.position, transform.up, xInput * cameraRotSpeed * Time.deltaTime);
                transform.RotateAround(target.position, transform.right, yInput * cameraRotSpeed * Time.deltaTime);
                //offset = transform.position - target.position;
            }*/

        }
    }
}


