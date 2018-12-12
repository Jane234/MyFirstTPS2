using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCure : MonoBehaviour {

    public int HP = 100;
    public int Energy = 0;

    //能量随时间减少的计时器
    float _energyTimer = 0;

    //能量提供的血量恢复计时器
    float _energyHPTimer = 0;


	// Use this for initialization
	void Start () {

        if (HP > 100)
        {
            HP = 100;
        }
	}
	
	// Update is called once per frame
	void Update () {


        EnergyUpdate();
        KeyUpdate();

        if (Input.GetKeyDown(KeyCode.Alpha0)) {

            int damage = Random.Range(0, HP );
            HP -= damage;
            Debug.Log("你被打了，现在血量是："+HP);
        }


    }
    //能量更新
    void EnergyUpdate() {
             if (Energy > 0) {

                        _energyTimer += Time.deltaTime;

                        //每3秒减少1点能量
                        if (_energyTimer >=3 ) {

                            Energy  -=  1;
                            _energyTimer = 0;

                        }
                        if (HP < 100)
                        {

                            _energyHPTimer += Time.deltaTime;

                            //每8秒回血
                            if (_energyHPTimer >= 8)
                            {

                                //TODO根据能量值回血
                                if (Energy <= 20)
                                {

                                    HP += 1;
                                }
                                else if (Energy <= 60)
                                {
                                    HP += 2;
                                }

                                else if (Energy <= 90)
                                {
                                   HP += 3;
                                }
                                else
                                {
                                   HP += 4;
                                }
                                if (HP > 100)
                                {
                                    HP = 100;
                                }

                                Debug.Log("血量恢复到：" + HP);

                                _energyHPTimer = 0;


                            }
                        }
                    }
    }

    //检测键盘按键
    void KeyUpdate() {
        if (Input.GetKeyDown (KeyCode.Alpha1)) {

            UseBandage();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            UseFirstAidKit();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            UseMedicalBox();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            UseRedBull();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            UseAnodyne();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {

            UseAdrenaline();
        }
    }
    void UseBandage() {

        if (HP>=75) {

            Debug.Log("血量大于等于75时，绷带无法使用");
            return;
        }

        HP += 10;
        if (HP >75) {
            HP = 75;
        }
        Debug.Log("使用了绷带，血量恢复到："+HP);
    }
    void UseFirstAidKit() {
        if (HP >= 75)
        {

            Debug.Log("血量大于等于75时，急救包无法使用");
            return;
        }
        HP = 75;
        
        Debug.Log("使用了急救包，血量恢复到：" + HP);
    }
    void UseMedicalBox() {

        HP = 100;

        Debug.Log("使用了医疗箱，血量恢复到：" + HP);
    }
    void UseRedBull() {

        Energy += 40;
        if (Energy  >100)
        {
            Energy  = 100;
        }

        Debug.Log("使用了红牛，能量恢复到：" + Energy);

    }
    void UseAnodyne() {

        Energy += 60;
        if (Energy > 100)
        {
            Energy = 100;
        }

        Debug.Log("使用了止痛药，能量恢复到：" + Energy);

    }
    void UseAdrenaline() {

        Energy = 100;
        
        Debug.Log("使用了红牛，能量恢复到：" + Energy);
    }
}
