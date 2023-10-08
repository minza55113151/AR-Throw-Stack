using System.Collections.Generic;
using UnityEngine;

public class PlateAutoCompleteController : MonoBehaviour
{
    [SerializeField]
    private PlateController plateController;

    private void OnTriggerEnter(Collider other)
    {
        plateController.TriggerEnter(other);   
    }
}
