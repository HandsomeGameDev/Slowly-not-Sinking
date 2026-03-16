using UnityEngine;

public class MovingAroundScript : MonoBehaviour
{
    public float xWave = 10f;
    public float yWave = 20f;
    public float PhaseChange = .3f;
    public RectTransform RTransform;
    void Update()
    {
        PhaseChange += Time.deltaTime;
        RTransform.anchoredPosition = new Vector3(Mathf.Sin(Time.time + PhaseChange) * xWave, Mathf.Sin(Time.time) * yWave, 0);
    }
}
