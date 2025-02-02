using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;
using System;

public class ShowImage : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private Image image;

    [SerializeField]
    private RawImage rawImage;

    [SerializeField]
    private String imageName;

    private bool isBuiltinImage = true;

    async void Start()
    {
        if (image == null)
        {
            isBuiltinImage = false;
        }

        await UniTask.Delay(TimeSpan.FromSeconds(3f));

        Debug.Log($"DelayTest:{0}");
    }

    void Update()
    {
        
    }
}
