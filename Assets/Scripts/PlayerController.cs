using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerType m_playerType;
    [SerializeField] private Rigidbody2D m_rigidBody;
    [Range(0,10)]
    [SerializeField] private float m_movementSpeed = 10;

    void FixedUpdate()
    {
        if(!GameManager.Instance.IsGamePaused)
        {
            MoveDirection();
        }
    }
    private void MoveDirection()
    {
        Vector3 m_moveDirection = new Vector3();
        if(m_playerType == PlayerType.Player1)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                m_moveDirection = Vector2.up;
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                m_moveDirection = Vector2.down;
            }
        }
        if(m_playerType == PlayerType.Player2)
        {
            if(Input.GetKey(KeyCode.W))
            {
                m_moveDirection = Vector2.up;
            }
            if(Input.GetKey(KeyCode.S))
            {
                m_moveDirection = Vector2.down;
            }
        }
        m_rigidBody.MovePosition(transform.position + m_moveDirection * m_movementSpeed * Time.fixedDeltaTime);
    }
}
public enum PlayerType
{
    Player1,
    Player2
}