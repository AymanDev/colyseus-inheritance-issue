using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3;

    private void Update()
    {
        var dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }


        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }

        dir *= Time.deltaTime * speed;

        if (dir.sqrMagnitude <= 0)
        {
            return;
        }

        transform.position += dir;

        NetworkManager.Instance.Room.Send("move", new
        {
            transform.position.x, transform.position.y
        });
    }
}