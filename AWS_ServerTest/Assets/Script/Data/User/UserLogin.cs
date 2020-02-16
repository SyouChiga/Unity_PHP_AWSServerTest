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

        [SerializeField]
        public struct UserLogin
        {
            //ID
            [SerializeField]
            public int userID_;


            //PASSWORD
            [SerializeField]
            public string userPass_;
        };

    }
}
