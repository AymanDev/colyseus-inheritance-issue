using Colyseus;
using Colyseus.Schema;
using Scripts.Schemas;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public ColyseusClient Client { get; private set; }
    public ColyseusRoom<WorldState> Room { get; private set; }

    private StateCallbackStrategy<WorldState> _callbacks;
    public StateCallbackStrategy<WorldState> Callbacks => _callbacks ??= Colyseus.Schema.Callbacks.Get(Room);


    public delegate void ConnectEvent();

    public static event ConnectEvent OnConnected;

    public static NetworkManager Instance;


    private void Awake()
    {
        Instance = this;
        Connect();
    }

    private async void Connect()
    {
        Client = new ColyseusClient("ws://localhost:2567");
        Room = await Client.JoinOrCreate<WorldState>("my_room");
        OnConnected?.Invoke();
    }
}