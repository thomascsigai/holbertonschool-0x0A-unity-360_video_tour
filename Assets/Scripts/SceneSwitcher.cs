using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    private List<GameObject> sceneObjects;

    private void Awake()
    {
        sceneObjects = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            sceneObjects.Add(transform.GetChild(i).gameObject);
            sceneObjects[i].SetActive(false);
        }

        sceneObjects[0].SetActive(true);
    }

    public void SwitchScene(VideoClip videoClip)
    {
        if (videoPlayer.clip != videoClip)
            videoPlayer.clip = videoClip;

        foreach (var sceneObject in sceneObjects)
        {
            if (videoClip.name.Equals(sceneObject.name))
                sceneObject.SetActive(true);
            else
                sceneObject.SetActive(false);
        }
    }
}
