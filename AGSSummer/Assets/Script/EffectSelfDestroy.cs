using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSelfDestroy : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (particle.isStopped)             //パーティクルが終了したか判別する
        {
            Destroy(this.gameObject);       //パーティクル用ゲームオブジェクトを削除する
        }
    }
}
