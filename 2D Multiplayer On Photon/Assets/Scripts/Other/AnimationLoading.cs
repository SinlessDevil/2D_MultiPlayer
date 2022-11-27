using UnityEngine;
using TMPro;
using System.Collections;

public class AnimationLoading : MonoBehaviour
{
    private TMP_Text _textLoading;
    private byte amount;
    private const float WAIT_TIME = 0.4f;

    private void Start()
    {
        _textLoading = GetComponent<TMP_Text>();
        StartCoroutine(AnimLoadinCoroutine());
    }

    private IEnumerator AnimLoadinCoroutine()
    {
        while (true){
            yield return new WaitForSeconds(WAIT_TIME);
            amount++;
            if (amount <= 3){
                switch (amount){
                    case 1:
                        _textLoading.text = Dictionary.nameAnimLoadingText + ".";
                        break;
                    case 2:
                        _textLoading.text = Dictionary.nameAnimLoadingText + "..";
                        break;
                    case 3:
                        _textLoading.text = Dictionary.nameAnimLoadingText + "...";
                        break;
                }
            }else{
                _textLoading.text = Dictionary.nameAnimLoadingText;
                amount = 0;
            }
        }
    }
}
