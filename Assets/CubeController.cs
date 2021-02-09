using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;
    //消滅位置
    private float deadLine = -10;
    //積まれる音
    public AudioClip ac;
    AudioSource stackSound;

    // Start is called before the first frame update
    void Start()
    {
        stackSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.ToString() == "CubeTag" || collision.gameObject.tag.ToString() == "GroundTag")
        {
            stackSound.PlayOneShot(ac);

        }
    }

}
