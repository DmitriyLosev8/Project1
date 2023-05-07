using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField, Range(0f, 1f)] private float _parallaxSpeedX;
    [SerializeField, Range(0f, 1f)] private float _parallaxSpeedY;

    private float _startPositionX;
    private float _startPositionY;

    private void Start()
    {
        _startPositionX = transform.position.x;
        _startPositionY = transform.position.y;
    }

    private void Update()
    {
        float distanceX = (_camera.transform.position.x * (1 - _parallaxSpeedX));
        float distanceY = (_camera.transform.position.y * (1 - _parallaxSpeedY));

        transform.position = new Vector3(_startPositionX + distanceX, _startPositionY + distanceY, transform.position.z);
    }
}
