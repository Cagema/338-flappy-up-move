using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] Transform _left;
    [SerializeField] Transform _right;

    private void Start()
    {
        _left.position = new Vector3(-GameManager.Single.RightUpperCorner.x, _left.transform.position.y, _left.transform.position.z);
        _right.position = new Vector3(GameManager.Single.RightUpperCorner.x, _right.transform.position.y, _right.transform.position.z);
    }
}
