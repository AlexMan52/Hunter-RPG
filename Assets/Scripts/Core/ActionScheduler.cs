using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hunter.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel(); //через интерфейс IAction вызывает функцию Cancel либо в Mover либо в Fighter, 
                                        //в зависимости от того, что является текущим действием (currentAction)
            }
            currentAction = action;
        }
    }

}
