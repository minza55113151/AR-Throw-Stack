using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject platePrefab;

    [SerializeField]
    private float initVelolcity;

    [SerializeField]
    private float velocityGrowByStack;

    [SerializeField]
    private Transform plateContainerTransform;

    [SerializeField]
    private Button playerClickButton;

    private GameObject inHandPlate;

    public float DistanceToStack => Vector3.Distance(new Vector2(cam.transform.position.x, cam.transform.position.z), new Vector2(StackController.Instance.transform.position.x, StackController.Instance.transform.position.z));

    public float Velocity => initVelolcity + velocityGrowByStack * StackController.Instance.Score;

    [SerializeField]
    private Slider angleSlider;

    public float Angle => angleSlider ? angleSlider.value : 10;

    public GameObject PlatePrefab => platePrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CreatePlateInHand(platePrefab);
        GameController.Instance.OnRestartGame += OnRestartGame;

        playerClickButton.onClick.AddListener(ThrowStack);
    }

    private void OnDestroy()
    {
        GameController.Instance.OnRestartGame -= OnRestartGame;

        playerClickButton.onClick.RemoveListener(ThrowStack);
    }

    private void Update()
    {
        if (inHandPlate)
        {
            inHandPlate.transform.position = cam.transform.position + cam.transform.forward * 0.5f;
        }
    }

    public void CreatePlateInHand(GameObject platePrefab)
    {
        if (inHandPlate) return;
        
        inHandPlate = Instantiate(PlatePrefab, cam.transform.position + cam.transform.forward * 0.5f, Quaternion.identity, transform);
        inHandPlate.transform.localScale = platePrefab.transform.localScale;
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
        direction = Quaternion.AngleAxis(-Angle, rotateAxis) * direction;
        direction.Normalize();
        
        // Add force
        var plateRB = inHandPlate.GetComponent<Rigidbody>();
        plateRB.isKinematic = false;
        plateRB.velocity = direction * Velocity;

        var plateCollider = inHandPlate.GetComponent<Collider>();
        plateCollider.isTrigger = false;

        inHandPlate.transform.SetParent(plateContainerTransform);
        inHandPlate = null;
    }

    private void OnRestartGame()
    {
        foreach(Transform child in plateContainerTransform)
        {
            Destroy(child.gameObject);
        }
        CreatePlateInHand(platePrefab);
    }
}
