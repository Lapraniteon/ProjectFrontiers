using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{

    public Image overlay;
    public Image[] panels;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Cutscene()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            Tween fadeIn = overlay.DOFade(0f, 0.5f);
            yield return fadeIn.WaitForCompletion();
            yield return new WaitForSeconds(4f);
            Tween fadeOut = overlay.DOFade(1f, 0.5f);
            yield return fadeOut.WaitForCompletion();
            panels[i].gameObject.SetActive(false);
        }
    }
}
