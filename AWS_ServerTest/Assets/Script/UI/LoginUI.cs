using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    namespace UI
    {
        //ログインUI処理
        public class LoginUI : MonoBehaviour
        {
            //ユーザーの名前
            [SerializeField]
            private Text userName_;
            public string UserName
            {
                get { return userName_.text; }
            }


            //ユーザーのパスワード
            [SerializeField]
            private Text userPass_;
            public string UserPass
            {
                get { return userPass_.text; }
            }

            //userName_,userPass_に中身が入っていればTrueを返す
            public bool InputSafe()
            {
                if (userName_.text == "" && userPass_.text == "") return false;
                return true;
            }
        }
    }
}
