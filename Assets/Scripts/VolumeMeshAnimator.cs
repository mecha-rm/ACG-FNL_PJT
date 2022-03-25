using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// an animator for the volumetic mesh.
public class VolumeMeshAnimator : MonoBehaviour
{
    // director for running animations.
    public TimelineDirector director;

    // Start is called before the first frame update
    void Start()
    {

        // finds the playback controls.
        if (director == null)
            director = GetComponent<TimelineDirector>();

    }

    // the timeline director should play on awake.
    public bool GetPlayOnAwake()
    {
        return director.director.playOnAwake;
    }

    // set play on awake.
    public void SetPlayOnAwake(bool value)
    {
        director.director.playOnAwake = value;
    }

    // plays the animation.
    public void PlayTimeline()
    {
        director.PlayTimeline();
    }

    // pauses the animation.
    public void PauseTimeline()
    {
        director.PauseTimeline();
    }

    // stops the animation
    public void StopTimeline()
    {
        director.StopTimeline();
    }

    // adds a timeline asset.
    public void AddTimelineAsset()
    {
        // director.timelineasset.
    }

    // Update is called once per frame
    void Update()
    {
    }
}
