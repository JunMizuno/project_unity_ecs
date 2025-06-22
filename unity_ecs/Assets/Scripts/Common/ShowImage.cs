using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public sealed class ShowImage : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private Image image;

    [SerializeField]
    private RawImage rawImage;

    [SerializeField]
    private String imageName;

    [SerializeField]
    private bool rawImageTypeA = false;
    
    [SerializeField]
    private bool rawImageTypeB = false;

    private bool isBuiltinImage = false;

    private bool isButtonTapped = false;

    private async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1f));

        Debug.Log($"DelayTest:{1}second(s)");

        if (!rawImageTypeA && !rawImageTypeB)
        {
            isBuiltinImage = true;
            AddButtonEventForImage();
            
            Debug.Log($"BuiltinImage");
        }

        if (!isBuiltinImage)
        {
            AddButtonEventForRawImage();

            Debug.Log($"RawImageA:{rawImageTypeA}, RawImageB:{rawImageTypeB}");
        }
    }

    private void Update()
    {

    }

    private void OnDestroy()
    {

    }

    private void AddButtonEventForImage()
    {
        if (button == null)
        {
            return;
        }

        button.OnClickAsObservable()
            .Subscribe(async _ => 
            {
                if (isButtonTapped)
                {
                    return;
                }

                if (image == null)
                {
                    return;
                }

                isButtonTapped = true;

                var downloadSize = await Addressables.GetDownloadSizeAsync("ushi_texas_tornado").Task;
                Debug.Log($"downloadSize:{downloadSize}");
                
                var loadedSprite = await Addressables.LoadAssetAsync<Texture2D>("ushi_texas_tornado").Task;
                if (loadedSprite != null)
                {
                    var sprite = Sprite.Create(loadedSprite, new Rect(0, 0, loadedSprite.width, loadedSprite.height), new Vector2(0.5f, 0.5f));
                    image.sprite = sprite;
                }
                else
                {
                    Debug.Log($"Image is null");
                }

                await UniTask.Delay(TimeSpan.FromSeconds(2f));

                isButtonTapped = false;
            })
            .AddTo(this);
    }

    private void AddButtonEventForRawImage()
    {
        if (button == null)
        {
            return;
        }

        button.OnClickAsObservable()
            .Subscribe(async _ =>
            {
                if (isButtonTapped)
                {
                    return;
                }

                isButtonTapped = true;

                var downloadSize = await Addressables.GetDownloadSizeAsync("ushi_texas_tornado").Task;
                if (downloadSize > 0)
                {

                }

                await UniTask.Delay(TimeSpan.FromSeconds(2f));

                isButtonTapped = false;
            })
            .AddTo(this);
    }
}
