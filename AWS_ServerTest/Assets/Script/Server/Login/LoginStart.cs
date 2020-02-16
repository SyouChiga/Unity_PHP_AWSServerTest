using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Game
{
    namespace Server
    {
        //ログイン処理
        public class LoginStart : MonoBehaviour
        {
            //ユーザー情報
            [SerializeField]
            private Data.UserLogin userLoginData_;

            // Start is called before the first frame update
            void Start()
            {
                //Debug
                DebugInit();
                //

                //データがあるかどうか
                if (PlayerPrefs.HasKey(Data.SaveDataName.const_UserData))
                { 

                    //保存されているデータをJSON変換し、変数に格納
                   userLoginData_ =  JsonUtility.FromJson<Data.UserLogin>( PlayerPrefs.GetString(Data.SaveDataName.const_UserData));

                    //ローカルに保存してあるユーザー情報をもとにサーバーとの通信開始
                    StartCoroutine(Access());
                }
                else
                {
                    //なかった場合は、新規に登録
                    NewUserData();
                }
            }

            //サーバーアクセス
            private IEnumerator Access()
            {
                //JSON形式に変更
                Dictionary<string, string> dic = new Dictionary<string, string>
                {
                    {"user_id", userLoginData_.userID_.ToString()},
                    {"user_pass", userLoginData_.userPass_.ToString()}
                };

                //JSON形式を格納するため
                WWWForm form = new WWWForm();
                foreach(KeyValuePair<string, string> dic_arg in dic)
                {
                    form.AddField(dic_arg.Key, dic_arg.Value);
                }

                //WWWformをUnityWebRequestでPOSTする
                string serverAddress = "http://www.chigame.online/public/login/" + Path.PathName.gameLogin_;
                UnityWebRequest www = UnityWebRequest.Post(serverAddress, form);

                www.timeout = 30;
                yield return www.SendWebRequest();

                //失敗した場合
                if (www.error != null)
                {
                    Debug.Log("HttpPost NG:" + www.error);
                }
                else if (www.isDone)
                {
                    //返ってきたデータを表示する
                    Debug.Log(www.downloadHandler.text);

                    www = null;
                }

            }

            //新規ユーザー登録
            private void NewUserData()
            {
                PlayerPrefs.SetString(Data.SaveDataName.const_UserData, JsonUtility.ToJson(userLoginData_));
            }

            //DebugInit
            private void DebugInit()
            {
                userLoginData_.userID_ = 0;
                userLoginData_.userPass_ = "chigasyou";
            }

            // Update is called once per frame
            void Update()
            {

            }
        }
    }
}
