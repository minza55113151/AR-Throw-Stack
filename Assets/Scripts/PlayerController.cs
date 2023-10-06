using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject platePrefab;

    [SerializeField]
    private float angle;

    [SerializeField]
    private float force;

    [SerializeField]
    private Transform plateContainerTransform;

    private GameObject inHandPlate;

    public float DistanceToStack => Vector3.Distance(new Vector2(cam.transform.position.x, cam.transform.position.z), new Vector2(StackController.Instance.transform.position.x, StackController.Instance.transform.position.z));

    public float Force => force;

    public GameObject PlatePrefab => platePrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CreatePlateInHand(platePrefab);
        GameController.Instance.OnGameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        GameController.Instance.OnGameOver -= OnGameOver;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowStack();
        }

        if (inHandPlate)
        {
            inHandPlate.transform.position = cam.transform.position + cam.transform.forward * 0.5f;
        }
    }

    public void CreatePlateInHand(GameObject platePrefab)
    {
        inHandPlate = Instantiate(platePrefab, cam.transform.position + cam.transform.forward * 0.5f, Quaternion.identity, transform);
        var plateRB = inHandPlate.GetComponent<Rigidbody>();
        plateRB.isKinematic = true;

        var plateCollider = inHandPlate.GetComponent<Collider>();
        plateCollider.isTrigger = true;

        // random color
        var material = inHandPlate.GetComponent<MeshRenderer>().material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    private void ThrowStack()
    {
        if (!inHandPlate) return;

        // direction
        var direction = cam.transform.forward;
        var rotateAxis = cam.transform.right;
        direction = Quaternion.AngleAxis(-angle, rotateAxis) * direction;
        direction.Normalize();
        
        // Add force
        var plateRB = inHandPlate.GetComponent<Rigidbody>();
        plateRB.isKinematic = false;
        plateRB.AddForce(direction * force);

        var plateCollider = inHandPlate.GetComponent<Collider>();
        plateCollider.isTrigger = false;

        inHandPlate.transform.SetParent(plateContainerTransform);
        inHandPlate = null;
    }

    private void OnGameOver()
    {
        foreach(Transform child in plateContainerTransform)
        {
            Destroy(child.gameObject);
        }
        CreatePlateInHand(platePrefab);
    }
}
