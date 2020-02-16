using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace State
    {
        public class BeginUIState : BeginState
        {
            //State_LOGIN
            public enum LOGIN_STATE : int
            {
                START = 0,
                LOADING,
                LOADING_END,
                USER_INPUT_START,
                USER_NEW_UPDATE,
                USER_INPUT_END,
                NEXT_SCENE_START,
                NEXT_SCENE_UPDATE,
                NEXT_SCENE_END
            }
        }

    }
}