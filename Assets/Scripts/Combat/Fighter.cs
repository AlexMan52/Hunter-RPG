using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunter.Combat
{
    public class Fighter : MonoBehaviour
    {
        public void Attack(CombatTarget target)
        {
            Debug.Log("I hit you, "+ target.name + "!");
        }
    }

}