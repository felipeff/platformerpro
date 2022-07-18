using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA;

    [SerializeField]
    private Transform _pointB;

    private float _speed = 3f;

    private bool _switching = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = _speed * Time.deltaTime;

        if (_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, step);
        }

        
        if(transform.position == _pointB.position)
        {
            _switching = true;
        }else if(transform.position == _pointA.position)
        {
            _switching = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            other.transform.parent = this.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = null;
    }
}
