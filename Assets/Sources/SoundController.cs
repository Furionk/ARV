using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.SceneManagement;
using Vuforia;
using Zenject;

public class SoundController : MonoBehaviour {

    [Inject]
    public DiContainer Container;

    public void Awake() {
        this.gameObject.AddComponent<AudioListener>();
        var bgmAudioSource = this.gameObject.AddComponent<AudioSource>();
        bgmAudioSource.loop = true;
        bgmAudioSource.clip = Resources.Load<AudioClip>("Music/Background_Soundtrack");
        bgmAudioSource.Play();
        Container.Bind<AudioSource>().WithId("BGMAudio").FromInstance(bgmAudioSource);



    }


}
