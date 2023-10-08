using UnityEngine;

public class MainMenuCameraController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1f;

    private Transform stackTransform;
    private float distanceFromStack;
    private float initialXRotation;

    private void Start()
    {
        stackTransform = StackController.Instance.transform;
        distanceFromStack = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(stackTransform.position.x, stackTransform.position.z));
        initialXRotation = transform.rotation.eulerAngles.x;
    }

    private void Update()
    {
        // Rotate the camera around the stackTransform
        RotateAroundStack();
    }

    private void RotateAroundStack()
    {
        // Calculate the desired rotation based on the current position
        float currentRotationY = Time.time * rotationSpeed;
        Quaternion desiredRotation = Quaternion.Euler(initialXRotation, currentRotationY, 0f);

        // Calculate the desired position based on the desired rotation
        Vector3 desiredPosition = stackTransform.position - (desiredRotation * Vector3.forward * distanceFromStack);

        // Set the camera's rotation to the desired rotation
        transform.rotation = desiredRotation;

        // Set the camera's position to the desired position
        transform.position = new Vector3(desiredPosition.x, transform.position.y, desiredPosition.z);
    }
}
