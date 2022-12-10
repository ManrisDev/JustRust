using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera settings")]
    [SerializeField] private Transform player;
    [SerializeField] private float camSpeed = 5f;
    [SerializeField] private float camHeight = 4.57f;

    private float direction;
    private Vector3 position;

    [Header("Camera limits")]
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float topLimit;
    [SerializeField] private float bottomLimit;

    [Header("Veiw limits")]
    [SerializeField] private float bottomViewLimit;
    [SerializeField] private float topViewLimit;

    private void Update()
    {
        position.x = player.position.x;
        position.y = player.position.y + camHeight;
        position.z = -10;

        direction = Input.GetAxis("Vertical");
        if(Input.GetButton("Vertical"))
        {
            if(direction > 0)
                transform.position = Vector3.Lerp(transform.position, position + new Vector3(0f, topViewLimit, 0f), camSpeed * Time.deltaTime);
            else if (direction < 0)
                transform.position = Vector3.Lerp(transform.position, position + new Vector3(0f, bottomViewLimit, 0f), camSpeed * Time.deltaTime);
        }
        else
            transform.position = Vector3.Lerp(transform.position, position, camSpeed * Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(rightLimit, topLimit));
    }
}
