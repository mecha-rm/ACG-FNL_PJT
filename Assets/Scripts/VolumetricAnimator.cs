using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// an animator for the volumetic mesh.
public class VolumetricAnimator : MonoBehaviour
{
    // director for running animations.
    public TimelineDirector director;

    // the input for the file for the volumetric animator.
    public InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {

        // finds the playback controls.
        if (director == null)
            director = GetComponent<TimelineDirector>();

        // check mTracks or trackObjects to see how many tracks have been made, but are not accessible at compile time.
        // output track count is 1 more than the amount of tracks.
        Debug.Log("Output Track Count: " + director.timelineasset.outputTrackCount);


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

    // adds a timeline asset using the input field for the name.
    public void CreateVolumetricRenderTrack()
    {
        // input field set.
        if(nameInputField != null)
        {
            // creates the track.
            CreateVolumetricRenderTrack(nameInputField.text);

            // clears out the text to show that it went through.
            nameInputField.text = "";

        }
        // input field not set.
        else
        {
            // creates the track with no name.
            CreateVolumetricRenderTrack("");
        }

        // track.CreateClip<>
    }

    // adds a timeline asset.
    public void CreateVolumetricRenderTrack(string name)
    {
        // creates the track.
        VolumetricRenderTrack track;
        
        if(name != "") // name provided.
            track = director.timelineasset.CreateTrack<VolumetricRenderTrack>(name);
        else // no name provided.
            track = director.timelineasset.CreateTrack<VolumetricRenderTrack>();

        // adds a clip
        // the clip cannot be grabbed.
        // track.CreateClip<VolumetricRenderClip>();
        track.CreateDefaultClip();

        // NOTE: when you add a track, it will not show up until you stop the program and run it again.
        Debug.Log("Added " + track.name + " to the Timeline Asset and gave it a clip. Stop and re-run the game to show the new track.");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
