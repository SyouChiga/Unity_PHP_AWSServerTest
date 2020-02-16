using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Game
{
    namespace Server
    {
        //新しいユーザーデータ作成クラス
        public class NewLoginData : BeginLoginData
        {
            public NewLoginData(ref Data.UserLogin _newUserData)
            {
                //保管
                userLoginData_ = _newUserData;

               
            }
            //サーバーアクセス
            public override IEnumerator LoginAccess()
            {
                //接続
                UnityWebRequest www = new UnityWebRequest();
                ServerLogin(Path.PathName.newUserData_,ref www);
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
        }
    }
}
