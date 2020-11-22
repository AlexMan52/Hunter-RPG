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
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 20f;

        Transform target;
        float timeSinceLastAttack = 0f;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

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
                    AttackBehaviour();
                }
            }
           
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                //this will trigger Hit() event in animation
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0f;
            }
        }

        void Hit() //Animation Event on Player
        {
            target.GetComponent<Health>().TakeDamage(weaponDamage);
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            
            Debug.Log("I'm gonna hit you, "+ combatTarget.name + "!");
        }

        public void Cancel() // for IAction
        {
            target = null;
        }

        

    }

}