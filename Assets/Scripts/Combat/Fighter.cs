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

        Health target;
        float timeSinceLastAttack = 0f;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null || target.IsDead()) return;
            else
            {
                bool isInRange = Vector3.Distance(transform.position, target.transform.position) < weaponRange;
                if (!isInRange)
                {
                    GetComponent<Mover>().MoveToCursor(target.transform.position);
                }
                else 
                {
                    GetComponent<Mover>().Cancel();
                    AttackBehaviour();
                }
            }
           
        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                transform.LookAt(target.transform);

                //this will trigger Hit() event in animation
                TriggerAttack();
                timeSinceLastAttack = 0f;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttacking");
            GetComponent<Animator>().SetTrigger("attack");
        }

        void Hit() //Animation Event on Player
        {
            if (target == null) return;
            target.TakeDamage(weaponDamage);
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
            
            Debug.Log("I'm gonna hit you, "+ combatTarget.name + "!");
            
        }

        public void Cancel() // for IAction
        {
            TriggerStopAttacking();
            target = null;
        }

        private void TriggerStopAttacking()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttacking");
        }


    }

}