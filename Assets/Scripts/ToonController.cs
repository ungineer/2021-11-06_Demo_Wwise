using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ToonController : MonoBehaviour {
    [SerializeField] float moveSpeed = 100f;

    private Rigidbody ToonRigidBody { get; set; }
    private float hInput, vInput;

    private void Start() {
        ToonRigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if(HasMoved(hInput, vInput)) {
            Move(new Vector3(hInput, 0f, vInput));
        }
    }

    private void Move(Vector3 input) {
        ToonRigidBody.AddForce(input.normalized * moveSpeed * Time.deltaTime);
    }

    private bool HasMoved(float h, float v) {
        return (v != 0f || h != 0f);
    }
}
