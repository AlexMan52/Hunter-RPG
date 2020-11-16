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
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            print("Nothing to do");


        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                
                Debug.Log("Enemy");
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
            return false;
        }


        private bool InteractWithMovement()
        {
            RaycastHit hitInfo;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hitInfo);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    //GetComponent<Fighter>().CancelFight(); - мой вариант как перейти от атаки врага к движению по карте, вместо StartMoving в Mover.cs
                    //GetComponent<Mover>().MoveToCursor(hitInfo.point);
                    GetComponent<Mover>().StartMoving(hitInfo.point);

                }
                return true;
            }
            else return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

