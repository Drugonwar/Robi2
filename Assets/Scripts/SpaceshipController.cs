using UnityEngine;

class SpaceshipController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float acceleration = 10;
    [SerializeField] float angularSpeedInIdle = 360;
    [SerializeField] float angularSpeedInMovement = 180;
    [SerializeField] float drag = 10;


    [SerializeField] float maxNitro = 2;
    [SerializeField] float turboMultiplier = 1.5f;

    float nitro;
    Vector3 velocity;

    void Start()
    {
        nitro = maxNitro;
    }
    void Update()
    {
        // Input
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        // Forgatás
        float angularSpeed = inputY == 0 ? angularSpeedInIdle : angularSpeedInMovement;
        transform.Rotate(0, 0, -inputX * angularSpeed * Time.deltaTime);

        // Mozgás
        transform.position += velocity * Time.deltaTime;

        // Reset
        if (Input.GetKeyDown(KeyCode.X))
        {
            Vector3 euler = transform.rotation.eulerAngles;
            euler.z = 0;
            transform.rotation = Quaternion.Euler(euler);
            velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // Input
        float inputY = Input.GetAxisRaw("Vertical");

        // Gyorsulás
        if (inputY != 0)
        {
            Vector3 direction = transform.up * inputY;
            float realAcceleration = acceleration;
            if (nitro > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                realAcceleration *= turboMultiplier;
                nitro -= Time.deltaTime;
                nitro = Mathf.Max(nitro, 0);
            }

            velocity += direction * realAcceleration * Time.fixedDeltaTime;   // Lépés
            if (velocity.magnitude > maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            }
        }
        else
        {
            nitro += Time.deltaTime;
            nitro = Mathf.Min(nitro, maxNitro);
        }

        // Lassítás
        Vector3 dragVector = -velocity * drag;
        velocity += dragVector * Time.fixedDeltaTime;


    }
}
