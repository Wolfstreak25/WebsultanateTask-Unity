using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] private PlayerType m_playerOpponent;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        GameManager.Instance.Scored(m_playerOpponent);
    }
}
