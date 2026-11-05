using UnityEngine;
using TMPro;

public class BackstabDetector : MonoBehaviour
{
    public Transform enemy;
    public float range = 3f;
    public float behindThreshold = -0.7f;
    public TMP_Text feedbackText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))   // left mouse button
        {
            TryBackstab();
        }
    }

    void TryBackstab()
    {
        Vector3 toPlayer = transform.position - enemy.position;
        float distance = toPlayer.magnitude;
        Vector3 dir = toPlayer.normalized;

        float dot = Vector3.Dot(enemy.forward, dir);

        bool isBehind = dot <= behindThreshold;
        bool inRange  = distance <= range;

        if (isBehind && inRange)
            feedbackText.text = "Backstab Successful";
        else
            feedbackText.text = "Attack Failed";
    }
}