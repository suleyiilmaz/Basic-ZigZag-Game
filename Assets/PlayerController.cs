using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    delegate void TurnDelegate();
    TurnDelegate turnDelegate;
    // Start is called before the first frame update
    public float moveSpeed = 2;
    bool lookingRight = true;
    GameManager gameManager;
    Animator anim;
    public Transform rayOrigin;
    public Text scoreTxt, HscoreTxt;
    public int score { get; private set; }
    public int Hscore { get; private set; }
    public ParticleSystem effect;
    void Start()
    {

        #region PLATFORM FOR TURNING
#if UNITY_EDITOR
        turnDelegate = TurnPlayerUsingKeyboard;
#endif
#if UNITY_ANDROID
        turnDelegate = TurnPlayerUsingTouch;
#endif
        #endregion

        gameManager = FindObjectOfType<GameManager>();
        anim = gameObject.GetComponent<Animator>();
        LoadHighScore();
    }

        // Update is called once per frame
        void Update()
    {

        

        if (!gameManager.gameStarted) return;

        anim.SetTrigger("gameStarted");
        moveSpeed *= 1.0001f;
        transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
        turnDelegate();
        CheckFalling();


    }

    private void TurnPlayerUsingKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Turn();
        }
    }
    private void TurnPlayerUsingTouch()
    {
        if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)
        {
            Turn();
        }
    }

    float elapsedTime = 0;
        float freq = 1 / 5f;

         void CheckFalling()
        {
            if ((elapsedTime += Time.deltaTime) > freq)  //0.2den büyükse yani snde 40kez değil 5 kez çağırılır
            {
                if (!Physics.Raycast(rayOrigin.position, new Vector3(0, -1, 0))) //ışın y ekseninde aşağı doğru geldiğinde nesne yoksa
                {
                    anim.SetTrigger("falling");
                    gameManager.RestartGame();
                    elapsedTime = 0;

                }

            }
        }
        
  

        void Turn()
        {
            if (lookingRight)
            {
                transform.Rotate(new Vector3(0, 1, 0), -90);
            }
            else
            {
                transform.Rotate(new Vector3(0, 1, 0), 90);
            }
            lookingRight = !lookingRight;
        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("crystal"))
        {
            MakeScore();
            CreateEffect();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Destroy(collision.gameObject, 2f);
    }

    private void CreateEffect()
    {
        var vfx = Instantiate(effect, transform);
        Destroy(vfx, 0.5f);
    }

    private void MakeScore()
    {
        score++;
        scoreTxt.text = score.ToString();
        if (score > Hscore)
        {
            Hscore = score;
            HscoreTxt.text = Hscore.ToString();
            PlayerPrefs.SetInt("hiscore", Hscore);
        }
    }

    private void LoadHighScore()
    {
        Hscore = PlayerPrefs.GetInt("hiscore");
        HscoreTxt.text = Hscore.ToString();
    }
}
