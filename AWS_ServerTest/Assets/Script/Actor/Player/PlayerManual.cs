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
            const float move_ = 50.5f;
            //回転値
            const float rotationForce_ = 15.5f;
            //移動値瞬間
            const float moveMoment_ = 10.5f;
            //回転値瞬間
            const float rotationForceMoment_ = 15.5f;


            public void UpdateManual(Transform _transform,ref Actor.PlayerActor _playerActor)
            {
                Transform transform = _transform;

                //座標を取得
                Vector3 position = transform.position;

                //物理取得
                Rigidbody rigidbody = _playerActor.GetRigidbody;

                //右に移動
                if((Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A)) && position.x > -0.5f)
                {
                    if(Mathf.Abs(rigidbody.velocity.x) >= 0.0f)
                    {
                        rigidbody.velocity = Vector3.zero;
                        rigidbody.angularVelocity = Vector3.zero;
                    }
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        rigidbody.AddForce(new Vector3(-moveMoment_, 0.0f, 0.0f), ForceMode.Impulse);
                        rigidbody.AddTorque(new Vector3(0.0f, 0.0f, rotationForceMoment_), ForceMode.Impulse);
                        _playerActor.IsMoment = true;
                        _playerActor.PlayerForceInitPosition = position;
                        _playerActor.IsRotation = true;

                    }
                    else if(!_playerActor.IsMoment)
                    {
                        rigidbody.AddForce(new Vector3(-move_, 0.0f, 0.0f), ForceMode.Force);
                        rigidbody.AddTorque(new Vector3(0.0f, 0.0f, rotationForce_), ForceMode.Impulse);
                        _playerActor.PlayerForceInitPosition = position;
                        _playerActor.IsRotation = true;
                    }

                }
                //左に移動
                else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D)) && position.x < 0.5f)
                {
                    if (Mathf.Abs(rigidbody.velocity.x) >= 0.0f)
                    {
                        rigidbody.velocity = Vector3.zero;
                        rigidbody.angularVelocity = Vector3.zero;
                    }
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        rigidbody.AddForce(new Vector3(moveMoment_, 0.0f, 0.0f), ForceMode.Impulse);
                        rigidbody.AddTorque(new Vector3(0.0f, 0.0f, -rotationForceMoment_), ForceMode.Impulse);
                        _playerActor.IsMoment = true;
                        _playerActor.PlayerForceInitPosition = position;
                        _playerActor.IsRotation = true;
                    }
                    else if(!_playerActor.IsMoment)
                    {
                        rigidbody.AddForce(new Vector3(move_, 0.0f, 0.0f), ForceMode.Force);
                        rigidbody.AddTorque(new Vector3(0.0f, 0.0f, -rotationForce_), ForceMode.Impulse);
                        _playerActor.PlayerForceInitPosition = position;
                        _playerActor.IsRotation = true;
                    }
                }

            }



            
        }
    }
}
