using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hunter.Movement
{
    public class Mover : MonoBehaviour
    {
        void Update()
        {
            UpdateAnimator();
        }
        public void MoveToCursor(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }
        void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}

