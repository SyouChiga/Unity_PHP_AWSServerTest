using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace State
    {
        public class LoginStart : BeginUIState
        {
            //LoginBoxObj
            [SerializeField]
            GameObject loginBoxObj_;

            //LoginBoxObj
            [SerializeField]
            GameObject loadingObj_;


            public LoginStart(Manager.LoginManager _loginManager)
            {
                loginBoxObj_ = _loginManager.LoginBoxObj;
                loginBoxObj_.SetActive(false);

                loadingObj_ = _loginManager.LoadingObj;
                loadingObj_.SetActive(true);
            }


            public override bool StateUpdate()
            {
                Manager.LoginManager.NextStateEnum = LOGIN_STATE.LOADING;
                return true;
            }
        }
    }
}
