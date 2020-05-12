using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("Game Session").SendMessage("Finish");
        SceneManager.LoadScene("Game Over");
    }

}
