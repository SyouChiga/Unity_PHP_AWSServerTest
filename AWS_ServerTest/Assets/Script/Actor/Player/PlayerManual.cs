using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Manual
    {
        //プレイヤー操作クラス
        public class PlayerManual
        {
            //移動値
            const float move_ = 1.0f;

            public void UpdateManual(Transform _transform)
            {
                Transform transform = _transform;

                //座標を取得
                Vector3 position = transform.position;

                //物理取得
                Rigidbody rigidbody = transform.gameObject.GetComponent<Rigidbody>();

                //右に移動
                if(Input.GetKey(KeyCode.A))
                {
                    rigidbody.AddForce(new Vector3(move_,0.0f,0.0f),ForceMode.Impulse);
                }
                //左に移動
                else if (Input.GetKey(KeyCode.D))
                {
                    rigidbody.AddForce(new Vector3(-move_, 0.0f, 0.0f), ForceMode.Impulse);
                }

            }
        }
    }
}
