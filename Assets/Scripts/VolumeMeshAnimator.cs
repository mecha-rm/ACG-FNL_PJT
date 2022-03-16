using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Animations;

// an animator for the volumetic mesh.
public class VolumeMeshAnimator : MonoBehaviour
{
    // used to switch the animator.
    public PlaybackControls playback;

    // Start is called before the first frame update
    void Start()
    {
        // finds the playback controls.
        if (playback == null)
            playback = FindObjectOfType<PlaybackControls>();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
