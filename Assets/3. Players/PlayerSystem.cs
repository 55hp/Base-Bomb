using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : Singleton<PlayerSystem>
{
    // Start is called before the first frame update

    [SerializeField] GameObject[] playersPrefabs;
    GameObject actualPlayer;

    [SerializeField] float startingTime;
    [SerializeField] float delayTime;

    public void GoPlayers()
    {
        InvokeRepeating("GenPlayer", startingTime, delayTime);
    }

    public void GenPlayer()
    {
        if(actualPlayer != null)
        {
            Destroy(actualPlayer);
        }
        actualPlayer = Instantiate(playersPrefabs[Random.Range(0, playersPrefabs.Length)]);
    }

    public void StopPlayerGeneration()
    {
        Destroy(actualPlayer);
        CancelInvoke();
    }
}
