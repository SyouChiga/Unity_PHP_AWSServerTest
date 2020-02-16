using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Manager
    {
        public class LoginManager : BeginManager
        {
            //LoginBoxObj
            [SerializeField]
            GameObject loginBoxObj_;
            public GameObject LoginBoxObj
            {
                get { return loginBoxObj_; }
            }

            //LoadinObj
            [SerializeField]
            GameObject loadingObj_;
            public GameObject LoadingObj
            {
                get { return loadingObj_; }
            }

            //EnumState
            [SerializeField]
            State.BeginUIState.LOGIN_STATE stateEnum_ = State.BeginUIState.LOGIN_STATE.START;


            [SerializeField]
            static private State.BeginUIState.LOGIN_STATE nextStateEnum_ = State.BeginUIState.LOGIN_STATE.START;
            static public State.BeginUIState.LOGIN_STATE NextStateEnum
            {
                set { nextStateEnum_ = value; }
            }

            // Start is called before the first frame update
            void Start()
            {
                state_ = new State.LoginStart(this);
            }

            // Update is called once per frame
            void Update()
            {
                if(state_.StateUpdate())
                {

                    ChangeStateSwitch((int)nextStateEnum_);
                }
            }

            //Stateの切り替え（switch）
            protected override void ChangeStateSwitch(int _switchState)
            {
                State.BeginUIState.LOGIN_STATE local_state = (State.BeginUIState.LOGIN_STATE)_switchState;
                //前のと同じなら処理をしない
                if (local_state == stateEnum_) return;
                
                switch (local_state)
                {
                    case State.BeginUIState.LOGIN_STATE.START:
                        ChangeState(new State.LoginStart(this));
                        break;
                    case State.BeginUIState.LOGIN_STATE.LOADING:
                        ChangeState(new State.LoginLoading(this));
                        break;
                    case State.BeginUIState.LOGIN_STATE.LOADING_END:
                        break;
                    case State.BeginUIState.LOGIN_STATE.USER_INPUT_START:
                        break;
                    case State.BeginUIState.LOGIN_STATE.USER_NEW_UPDATE:
                        break;
                    case State.BeginUIState.LOGIN_STATE.USER_INPUT_END:
                        break;
                    case State.BeginUIState.LOGIN_STATE.NEXT_SCENE_START:
                        break;
                    case State.BeginUIState.LOGIN_STATE.NEXT_SCENE_UPDATE:
                        break;
                    case State.BeginUIState.LOGIN_STATE.NEXT_SCENE_END:
                        break;

                    default:
                        return;
                }

                stateEnum_ = local_state;
            }
        }
    }
}
