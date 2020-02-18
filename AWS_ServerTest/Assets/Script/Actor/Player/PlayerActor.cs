using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Actor
    {
        //プレイヤークラス
        public class PlayerActor : MonoBehaviour
        {
            //プレイヤーの操作クラス
            [SerializeField]
            Manual.PlayerManual playerManual_ = new Manual.PlayerManual();
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {
                playerManual_.UpdateManual(gameObject.transform) ;
            }
        }
    }
}
