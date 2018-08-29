using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineTrigger : MonoBehaviour {

    public PlayableDirector playableDirector;
    public TimelineAsset timeline;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
            playableDirector.playableAsset = timeline;
            playableDirector.Play();
        }
	}
}
