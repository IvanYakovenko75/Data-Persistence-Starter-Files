using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float _minMagnitude = 3.0f;
    [SerializeField] private float _coefVelosity = 3.0f;
    [SerializeField] private float _angularDeviation = 0.1f;
    [SerializeField] private float _upSpeedModifier = 0.5f;
    [SerializeField] private float _downSpeedModifier = 0.5f;
    [SerializeField] private float _accelerationModifier = 0.01f;

    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionExit(Collision other)
    {
        var velocity = m_Rigidbody.velocity;

        //после столкновения немного ускоряемся
        velocity += velocity.normalized * _accelerationModifier;

        //проверяем, не движемся ли мы полностью вертикально, так как это может привести к застреванию, мы добавляем небольшую вертикальную силу
        if (Vector3.Dot(velocity.normalized, Vector3.up) < _angularDeviation)
        {
            velocity += velocity.y > 0 ? Vector3.up * _upSpeedModifier : Vector3.down * _downSpeedModifier;
        }

        //max velocity
        if (velocity.magnitude > _minMagnitude)
        {
            velocity = velocity.normalized * _coefVelosity;
        }

        m_Rigidbody.velocity = velocity;
    }
}
