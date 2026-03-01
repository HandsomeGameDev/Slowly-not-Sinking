using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraProcessing : MonoBehaviour
{
    public Volume vol;
    private Vignette vign;
    private ColorAdjustments coladj;
    public int rColorAdj = 51;
    public int gColorAdj = 91;
    public int bColorAdj = 144;
    private float depth = 0.0f;

    void Start()
    {
        if (vol.profile.TryGet(out vign)){}
        if(vol.profile.TryGet(out coladj)){}
    }

    void FixedUpdate()
    {
        Debug.Log(coladj.colorFilter);
        Debug.Log(vign.color);
        depth = transform.position.y;
        if (depth < 0)
        {
            vign.intensity.value = 0.75f * (Mathf.Max(-70.0f, depth)/ -70.0f);
            rColorAdj = (int)Mathf.Lerp(69, 34, Mathf.Max(-70.0f, depth)/-70.0f);
            gColorAdj = (int)Mathf.Lerp(100, 50, Mathf.Max(-70.0f, depth)/-70.0f);
            bColorAdj = (int)Mathf.Lerp(156, 78, Mathf.Max(-70.0f, depth)/-70.0f);
            coladj.colorFilter.value = new Color32((byte)rColorAdj, (byte)gColorAdj, (byte)bColorAdj, 255);
        }
        else
        {
            vign.intensity.value = 0.0f;
            rColorAdj = 111;
            gColorAdj = 162;
            bColorAdj = 255;
            coladj.colorFilter.value = new Color32((byte)rColorAdj, (byte)gColorAdj, (byte)bColorAdj, 255);
        }

    }
}
