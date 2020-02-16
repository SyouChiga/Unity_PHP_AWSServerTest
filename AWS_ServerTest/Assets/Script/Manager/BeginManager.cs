using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Manager
    {
        //マネージャークラス：基礎
        public class BeginManager : MonoBehaviour
        {
            //State
            [SerializeField]
            protected State.BeginState state_;

            //Stateの切り替え
            virtual protected void ChangeState(State.BeginState _changeState)
            {
                state_ = null;
                state_ = _changeState;
                state_.StateInit();
            }

            //Stateの切り替え（switch）
            virtual protected void ChangeStateSwitch(int _switchState)
            {

            }
        }
    }
}