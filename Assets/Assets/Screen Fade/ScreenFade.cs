using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DisablePanel());
    }

    IEnumerator DisablePanel()
    {
        yield return new WaitForSeconds(1f);

        this.transform.gameObject.SetActive(false);
    }
}
