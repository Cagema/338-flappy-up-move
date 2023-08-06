using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform _playerTr;
    private void Start()
    {
        _playerTr = FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate()
    {
        if (_playerTr)
        {
            if (_playerTr.position.y > transform.position.y + 10)
            {
                Destroy(gameObject);
            }
        }
    }
}
