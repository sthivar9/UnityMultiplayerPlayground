using DilmerGames.Core.Singletons;
using Unity.Netcode;

public class PlayersManager : Singleton<PlayersManager>
{
    NetworkVariable<int> playersInGame = new NetworkVariable<int>();

    public int PlayersInGame
    {
        get
        {
            return playersInGame.Value;
        }
    }

    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            playersInGame.Value++;
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            playersInGame.Value--;
        };
    }
}