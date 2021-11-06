using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ToonController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 1000f;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private GameObject ground;

    private float hInput, vInput;
    private Rigidbody toonRigidBody;
    private bool isGrounded = true;

    #region MonoBehaviour
    private void Start() {
        toonRigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if(HasMoved(hInput, vInput)) {
            Move(new Vector3(hInput, 0f, vInput));
        }

        if(Input.GetKeyDown(jumpKey) && isGrounded) {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject == ground) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject == ground) {
            isGrounded = false;
        }
    }
    #endregion MonoBehaviour

    #region Class Methods
    private void Jump() {
        toonRigidBody.AddForce(Vector3.up * jumpForce);
    }

    private void Move(Vector3 input) {
        toonRigidBody.AddForce(input.normalized * moveSpeed * Time.deltaTime);
    }

    private bool HasMoved(float h, float v) {
        return (v != 0f || h != 0f);
    }
    #endregion Class Methods
}
