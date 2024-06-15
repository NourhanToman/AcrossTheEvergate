using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DistanceShader : MonoBehaviour
{
    public float distanceValue;
    [SerializeField] private string DissolveColorReferance;
    [SerializeField] private Color DissolveColor;
    [SerializeField] private int Intensity;
    [SerializeField] private string distanceReferance;
    [SerializeField] private string playerPosition;
    [SerializeField] private float maxDistance;
    [SerializeField] private float minmummDistance;
    private float referancevelo;
    public bool activate;
    [SerializeField] private GameObject player;
    public Volume globalVolume;
    private ChromaticAberration chromaticAberration; // Reference to the Chromatic Aberration effect
    public float DissolveTime;
    public float ReverseTime;
    private bool playingMusic;
    public bool pause;

    private void Start()
    {
        pause = false;
        activate = false;
        playingMusic = false;
        DissolveColor *= Intensity;
        Shader.SetGlobalColor(DissolveColorReferance, DissolveColor);
        referancevelo = 0;
    }

    void Update()
    {
        changeDistance();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Shader.SetGlobalVector(playerPosition, player.transform.position);
            activate = !activate;
        }
        ReveilOjects();
    }

    private void changeDistance()
    {
        Shader.SetGlobalFloat(distanceReferance, distanceValue);
    }

    public void ReveilOjects()
    {
        Shader.SetGlobalVector(playerPosition, player.transform.position);

        if (activate && pause == false)
        {
            distanceValue = Mathf.SmoothDamp(distanceValue, maxDistance, ref referancevelo , DissolveTime);
            if(playingMusic == false)
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlaySFX("TimeTravel");
                playingMusic = true;
            }
        }
        else if(activate == false && pause == false)
        {
           distanceValue = Mathf.SmoothDamp(distanceValue, minmummDistance, ref referancevelo, ReverseTime);
        }
    }
}
