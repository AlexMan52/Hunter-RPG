using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter.Movement;
using Hunter.Core;

namespace Hunter.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;

        Transform target;

        private void Update()
        {
            if (target == null) return;
            else
            {
                bool isInRange = Vector3.Distance(transform.position, target.position) > weaponRange;
                if (isInRange)
                {
                    GetComponent<Mover>().MoveToCursor(target.position);
                }
                else
                {
                    GetComponent<Mover>().Cancel();
                }
            }
           
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            Debug.Log("I hit you, "+ combatTarget.name + "!");
        }

        public void Cancel() // for IAction
        {
            target = null;
        }

    }

}