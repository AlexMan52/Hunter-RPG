using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter.Movement;
using System;
using Hunter.Combat;

namespace Hunter.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            InteractWithMovement();
            InteractWithCombat();


        }

        private void InteractWithCombat()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
                foreach (RaycastHit hit in hits)
                {
                    CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                    if (target == null) continue;
                    GetComponent<Fighter>().Attack(target);
                }
            }
                
        }


        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                CheckClickedObject();
            }
        }

        void CheckClickedObject()
        {
            RaycastHit hitInfo;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hitInfo);
            if (hasHit)
            {
                GetComponent<Mover>().MoveToCursor(hitInfo.point);
            }
            else return;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

