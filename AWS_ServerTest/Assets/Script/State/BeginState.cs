using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace State
    {
        public class BeginState
        {
            //ステートの初期処理
            virtual public void StateInit()
            {

            }
            //ステートの更新処理
            virtual public bool StateUpdate()
            {
                return true;
            }
        }
    }
}
