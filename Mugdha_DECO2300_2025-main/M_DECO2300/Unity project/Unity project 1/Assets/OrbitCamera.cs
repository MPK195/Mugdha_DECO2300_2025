using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 4f;
    public float xSpeed = 120f;
    public float ySpeed = 80f;
    public float yMin = -20f, yMax = 60f;

    float x, y;

    void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.y; y = angles.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
            y = Mathf.Clamp(y, yMin, yMax);
        }

        Quaternion rot = Quaternion.Euler(y, x, 0);
        Vector3 pos = rot * new Vector3(0, 0, -distance) + target.position;

        transform.rotation = rot;
        transform.position = pos;
    }
}