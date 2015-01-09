using UnityEngine;
using System.Collections;

public class EndGameTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject gameObj = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            if (gameObj != null)
            {
                GameController controller = gameObj.GetComponent<GameController>();
                controller.GameOver();
            }
        }
    }
}
