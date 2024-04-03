using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private GameObject[] Playerobjects;
    [SerializeField] private Transform ball;
    [SerializeField] private Rigidbody2D ballRB;
    [Header("KeyInput")]
    private float Horizontal1;
    private float Horizontal2;
    [Header("Values")]
    private float ballSpeed = 3f;
    private float playerSpeed = 10f;
    private float randomX;
    private float randomY;
    [Header("Text")]
    private Canvas GameOver_Canvas;
    private Score score;
    private TextMeshProUGUI playerIdent;
    [Header("Bools")]
    private bool paused = false;
    private Vector2 ballPos;
    private Vector2 p1Pos;
    private Vector2 p2Pos;

    public void Start()
    {
        ballPos = ball.position;
        p1Pos = Playerobjects[0].transform.position;
        p2Pos = Playerobjects[1].transform.position;

        ballRB.gravityScale = 0f;
        randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        randomY = Random.Range(0, 2) == 0 ? -1 : 1;
        ballRB.velocity = new Vector2(ballSpeed * randomX, ballSpeed * randomY);

        score = GameObject.Find("ScoreCanvas").GetComponent<Score>();
        playerIdent = GameObject.Find("GameOver").GetComponent<TextMeshProUGUI>();
        GameOver_Canvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        GameOver_Canvas.enabled = false;
    }

    public void Update()
    {
        Debug.Log("test");
        Horizontal1 = Input.GetAxis("Horizontal1");
        Horizontal2 = Input.GetAxis("Horizontal2");
        Playerobjects[0].transform.position = Playerobjects[0].transform.position + new Vector3(Horizontal1 * playerSpeed * Time.deltaTime, 0, 0);
        Playerobjects[1].transform.position = Playerobjects[1].transform.position + new Vector3(Horizontal2 * playerSpeed * Time.deltaTime, 0, 0);

        if(ball.position.y < -5 &! paused)
        {
            score.scorePlayer1 += 1;
            score.AddScore(true);
            paused = true;
            GameOver_Canvas.enabled = true;
            playerIdent.text = "Player 1 Won!";
        }

        if (ball.position.y > 5 &! paused)
        {
            score.scorePlayer2 += 1;
            score.AddScore(false);
            paused = true;
            GameOver_Canvas.enabled = true;
            playerIdent.text = "Player 2 Won!";
        }

        if(paused)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameOver_Canvas.enabled = false;
                paused = false;
                Reset();
            }
        }
    }

    private void Reset()
    {
        Playerobjects[0].transform.position = p1Pos;
        Playerobjects[1].transform.position = p2Pos;
        ball.position = ballPos;
    }
}
