using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCutscene : MonoBehaviour
{

    public Image overlay;
    public Image[] panels;
    
    void Start() => StartCoroutine(Cutscene());

    IEnumerator Cutscene()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            Tween fadeIn = overlay.DOFade(0f, 0.5f);
            yield return fadeIn.WaitForCompletion();
            yield return new WaitForSeconds(6f);
            Tween fadeOut = overlay.DOFade(1f, 0.5f);
            yield return fadeOut.WaitForCompletion();
            panels[i].gameObject.SetActive(false);
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
}
