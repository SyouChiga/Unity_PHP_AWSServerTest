using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Actor
    {
        //プレイヤークラス
        public class PlayerActor : BeginActor
        {
            //プレイヤーの操作クラス
            [SerializeField]
            Manual.PlayerManual playerManual_ = new Manual.PlayerManual();

            //プレイヤーが動いた瞬間の初期位置
            [SerializeField]
            Vector3 playerForceInitPosition_;
            public Vector3 PlayerForceInitPosition
            {
                set { playerForceInitPosition_ = value; }
            }

            //物理
            [SerializeField]
            Rigidbody rigidbody_;
            public Rigidbody GetRigidbody
            {
                get { return rigidbody_; }
            }


            //プレイヤーが動いた瞬間の範囲
            const float playerForceInitPositionLength_ = 0.5f;
            // Start is called before the first frame update
            void Start()
            {
                rigidbody_ = GetComponent<Rigidbody>();
            }

            //回転するかどうか
            bool isRotation_ = false;
            public bool IsRotation
            {
                set { 
                      isRotation_ = value;
                    rotationTime_ = 0.0f;
                    }
            }
            //回転時間
            float rotationTime_ = 0.0f;
            //回転時間制限
            const float rotatinTimeLength_ = 0.5f;
            //回転軸制限:Z
            const float rotationZLengt_ = 2.0f;

            //瞬間時間
            float momentTime_ = 0.0f;
            //瞬間ボタンを押したかどうか
            bool isMoment_ = false;
            public bool IsMoment
            {
                set
                {
                    isMoment_ = value;
                    momentTime_ = 0.0f;
                }
                get
                {
                    return isMoment_;
                }
            }
            //瞬間時間制限
            const float momentTimeLength_ = 0.5f;

            // Update is called once per frame
            void Update()
            {
                PlayerActor playerActor = this;
                playerManual_.UpdateManual(gameObject.transform,ref playerActor) ;
                RotationUpdate();
                MomentUpdate();
               // DebugUpdate();
            }

            //物理Update
            private void FixedUpdate()
            {
                Vector3 position = transform.position;

                //範囲外こえたら戻す
                if(position.x >= 0.5f || position.x <= -0.5f)
                {
                    position.x = Mathf.Sign(position.x) * 0.5f;
                    transform.position = position;
                   
                }


                float length = Vector3.Magnitude(playerForceInitPosition_ - position);

                if (length >= playerForceInitPositionLength_)
                {
                    float positionX = position.x + (Mathf.Sign(position.x) * playerForceInitPositionLength_);
                    position.x = positionX;
                    rigidbody_.velocity = Vector3.zero;
                }
            }

            protected override void DebugUpdate()
            {
                Debug.Log(transform.position);
                Debug.Log(Mathf.Sign(transform.position.x));
            }

            //回転Update
            private void RotationUpdate()
            {
                if (!isRotation_) return;

                Vector3 rotation = transform.localEulerAngles;
                

                rotationTime_ += Time.deltaTime;

                if (rotationTime_ <= rotatinTimeLength_) return;


                rigidbody_.angularVelocity = Vector3.zero;

                isRotation_ = false;
                rotationTime_ = 0.0f;
                
            }

            //瞬間Update
            private void MomentUpdate()
            {
                if (!isMoment_) return;

                momentTime_ += Time.deltaTime;

                if (momentTime_ < momentTimeLength_) return;

                momentTime_ = 0.0f;
                isMoment_ = false;
            }
        }
    }
}
