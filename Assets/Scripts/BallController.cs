using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_rigidBody;
    [SerializeField] private float m_ballSpeed;
    private Vector2 m_vel;
    public void LaunchBall()
    {
        float x = Random.Range(0,2) == 0?  1:-1;
        float y = Random.Range(0,2) == 0?  1:-1;
        m_rigidBody.AddForce(new Vector2(x,y) * m_ballSpeed );
    }
    private void Update() 
    {
        m_vel = m_rigidBody.velocity;
        if(GameManager.Instance.IsGamePaused)
        {
            m_rigidBody.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D coliders) 
    {
        var speed = m_vel.magnitude;
        var direction = Vector3.Reflect(m_vel.normalized, coliders.GetContact(0).normal);
        m_rigidBody.velocity = direction * Mathf.Max(speed, 0f);
    }
    public void ResetBall()
    {
        transform.position = Vector3.zero;
        m_rigidBody.velocity = Vector2.zero;
    }
}
