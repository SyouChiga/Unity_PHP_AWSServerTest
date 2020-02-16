using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    namespace State
    {
        public class LoginLoading : BeginUIState
        {
            //LoginBoxObj
            [SerializeField]
            Image loadingImg_;

            //時間
            [SerializeField]
            float time_;

            public LoginLoading(Manager.LoginManager _loginManager)
            {
                loadingImg_ = _loginManager.LoadingObj.GetComponent<Image>();
            }

            public override bool StateUpdate()
            {


                //回転させる
                RectTransform rectTransform = loadingImg_.rectTransform;

                Quaternion quaternion = rectTransform.rotation;
                Vector3 angle = quaternion.eulerAngles;
                quaternion.eulerAngles = new Vector3(angle.x, angle.x, angle.z + Time.deltaTime * 100.0f);
             
                rectTransform.rotation = quaternion;

                return false;
            }
        }
    }
}