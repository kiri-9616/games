using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region//インスペクター設定
    public float speed;　　　//歩く速度
    public float gravity;　　//重力
    public float jumpspeed;  //ジャンプ速度
    public float jumpHeight; //ジャンプ制限
    public float runspeed;   //走る速度
    public float JumpLimitTime;//ジャンプの制限時間
   
    public GroundChecker ground;//接地判定
    public GroundChecker head;//天井判定
    public DiveChecker dive;

    public AnimationCurve dashcurve;
    public AnimationCurve jumpcurve;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private Animator anim = null;

    private float xspeed;
    private float yspeed;
    private float jumpPos = 0.0f;
    private float dashtime, jumptime;
    private float beforekey;
    //private float JumpCoolTime = 0.0f;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isWalk = false;
    private bool isDive = false;

    private bool disable = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定//
        isGround = ground.isGround;
        //天井判定//
        isHead = head.isGround;

        isDive = dive.isDive;

        if (isDive)
        {
            DisableFlag();
        }

        if (disable)
        {
            StopControl();
        }

        if (!disable)
        {

            //X,Y軸の速度を得る//
            xspeed = GetXspeed();
            yspeed = GetYspeed();



            //移動//
            rb.velocity = new Vector2(xspeed, yspeed);
        }
        //アニメーションの適用//
            SetAnimation();
    }

    #region//Y軸速度（GetYspeed）
    private float GetYspeed()
    {
        float yspeed = -gravity;
        float verticalkey = Input.GetAxis("Vertical");
      
        if (isGround)
        {
            

            if (verticalkey > 0 /*&& JumpCoolTime <= 0.0f*/)
            {
                yspeed = jumpspeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumptime = 0.0f;
                //JumpCoolTime = 0.5f;

                
            }
            else
            {
                isJump = false;
               
            }
        }
        else if (isJump)
        {
           
            if (verticalkey > 0 && jumpPos + jumpHeight > transform.position.y && !isHead && jumptime < JumpLimitTime)
            {
                yspeed = jumpspeed;
                jumptime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumptime = 0.0f;
               
            }
        }

        if (isJump)
        {
            yspeed *= jumpcurve.Evaluate(jumptime);
        }
        return yspeed;
    }
    #endregion

    #region//X軸族度（GetXspeed）
    private float GetXspeed()
    {
        float xspeed = 0.0f;
        float horizontalkey = Input.GetAxis("Horizontal");

        //右移動速度決定//
        if (horizontalkey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

            //走り
            if (Input.GetKey(KeyCode.LeftShift))
            {
                xspeed = runspeed;
                dashtime += Time.deltaTime;
                xspeed *= dashcurve.Evaluate(dashtime);

                isRun = true;
                isWalk = false;
            }
            //歩き
            else
            {
                xspeed = speed;
                dashtime = 0.0f;

                isWalk = true;
                isRun = false;
            }
            
        }
        //左移動速度決定//
        else if (horizontalkey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

            //走り
            if (Input.GetKey(KeyCode.LeftShift))
            {
                xspeed = -runspeed;
                dashtime += Time.deltaTime;
                xspeed *= dashcurve.Evaluate(dashtime);

                isRun = true;
                isWalk = false;
            }
            //歩き
            else
            {
                xspeed = -speed;
                dashtime = 0.0f;

                isWalk = true;
                isRun = false;
            }

        }
        //立ち状態//
        else
        {
            dashtime = 0.0f;
            isWalk = false;
            isRun = false;
            
        }

        //ダッシュ反転の際に速度を殺す//
        if(horizontalkey > 0 && beforekey < 0)
        {
            dashtime = 0.0f;
        }
        else if (horizontalkey < 0 && beforekey > 0)
        {
            dashtime = 0.0f;
        }
        beforekey = horizontalkey;

        //ジャンプのクールタイム消費//
       /* if(JumpCoolTime > 0.0f && isGround)
        {
            JumpCoolTime -= Time.deltaTime;
        }*/

        return xspeed;

    }
    #endregion

    #region//アニメーション設定
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
        anim.SetBool("walk", isWalk);
        anim.SetBool("dive", isDive);
    }
    #endregion

    #region//コントロール停止（StopControl）
    private void StopControl()
    {
        isJump = false;
        isGround = false;
        isRun = false;
        isWalk = false;

        rb.velocity = new Vector2(0, 0);
    }
    #endregion

    #region//停止フラグ
    private void DisableFlag()
    {
        disable = true;
        
    }
    #endregion


}













