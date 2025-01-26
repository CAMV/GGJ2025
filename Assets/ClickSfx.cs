using UnityEngine;

public class ClickSfx : MonoBehaviour
{
    [SerializeField]
    private AudioSource _clickAS;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           _clickAS.Stop();
            _clickAS.Play();
        }

    }
}
