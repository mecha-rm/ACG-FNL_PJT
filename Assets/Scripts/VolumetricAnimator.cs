/*
 * References:
 *  - https://forum.unity.com/threads/get-all-grouptrack-in-timeline.512140/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

// an animator for the volumetic mesh.
public class VolumetricAnimator : MonoBehaviour
{
    // an enum for the list of tracks.
    public enum trackType { activation, animation, audio, control, signal, playable, volumetric }

    // director for running animations.
    public TimelineDirector director;

    // the input for the file for the volumetric animator.
    public InputField nameInputField;

    // the input field for the group the track goes into.
    public InputField groupInputField;

    // the dropdown for the track type.
    public Dropdown trackTypeDropdown;

    // the amount of tracks.
    public Text trackCountText;

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

    // gets the track name from the enum.
    public string TrackTypeNameFromEnum(trackType type)
    {
        // the name string
        string nameStr;

        // checks the type.
        switch (type)
        {
            case trackType.activation:
                nameStr = "Activation Track";
                break;

            case trackType.animation:
                nameStr = "Animation Track";
                break;

            case trackType.audio:
                nameStr = "Audio Track";
                break;

            case trackType.control:
                nameStr = "Control Track";
                break;

            case trackType.signal:
                nameStr = "Signal Track";
                break;

            case trackType.playable:
                nameStr = "Playable Track";

                break;

            case trackType.volumetric:
                nameStr = "Volumetric Render Track";
                break;

            default: // none
                nameStr = "";
                
                break;
        }

        // returns the name string.
        return nameStr;
    }

    // creates a track.
    public void CreateTrack()
    {
        // grabs the name of the selection.
        string typeStr = trackTypeDropdown.options[trackTypeDropdown.value].text;
        
        // the type that will be set.
        trackType typeEnum;

        // the track name and track group name.
        string trackName = "", trackGroupName = "";

        // checks what type of track to generate.
        if(typeStr == "Activation Track")
        {
            typeEnum = trackType.activation;
        }
        else if(typeStr == "Animation Track")
        {
            typeEnum = trackType.animation;
        }
        else if(typeStr == "Audio Track")
        {
            typeEnum = trackType.audio;
        }
        else if (typeStr == "Control Track")
        {
            typeEnum = trackType.control;
        }
        else if (typeStr == "Signal Track")
        {
            typeEnum = trackType.signal;
        }
        else if (typeStr == "Playable Track")
        {
            typeEnum = trackType.playable;
        }
        else if(typeStr == "Volumetric Render Track")
        {
            typeEnum = trackType.volumetric;
        }
        else // defaults to a volumetric render track.
        {
            // generates and returns the track.
            CreateVolumetricRenderTrack();
            return;
        }

        // NAME //
        // name input field set, so use the name saved there.
        if (nameInputField != null)
        {
            // grabs the name.
            trackName = nameInputField.text;

            // clears out the text to show that the input went through.
            nameInputField.text = "";

        }

        // GROUP //
        // group input field set, so use the group saved there.
        if (groupInputField != null)
        {
            // grabs the group.
            trackGroupName = groupInputField.text;

            // clears out the text to show that the input went through.
            groupInputField.text = "";

        }

        // creates the track.
        CreateTrack(typeEnum, trackName, trackGroupName);
    }

    // creates a track.
    public void CreateTrack(trackType type, string trackName, string groupName)
    {
        // activation, animation, audio, control, signal, playable, volumetric 
        TrackAsset track;

        // checks the type.
        switch(type)
        {
            case trackType.activation:
                if (name != "") // name provided.
                    track = director.timelineasset.CreateTrack<ActivationTrack>(trackName);
                else // no name provided.
                    track = director.timelineasset.CreateTrack<ActivationTrack>();
                
                break;

            case trackType.animation:
                if (name != "") // name provided.
                    track = director.timelineasset.CreateTrack<AnimationTrack>(trackName);
                else // no name provided.
                    track = director.timelineasset.CreateTrack<AnimationTrack>();

                break;

            case trackType.audio:
                if (name != "") // name provided.
                    track = director.timelineasset.CreateTrack<AudioTrack>(trackName);
                else // no name provided.
                    track = director.timelineasset.CreateTrack<AudioTrack>();

                break;

            case trackType.control:
                if (name != "") // name provided.
                    track = director.timelineasset.CreateTrack<ControlTrack>(trackName);
                else // no name provided.
                    track = director.timelineasset.CreateTrack<ControlTrack>();

                break;

            case trackType.signal:
                if (name != "") // name provided.
                    track = director.timelineasset.CreateTrack<SignalTrack>(trackName);
                else // no name provided.
                    track = director.timelineasset.CreateTrack<SignalTrack>();

                break;

            case trackType.playable:
                if (name != "") // name provided.
                    track = director.timelineasset.CreateTrack<PlayableTrack>(trackName);
                else // no name provided.
                    track = director.timelineasset.CreateTrack<PlayableTrack>();

                break;

            case trackType.volumetric: // main one
            default:
                if (name != "") // name provided.
                    track = director.timelineasset.CreateTrack<VolumetricRenderTrack>(trackName);
                else // no name provided.
                    track = director.timelineasset.CreateTrack<VolumetricRenderTrack>();

                break;

        }

        // creates the default clip for the track.
        track.CreateDefaultClip();

        // NOTE: when you add a track, it will not show up until you stop the program and run it again.
        Debug.Log("Added " + TrackTypeNameFromEnum(type) + " named \"" + track.name + "\" to the Timeline Asset and gave it a clip. " +
            "Click off the timeline object, and then click back on it to view the new track.");
    }


    // originally called by the button.
    // VOLUMETRIC RENDER TRACK 
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
        // the clip cannot be grabbed for some reason.
        track.CreateDefaultClip();

        // NOTE: when you add a track, it will not show up until you stop the program and run it again.
        Debug.Log("Added " + track.name + " to the Timeline Asset and gave it a clip. " +
            "Click off the timeline object, and then click back on it to view the new track.");
    
    }

    // Update is called once per frame
    void Update()
    {
        // updates the text.
        if (trackCountText != null && director != null)
        {
            // the amount of tracks (this is +1 of the amount of output tracks)
            int clipCount = director.timelineasset.outputTrackCount - 1;

            // updates the text.
            trackCountText.text = "Track Count: " + clipCount.ToString("000");
        }
    }
}
