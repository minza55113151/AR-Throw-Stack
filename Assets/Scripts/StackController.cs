using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class StackController : MonoBehaviour
{
    public static StackController Instance { get; private set; }

    private List<GameObject> stack;

    [SerializeField]
    private GameObject topStackPlate;

    public GameObject TopStackPlate => topStackPlate;

    private GameObject platePrefab => PlayerController.Instance.PlatePrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        stack = new List<GameObject>();
    }

    private void Update()
    {
        
    }

    public void CollisionEnter(GameObject plateGameObject, GameObject collisionGameObject)
    {
        // check is in mainmenu
        if (UIMainMenuController.Instance != null) return;

        var plateRB = plateGameObject.GetComponent<Rigidbody>();
        if (plateRB.isKinematic) return;

        // check if the plate colis on top of stack
        var isTagPlate = plateGameObject.CompareTag("Plate");
        var isPosTop = plateGameObject.transform.position.y >= topStackPlate.transform.position.y;
        var isHitTopStack = collisionGameObject == topStackPlate;
        if (isTagPlate && isPosTop && isHitTopStack)
        {
            // add plate to stack
            stack.Add(plateGameObject);
            // set plate as child of stack
            plateGameObject.transform.SetParent(transform);

            plateGameObject.transform.position = new Vector3(plateGameObject.transform.position.x, collisionGameObject.transform.position.y + plateGameObject.transform.localScale.y, plateGameObject.transform.position.z);

            var leftTopPlatePos = topStackPlate.transform.position.x - topStackPlate.transform.localScale.x / 2;
            var rightTopPlatePos = topStackPlate.transform.position.x + topStackPlate.transform.localScale.x / 2;
            var topTopPlatePos = topStackPlate.transform.position.z + topStackPlate.transform.localScale.z / 2;
            var bottomTopPlatePos = topStackPlate.transform.position.z - topStackPlate.transform.localScale.z / 2;

            var leftPlatePos = plateGameObject.transform.position.x - plateGameObject.transform.localScale.x / 2;
            var rightPlatePos = plateGameObject.transform.position.x + plateGameObject.transform.localScale.x / 2;
            var topPlatePos = plateGameObject.transform.position.z + plateGameObject.transform.localScale.z / 2;
            var bottomPlatePos = plateGameObject.transform.position.z - plateGameObject.transform.localScale.z / 2;

            var leftOverflow = leftTopPlatePos - leftPlatePos;
            var rightOverflow = rightPlatePos - rightTopPlatePos;
            var topOverflow = topPlatePos - topTopPlatePos;
            var bottomOverflow = bottomTopPlatePos - bottomPlatePos;

            //Debug.Log($"leftOverflow: {leftOverflow}, rightOverflow: {rightOverflow}, topOverflow: {topOverflow}, bottomOverflow: {bottomOverflow}");

            //Debug.DrawRay(new Vector3(leftTopPlatePos, topStackPlate.transform.position.y, topStackPlate.transform.position.z), Vector3.up * 0.1f, Color.red, 2);
            //Debug.DrawRay(new Vector3(rightTopPlatePos, topStackPlate.transform.position.y, topStackPlate.transform.position.z), Vector3.up * 0.1f, Color.red, 2);
            //Debug.DrawRay(new Vector3(topStackPlate.transform.position.x, topStackPlate.transform.position.y, topTopPlatePos), Vector3.up * 0.1f, Color.red, 2);
            //Debug.DrawRay(new Vector3(topStackPlate.transform.position.x, topStackPlate.transform.position.y, bottomTopPlatePos), Vector3.up * 0.1f, Color.red, 2);

            var slicedPlateContainer = new GameObject("SlicedPlateContainer");
            //slicedPlateContainer.AddComponent<Rigidbody>();

            var leftBoundNewPlate = leftPlatePos;
            var rightBoundNewPlate = rightPlatePos;
            var topBoundNewPlate = topPlatePos;
            var bottomBoundNewPlate = bottomPlatePos;

            if (leftOverflow > 0)
            {
                var slicedPlate = Instantiate(platePrefab, slicedPlateContainer.transform);
                slicedPlate.transform.position = new Vector3(leftTopPlatePos - leftOverflow / 2, plateGameObject.transform.position.y, plateGameObject.transform.position.z);
                slicedPlate.transform.localScale = new Vector3(leftOverflow, plateGameObject.transform.localScale.y, plateGameObject.transform.localScale.z);

                leftBoundNewPlate = leftTopPlatePos;
            }
            if (rightOverflow > 0)
            {
                var slicedPlate = Instantiate(platePrefab, slicedPlateContainer.transform);
                slicedPlate.transform.position = new Vector3(rightTopPlatePos + rightOverflow / 2, plateGameObject.transform.position.y, plateGameObject.transform.position.z);
                slicedPlate.transform.localScale = new Vector3(rightOverflow, plateGameObject.transform.localScale.y, plateGameObject.transform.localScale.z);
                
                rightBoundNewPlate = rightTopPlatePos;
            }
            if (topOverflow > 0)
            {
                var slicedPlate = Instantiate(platePrefab, slicedPlateContainer.transform);
                slicedPlate.transform.position = new Vector3(plateGameObject.transform.position.x, plateGameObject.transform.position.y, topTopPlatePos + topOverflow / 2);
                slicedPlate.transform.localScale = new Vector3(plateGameObject.transform.localScale.x, plateGameObject.transform.localScale.y, topOverflow);

                topBoundNewPlate = topTopPlatePos;
            }
            if (bottomOverflow > 0)
            {
                var slicedPlate = Instantiate(platePrefab, slicedPlateContainer.transform);
                slicedPlate.transform.position = new Vector3(plateGameObject.transform.position.x, plateGameObject.transform.position.y, bottomTopPlatePos - bottomOverflow / 2);
                slicedPlate.transform.localScale = new Vector3(plateGameObject.transform.localScale.x, plateGameObject.transform.localScale.y, bottomOverflow);

                bottomBoundNewPlate = bottomTopPlatePos;
            }

            foreach(Transform slicedPlate in slicedPlateContainer.transform)
            {
                //var rb = slicedPlate.GetComponent<Rigidbody>();
                //rb.velocity = plateRB.velocity / 100;

                var collider = slicedPlate.GetComponent<BoxCollider>();
                collider.isTrigger = true;

                var material = slicedPlate.GetComponent<MeshRenderer>().material;
                material.color = plateGameObject.GetComponent<MeshRenderer>().material.color;

                slicedPlate.tag = "Untagged";
            }

            //Debug.DrawRay(new Vector3(leftBoundNewPlate, plateGameObject.transform.position.y, plateGameObject.transform.position.z), Vector3.up * 0.1f, Color.green, 2);
            //Debug.DrawRay(new Vector3(rightBoundNewPlate, plateGameObject.transform.position.y, plateGameObject.transform.position.z), Vector3.up * 0.1f, Color.green, 2);
            //Debug.DrawRay(new Vector3(plateGameObject.transform.position.x, plateGameObject.transform.position.y, topBoundNewPlate), Vector3.up * 0.1f, Color.green, 2);
            //Debug.DrawRay(new Vector3(plateGameObject.transform.position.x, plateGameObject.transform.position.y, bottomBoundNewPlate), Vector3.up * 0.1f, Color.green, 2);

            plateGameObject.transform.position = new Vector3((leftBoundNewPlate + rightBoundNewPlate) / 2, collisionGameObject.transform.position.y + plateGameObject.transform.localScale.y, (topBoundNewPlate + bottomBoundNewPlate) / 2);
            plateGameObject.transform.localScale = new Vector3(Mathf.Abs(rightBoundNewPlate - leftBoundNewPlate), plateGameObject.transform.localScale.y, Mathf.Abs(topBoundNewPlate - bottomBoundNewPlate));

            ////pause game by unity
            //Debug.Break();

            // set plate rigidbody to kinematic
            plateRB.isKinematic = true;
            // set top stack plate
            topStackPlate = plateGameObject;
        }
        else
        {
            GameController.Instance.GameOver();
        }
    }  
}
