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
        // allowSceneActivation : ����� �غ�� ��� ����� Ȱ��ȭ�Ǵ� ���� ����ϴ� ����.

        Color color = screenInage.color;

        color.a = 0;

        while(asyncOperation.isDone == false)
        // isDone : �ش� ������ �Ϸ�Ǿ����� ��Ÿ���� ����. (�б� ����)
        {
            color.a += Time.deltaTime;

            screenInage.color = color;

            if(asyncOperation.progress >= 0.9f)
            // progress : �۾��� ���� ���¸� ��Ÿ���� ����. (�б� ����)
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
