using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter.Movement;




namespace Hunter.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        public Transform target;

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
                    GetComponent<Mover>().Stop();
                }
            }
           
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            Debug.Log("I hit you, "+ combatTarget.name + "!");
        }
    }

}