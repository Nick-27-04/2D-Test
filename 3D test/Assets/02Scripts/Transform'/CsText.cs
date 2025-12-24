using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //추가

public class CsText : MonoBehaviour
{
    public string words = "GoodBye World";
    //게임오브젝트 타입의 변수 선언
    GameObject obj;
    //텍스트 타입의 변수 선언
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        //게임오브젝트 "txtCenter"를 찾아서 obj에 대입
        obj = GameObject.Find("txtCenter");
        // obj에서 Text 컴포넌트를 txt에 대입
        txt = obj.GetComponent<Text>();//GameObject.Find("txtCenter").GetComponent<Text>()
                                       // txt.text = words; 
                                       // obj.GetComponent<Text>().text = words;


        //메서드 호출
        ChangeText();
    }

    void ChangeText()
    {
        //txtCenter 게임오브젝트의 Text컴포넌의 
        //text 값을 "GoodBye World"로 설정
        Debug.Log(txt.text);  //Helloe World
        txt.text = words;
        //Debug.Log(txt.text)  //GoodBye World
    }

}
