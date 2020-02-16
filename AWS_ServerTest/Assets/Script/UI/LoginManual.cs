using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Manual
    {
        //ログインの操作
        public class LoginManual : MonoBehaviour
        {
            //ログインUIの情報
            [SerializeField]
            UI.LoginUI loginUI_;

            //ログイン中かどうか
            [SerializeField]
            private bool useLoginConnection_ = false;

            private  void Awake()
            {
                loginUI_ = GetComponent<UI.LoginUI>();
            }

            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }
            //ボタンを押したときの処理
            public void PushButton()
            {
                //何も入力してなかったらor接続中なら、終了
                if (!loginUI_.InputSafe() || useLoginConnection_ == true) return;

                //ユーザーデータをセット
                Data.UserLogin userLogin = new Data.UserLogin();
                userLogin.SetUserData(loginUI_.UserName, loginUI_.UserPass);

                GameObject loginObj = GameObject.Find("Login");
                if (!loginObj) return;

                //loginObjにLoginStartを追加
                Server.LoginStart loginStart = loginObj.GetComponent<Server.LoginStart>();
                loginStart.UserLoginData = userLogin;
                loginStart.ServerStart();
                useLoginConnection_ = true;

            }
        }
    }
}
