using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_Manager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        // 대화 data
        // NPC : 1000 번대
        // 사물 : 100 번대

        talkData.Add(100000, new string[] { "1000번 대사:1", "2번째 대사:2" });
        talkData.Add(2000, new string[] { "2000번 대사:0", "2번째 대사:1" });
        talkData.Add(3000, new string[] { "우울? [어디한번 해봐...]:3", });

        talkData.Add(100, new string[] { "carpet" });
        talkData.Add(200, new string[] { "아이템이 부족한거 같다. 퍼즐을 풀고 아이템을 모아오자" });       
        talkData.Add(300, new string[] { "움직이는 노트가 재료칸에 들어갔을 때 스페이스바를 눌러 재료를 담아보자!" });
        talkData.Add(400, new string[] { "가운데에 온도 조절 버튼을 눌러 온도를 맞춰보자!" });
        talkData.Add(500, new string[] { "num4" });
        talkData.Add(600, new string[] { "열쇠를 획득했다!"});
        // InnerRoom 전용 30000번대

      
        talkData.Add(30000, new string[] { "여긴 너무 어두운걸.....:1", "불을 켤만한 게 있을까..?:0" });
        talkData.Add(100+30000, new string[] { "방이 밝아졌다." });
        talkData.Add(200 + 30000, new string[] { "침대에 무언가가...?:1","확인해볼까?:0" });

        talkData.Add(35100, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35200, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35300, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35400, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35500, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35600, new string[] { "순서대로 확인해봐야될거같아.:0" });
        talkData.Add(35700, new string[] { "토끼 인형을 발견했다." });
        // InnerRoom quest


        talkData.Add(60 + 35400, new string[] { "다음으로 넘어가자.:0" });
        talkData.Add(61 + 35500, new string[] { "다음으로 넘어가자.:0" });

        talkData.Add(70 + 35200, new string[] { "다음으로 넘어가자.:0" });
        talkData.Add(71 + 35300, new string[] { "다음으로 넘어가자.:0" });

        talkData.Add(80 + 35600, new string[] { "다음으로 넘어가자.:0" });
        talkData.Add(81 + 35100, new string[] { "무언가가 있는거 같아.:0" });
        talkData.Add(90 + 35100, new string[] { "인형이 놓여있던 장소야.:0" });

        // Boss 40000번대
        talkData.Add(0 + 40000, new string[] { "이게 뭐야?? 왜 마당에 이런 게...?:1" });
        talkData.Add(0 + 41000, new string[] { "제단이 나왔어...:0" });
        talkData.Add(0 + 40100, new string[] { "개껌을 올려두었다." });
        talkData.Add(0 + 40200, new string[] { "오리 인형을 올려두었다." });
        talkData.Add(0 + 40300, new string[] { "토끼 인형을 올려두었다." });

        talkData.Add(0 + 42100, new string[] { "성공했어.:0" });
        talkData.Add(0 + 42200, new string[] { "제단이 나온거 같아.:0" });
        talkData.Add(0 + 45000, new string[] { "하나는 조용히 눈을 감고있다..." });
        // Boss quest data  1000번대 활용

        talkData.Add(0 + 1000, new string[] { "??? [그런건 중요하지않아.]:3", "??? [49일전, 네가 나를 이렇게 만들었다는 것이 남았을 뿐이지.]:3",".........그건 내가 한 짓이 아니야.:1","??? [그럼 도망쳐 봐. 넌 영원히 나에게서도 현실에서도 도망치면서 살아야 할 테니까.]:3" ,"??? [하지만 <네가 얻은 것>을 <제단>에 올릴 수 있다면]:3","??? [넌 점점 현실을 마주할 수 있게 될 거야.]:3" });

        talkData.Add(1 + 3000, new string[] { "성공했어:0", "우울? [이제 우울에게서 도망치는 법을 깨달았구나]:3","우울? [하지만 언제까지 도망만 치며 다닐 순 없지.]:3","우울? [우울은 결국 너를 잠기게 만들 테니까.]:3" ,"비를 피해야 해...!:1"});

        talkData.Add(10 + 2000, new string[] { "우울? [이제 거의 다 진실에 닿아 가는군]:3", "우울? [내가 내는 문제를 맞추면 마지막 제단을 줄게.]:3" });
        talkData.Add(11 + 2000, new string[] { "우울? [나는 네가 만들어 주는 간식을 좋아했어. 둘중 무엇을 더 좋아했었지?]:3" });
        talkData.Add(20 + 2000, new string[] { "우울? [난 목욕을 정말 싫어했는데]:3", "우울? [네가 이걸 넣어주면 정신이 팔려 샴푸질을 당하는 줄도 몰랐지.]:3", "우울? [이것은 뭐일까?]:3"});
        talkData.Add(30 + 2000, new string[] { "우울? [나는 내 애착인형을 물고 가서 이불 속에 숨어있는 걸 좋아했어.]:3", "우울? [네가 준 수많은 인형들 중 유독 한 인형을 좋아했는데, 무슨 인형이지?]:3" });
        talkData.Add(40 + 2000, new string[] { "우울? [네가 이겼어!]:3", "우울? [이제 현실로 돌아갈 수 있는 마지막 제단을 줄게.]:3","이제 전부 알겠어.....넌 하나지?:4","내가 예전처럼 다시 밖으로 나왔으면 좋겠어서... 편지를 보낸거야?:4","하나 [맞아, 유리! 네 말처럼 모든 건 네 잘못이 아니야.....]:3","하나 [전부 사고였어. 나를 이제 무서운 불행이 아닌]:3","하나 [다시 따뜻한 추억으로 기억해 줄 거지?]:3","하나 [난 영원히 네 마음 속에서 행복하게 존재할거야.]:3" });
        talkData.Add(100 + 2000, new string[] { "우울? [아니, 다시 처음 문제부터 다시 생각해봐 내가 좋아하는 간식은?]:3" });
        // 초상화 data
        portraitData.Add(1000 + 0,portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 4, portraitArr[4]);

        portraitData.Add(3000 + 0, portraitArr[0]);
        portraitData.Add(3000 + 1, portraitArr[1]);
        portraitData.Add(3000 + 3, portraitArr[3]);
        portraitData.Add(3000 + 4, portraitArr[4]);

        // InnerRoom 초상화
        portraitData.Add(30000 + 0, portraitArr[0]);
        portraitData.Add(30000 + 1, portraitArr[1]);         // 진입 혼잣말


        portraitData.Add(30200 + 0, portraitArr[1]);        // 불켜짐
        portraitData.Add(30200 + 1, portraitArr[1]);

        //InnerRoom quest 초상화
        portraitData.Add(35100 + 0, portraitArr[0]);
        portraitData.Add(35200 + 0, portraitArr[0]);
        portraitData.Add(35300 + 0, portraitArr[0]);
        portraitData.Add(35400 + 0, portraitArr[0]);
        portraitData.Add(35500 + 0, portraitArr[0]);
        portraitData.Add(35600 + 0, portraitArr[0]);

        //Boss 초상화
        portraitData.Add(40000 + 0, portraitArr[1]);
        portraitData.Add(40000 + 1, portraitArr[1]);
        portraitData.Add(41000 + 0, portraitArr[0]);

        portraitData.Add(42100 + 0, portraitArr[0]);        // 패턴2
        portraitData.Add(42200 + 0, portraitArr[0]);        





    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id- id%10))
            {
                // 퀘스트 맨 처음 대사마저 없을 때,
                // 기본 대사 가지고 옴
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //해당 퀘스트 진행 순서 대사가 없을 때,
                // 퀘스트 맨 처음 대사를 가지고 옴.
                if (talkIndex == talkData[id - id % 10].Length)
                    return null;
                else
                    return talkData[id - id % 10][talkIndex];
            }
        }
        if (talkIndex == talkData[id].Length){
            return null;
        }


        else
            return talkData[id][talkIndex];
    }
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
