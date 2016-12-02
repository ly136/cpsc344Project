using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RespawnInHub : MonoBehaviour {

	// Reload Scene if Player enters RespawnZone

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
