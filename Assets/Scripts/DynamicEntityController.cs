using Scripts.Schemas;
using UnityEngine;

[RequireComponent(typeof(NetworkSyncEntityPosition))]
public class DynamicEntityController : MonoBehaviour, ISetup<Entity>
{
    private NetworkSyncEntityPosition _remotePosition;

    private void Awake()
    {
        _remotePosition = GetComponent<NetworkSyncEntityPosition>();
    }

    public void Setup(Entity value)
    {
        _remotePosition.Setup(value.position);
    }
}