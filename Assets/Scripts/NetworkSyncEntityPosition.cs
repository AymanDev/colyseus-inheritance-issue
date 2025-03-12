using Scripts.Schemas;
using UnityEngine;

public class NetworkSyncEntityPosition : MonoBehaviour, ISetup<Vector2D>
{
    [SerializeField] private float speed = 5f;

    private Vector3 _targetPosition;


    public void Setup(Vector2D value)
    {
        transform.position = new Vector3(value.x, value.y, 0);


        NetworkManager.Instance.Callbacks.Listen(_ => value, OnChange);
    }

    private void OnChange(Vector2D current, Vector2D _)
    {
        _targetPosition = new Vector3(current.x, current.y, 0);
    }

    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, speed * Time.deltaTime);
    }
}