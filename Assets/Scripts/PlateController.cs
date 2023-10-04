using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        StackController.Instance.CollisionEnter(gameObject, collision.gameObject);
    }
}
