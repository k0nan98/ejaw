using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
public class GeometryObjectModel : MonoBehaviour
{
    public Settings objectSettings;
    
    uint clicksCount;
    CompositeDisposable disposables;

    float colorSaturation;
    Color currentCol;
    Color nextCol;
    public GameObject getAsset()
    {
        return objectSettings.GetMesh();
    }
    public string getObjectName()
    {
        return objectSettings.getName();
    }
    public uint getClicksCount()
    {
        return clicksCount;
    }
    public float GetColorSaturation()
    {
        return colorSaturation;
    }
    public void Click()
    {
        clicksCount++;
        SetColor(objectSettings.GetColor(clicksCount));
    }

    public void SetColor(Color newColor)
    {
        nextCol = newColor;
        colorSaturation = 0;
    }

    private void Start()
    {
        colorSaturation = 1;
        currentCol = this.GetComponent<MeshRenderer>().material.color;
    }
    public void SetTimer(float time)
    {
        if(disposables != null)
        {
            disposables.Dispose();
        }
        disposables = new CompositeDisposable();
        Observable.Timer(System.TimeSpan.FromSeconds(time))
    .Repeat()
    .Subscribe(_ => {
        SetColor(objectSettings.GetRandomColor());
    }).AddTo(disposables);
    }
    public void Update()
    {
        if(colorSaturation < 1)
        {
            colorSaturation += Time.deltaTime*0.6f;
            currentCol = Color.Lerp(currentCol, nextCol, colorSaturation);
            this.GetComponent<MeshRenderer>().material.color = currentCol;
        }

    }
    void OnDisable()
    { 
        if (disposables != null)
        {
            disposables.Dispose();
        }
    }
}
