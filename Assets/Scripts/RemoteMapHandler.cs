using UnityEngine;

public abstract class RemoteMapHandler<T> : MonoBehaviour
{
    private void Awake()
    {
        NetworkManager.OnConnected += Initialize;
    }

    public abstract void Initialize();
    public abstract void OnAdded(string key, T entity);
    public abstract void OnRemoved(string key, T entity);
}