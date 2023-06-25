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
        // ��ȭ data
        // NPC : 1000 ����
        // �繰 : 100 ����

        talkData.Add(100000, new string[] { "1000�� ���:1", "2��° ���:2" });
        talkData.Add(2000, new string[] { "2000�� ���:0", "2��° ���:1" });
        talkData.Add(3000, new string[] { "���? [����ѹ� �غ�...]:3", });

        talkData.Add(100, new string[] { "carpet" });
        talkData.Add(200, new string[] { "�������� �����Ѱ� ����. ������ Ǯ�� �������� ��ƿ���" });       
        talkData.Add(300, new string[] { "�����̴� ��Ʈ�� ���ĭ�� ���� �� �����̽��ٸ� ���� ��Ḧ ��ƺ���!" });
        talkData.Add(400, new string[] { "����� �µ� ���� ��ư�� ���� �µ��� ���纸��!" });
        talkData.Add(500, new string[] { "num4" });
        talkData.Add(600, new string[] { "���踦 ȹ���ߴ�!"});
        // InnerRoom ���� 30000����

      
        talkData.Add(30000, new string[] { "���� �ʹ� ��ο��.....:1", "���� �Ӹ��� �� ������..?:0" });
        talkData.Add(100+30000, new string[] { "���� �������." });
        talkData.Add(200 + 30000, new string[] { "ħ�뿡 ���𰡰�...?:1","Ȯ���غ���?:0" });

        talkData.Add(35100, new string[] { "������� Ȯ���غ��ߵɰŰ���.:0" });
        talkData.Add(35200, new string[] { "������� Ȯ���غ��ߵɰŰ���.:0" });
        talkData.Add(35300, new string[] { "������� Ȯ���غ��ߵɰŰ���.:0" });
        talkData.Add(35400, new string[] { "������� Ȯ���غ��ߵɰŰ���.:0" });
        talkData.Add(35500, new string[] { "������� Ȯ���غ��ߵɰŰ���.:0" });
        talkData.Add(35600, new string[] { "������� Ȯ���غ��ߵɰŰ���.:0" });
        talkData.Add(35700, new string[] { "�䳢 ������ �߰��ߴ�." });
        // InnerRoom quest


        talkData.Add(60 + 35400, new string[] { "�������� �Ѿ��.:0" });
        talkData.Add(61 + 35500, new string[] { "�������� �Ѿ��.:0" });

        talkData.Add(70 + 35200, new string[] { "�������� �Ѿ��.:0" });
        talkData.Add(71 + 35300, new string[] { "�������� �Ѿ��.:0" });

        talkData.Add(80 + 35600, new string[] { "�������� �Ѿ��.:0" });
        talkData.Add(81 + 35100, new string[] { "���𰡰� �ִ°� ����.:0" });
        talkData.Add(90 + 35100, new string[] { "������ �����ִ� ��Ҿ�.:0" });

        // Boss 40000����
        talkData.Add(0 + 40000, new string[] { "�̰� ����?? �� ���翡 �̷� ��...?:1" });
        talkData.Add(0 + 41000, new string[] { "������ ���Ծ�...:0" });
        talkData.Add(0 + 40100, new string[] { "������ �÷��ξ���." });
        talkData.Add(0 + 40200, new string[] { "���� ������ �÷��ξ���." });
        talkData.Add(0 + 40300, new string[] { "�䳢 ������ �÷��ξ���." });

        talkData.Add(0 + 42100, new string[] { "�����߾�.:0" });
        talkData.Add(0 + 42200, new string[] { "������ ���°� ����.:0" });
        talkData.Add(0 + 45000, new string[] { "�ϳ��� ������ ���� �����ִ�..." });
        // Boss quest data  1000���� Ȱ��

        talkData.Add(0 + 1000, new string[] { "??? [�׷��� �߿������ʾ�.]:3", "??? [49����, �װ� ���� �̷��� ������ٴ� ���� ������ ������.]:3",".........�װ� ���� �� ���� �ƴϾ�.:1","??? [�׷� ������ ��. �� ������ �����Լ��� ���ǿ����� ����ġ�鼭 ��ƾ� �� �״ϱ�.]:3" ,"??? [������ <�װ� ���� ��>�� <����>�� �ø� �� �ִٸ�]:3","??? [�� ���� ������ ������ �� �ְ� �� �ž�.]:3" });

        talkData.Add(1 + 3000, new string[] { "�����߾�:0", "���? [���� ��￡�Լ� ����ġ�� ���� ���޾ұ���]:3","���? [������ �������� ������ ġ�� �ٴ� �� ����.]:3","���? [����� �ᱹ �ʸ� ���� ���� �״ϱ�.]:3" ,"�� ���ؾ� ��...!:1"});

        talkData.Add(10 + 2000, new string[] { "���? [���� ���� �� ���ǿ� ��� ���±�]:3", "���? [���� ���� ������ ���߸� ������ ������ �ٰ�.]:3" });
        talkData.Add(11 + 2000, new string[] { "���? [���� �װ� ����� �ִ� ������ �����߾�. ���� ������ �� �����߾���?]:3" });
        talkData.Add(20 + 2000, new string[] { "���? [�� ����� ���� �Ⱦ��ߴµ�]:3", "���? [�װ� �̰� �־��ָ� ������ �ȷ� ��Ǫ���� ���ϴ� �ٵ� ������.]:3", "���? [�̰��� ���ϱ�?]:3"});
        talkData.Add(30 + 2000, new string[] { "���? [���� �� ���������� ���� ���� �̺� �ӿ� �����ִ� �� �����߾�.]:3", "���? [�װ� �� ������ ������ �� ���� �� ������ �����ߴµ�, ���� ��������?]:3" });
        talkData.Add(40 + 2000, new string[] { "���? [�װ� �̰��!]:3", "���? [���� ���Ƿ� ���ư� �� �ִ� ������ ������ �ٰ�.]:3","���� ���� �˰ھ�.....�� �ϳ���?:4","���� ����ó�� �ٽ� ������ �������� ���ھ... ������ �����ž�?:4","�ϳ� [�¾�, ����! �� ��ó�� ��� �� �� �߸��� �ƴϾ�.....]:3","�ϳ� [���� �����. ���� ���� ������ ������ �ƴ�]:3","�ϳ� [�ٽ� ������ �߾����� ����� �� ����?]:3","�ϳ� [�� ������ �� ���� �ӿ��� �ູ�ϰ� �����Ұž�.]:3" });
        talkData.Add(100 + 2000, new string[] { "���? [�ƴ�, �ٽ� ó�� �������� �ٽ� �����غ� ���� �����ϴ� ������?]:3" });
        // �ʻ�ȭ data
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

        // InnerRoom �ʻ�ȭ
        portraitData.Add(30000 + 0, portraitArr[0]);
        portraitData.Add(30000 + 1, portraitArr[1]);         // ���� ȥ�㸻


        portraitData.Add(30200 + 0, portraitArr[1]);        // ������
        portraitData.Add(30200 + 1, portraitArr[1]);

        //InnerRoom quest �ʻ�ȭ
        portraitData.Add(35100 + 0, portraitArr[0]);
        portraitData.Add(35200 + 0, portraitArr[0]);
        portraitData.Add(35300 + 0, portraitArr[0]);
        portraitData.Add(35400 + 0, portraitArr[0]);
        portraitData.Add(35500 + 0, portraitArr[0]);
        portraitData.Add(35600 + 0, portraitArr[0]);

        //Boss �ʻ�ȭ
        portraitData.Add(40000 + 0, portraitArr[1]);
        portraitData.Add(40000 + 1, portraitArr[1]);
        portraitData.Add(41000 + 0, portraitArr[0]);

        portraitData.Add(42100 + 0, portraitArr[0]);        // ����2
        portraitData.Add(42200 + 0, portraitArr[0]);        





    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id- id%10))
            {
                // ����Ʈ �� ó�� ��縶�� ���� ��,
                // �⺻ ��� ������ ��
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //�ش� ����Ʈ ���� ���� ��簡 ���� ��,
                // ����Ʈ �� ó�� ��縦 ������ ��.
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
