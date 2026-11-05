using UnityEngine;
using UnityEngine.UI;

public class BackstabDetector : MonoBehaviour
{
    public Transform enemy;          // enemy transform
    public float range = 3f;
    public float behindThreshold = -0.7f; // -1 = directly behind
    public Text feedbackText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // attack key
        {
            TryBackstab();
        }
    }

    void TryBackstab()
    {
        Vector3 toPlayer = transform.position - enemy.position;
        float distance = toPlayer.magnitude;
        Vector3 dir = toPlayer.normalized;

        float dot = Vector3.Dot(enemy.forward, dir); // enemy's forward vs direction to player

        bool isBehind = dot <= behindThreshold;
        bool inRange  = distance <= range;

        if (isBehind && inRange)
            feedbackText.text = "Backstab Successful";
        else
            feedbackText.text = "Attack Failed";
    }
}