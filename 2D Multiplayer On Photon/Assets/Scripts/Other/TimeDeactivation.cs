using UnityEngine;
using System.Collections;

public class TimeDeactivation : MonoBehaviour
{
    private const float WAIT_TIME = 3f;
    private void Start(){
        StartCoroutine(TimeDeactivationCoroutine());
    }

    private IEnumerator TimeDeactivationCoroutine(){
        yield return new WaitForSeconds(WAIT_TIME);
        this.gameObject.SetActive(false);
    }
}
