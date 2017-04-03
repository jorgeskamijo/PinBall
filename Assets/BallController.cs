using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //Text用変数
    public Text scoreText;
    //スコア計算用変数
    private int score = 0;


    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //初期スコアを代入して画面に表示
        scoreText.text = "Score: 0"; 
    }
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // タグによって点数を変える
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 30;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 40;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 20;
        }

        //スコアを更新して表示
        scoreText.text = "Score: " + score.ToString();
    }

        // Update is called once per frame
        void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
}