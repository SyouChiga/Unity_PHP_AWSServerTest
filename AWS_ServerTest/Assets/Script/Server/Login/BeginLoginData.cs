using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Game
{
    namespace Server
    {
        //LoginDataクラスの基礎
        public class BeginLoginData : MonoBehaviour
        {
            //保管ユーザーデータ
            [SerializeField]
            protected   Data.UserLogin userLoginData_;
            //サーバーアクセス:基礎関数
            virtual public IEnumerator LoginAccess()
            {
                yield return null;
            }

            //サーバーアクセス用関数
            virtual protected void ServerLogin(string _pathName,ref UnityWebRequest _www)
            {
                //JSON形式に変更
                Dictionary<string, string> dic = new Dictionary<string, string>
                {
                    {"user_id", userLoginData_.userID_.ToString()},
                    {"user_pass", userLoginData_.userPass_.ToString()}
                };

                //JSON形式を格納するため
                WWWForm form = new WWWForm();
                foreach (KeyValuePair<string, string> dic_arg in dic)
                {
                    form.AddField(dic_arg.Key, dic_arg.Value);
                }

                //WWWformをUnityWebRequestでPOSTする
                string serverAddress = "http://www.chigame.online/public/login/" + _pathName;
                _www = UnityWebRequest.Post(serverAddress, form);

                _www.timeout = 30;
            }
        }
    }
}
