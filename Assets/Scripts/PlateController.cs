using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{

    private Rigidbody rb;

    private List<Collision> collisions = new List<Collision>();

    private Coroutine performCollisionsCoroutine;

    public Rigidbody RB => rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameController.Instance.OnGameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        GameController.Instance.OnGameOver -= OnGameOver;
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions.Add(collision);
        if (performCollisionsCoroutine != null)
        {
            StopCoroutine(performCollisionsCoroutine);
            performCollisionsCoroutine = null;
        }
        performCollisionsCoroutine = StartCoroutine(PerformCollision());
    }

    private IEnumerator PerformCollision()
    {
        yield return new WaitForSeconds(Time.fixedDeltaTime);
        StackController.Instance.CollisionEnter(gameObject, collisions);
        collisions.Clear();
        performCollisionsCoroutine = null;
    }

    private void OnGameOver()
    {
        collisions = new List<Collision>();
        if (performCollisionsCoroutine != null)
        {
            StopCoroutine(performCollisionsCoroutine);
            performCollisionsCoroutine = null;
        }
    }
}
