using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Canvas canvas;
    public FruitSpawner spawner;

    public void StartGame()
    {
        canvas.enabled = false;
        spawner.StartSpawning();
    }

    public void EndGame()
    {
        canvas.enabled = true;
        spawner.StopSpawning();
    }

}
