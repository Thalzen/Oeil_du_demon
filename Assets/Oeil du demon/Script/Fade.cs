using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeSceneAsyncFade(string scenename)
    {

        StartCoroutine(WaitforFade(scenename));

    }

    private IEnumerator WaitforFade(string scenename)
    {
        _animator.SetTrigger("ChangeScene");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scenename);

    }
    
    
}
