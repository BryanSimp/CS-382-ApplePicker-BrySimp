using UnityEngine;
using TMPro;
public class Rounds : MonoBehaviour
{
    [Header("Dynamic")]
    public int level = 1;
    private TMP_Text uiText;
    void Start()
    {
        uiText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Round: " + level.ToString();
    }
}
