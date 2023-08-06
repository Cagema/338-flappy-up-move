using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    [SerializeField] Transform _playerTr;
    [SerializeField] float _height;
    [SerializeField] Transform[] _spriteTrs;
    bool _lowerFirst = true;
    private void Start()
    {
        _spriteTrs[1].position = _spriteTrs[0].position + Vector3.up * _height;
    }
    private void FixedUpdate()
    {
        if (_playerTr)
        {
            if (_playerTr.position.y > (_lowerFirst ? _spriteTrs[0].position.y : _spriteTrs[1].position.y) + _height)
            {
                _spriteTrs[_lowerFirst ? 0 : 1].position = _spriteTrs[_lowerFirst ? 1 : 0].position + Vector3.up * _height;
                _lowerFirst = !_lowerFirst;
            }
        }
    }
}
