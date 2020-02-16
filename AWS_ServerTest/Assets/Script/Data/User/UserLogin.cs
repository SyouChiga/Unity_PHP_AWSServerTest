using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Data
    {
        public struct SaveDataName
        {
            public const string const_UserData = "UserData";
        }

        //ユーザーログイン情報
        [SerializeField]
        public struct UserLogin
        {
            //ID
            [SerializeField]
            public int userID_;


            //PASSWORD
            [SerializeField]
            public string userPass_;

            //ユーザーステータス
            [SerializeField]
            public UserStatus userStatus_;

            //ユーザーセット
            public void SetUserData(int _userID, string _userPass)
            {
                userID_   = _userID;
                userPass_ = _userPass;
            }
            public void SetUserData(string _userID, string _userPass)
            {
                userID_ = int.Parse(_userID);
                userPass_ = _userPass;
            }
        };

        //ユーザーステータス情報
        [SerializeField]
        public struct UserStatus
        {
            //MaxScore
            [SerializeField]
            public int maxScore_;
        }


    }
}
