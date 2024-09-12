using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : MonoBehaviour
{
    [SerializeField] Image screenInage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);  
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AsyncLoad(1));
        }
    }

    public IEnumerator FadeIn()
    {
        screenInage.gameObject.SetActive(true);

        Color color = screenInage.color;

        color.a = 1f;

        while(color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;

            screenInage.color = color;

            yield return null;
        }

        screenInage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(int index)
    {
        screenInage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        asyncOperation.allowSceneActivation = false;
        // allowSceneActivation : 장면이 준비된 즉시 장면이 활성화되는 것을 허용하는 변수.

        Color color = screenInage.color;

        color.a = 0;

        while(asyncOperation.isDone == false)
        // isDone : 해당 동적이 완료되었는지 나타내는 변수. (읽기 전용)
        {
            color.a += Time.deltaTime;

            screenInage.color = color;

            if(asyncOperation.progress >= 0.9f)
            // progress : 작업의 진행 상태를 나타내는 변수. (읽기 전용)
            {
                color.a = Mathf.Lerp(color.a,1f,Time.deltaTime);

                screenInage.color = color;

                if(color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }

            yield return null;
        }
    }

    void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
