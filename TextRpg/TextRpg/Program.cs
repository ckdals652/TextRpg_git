namespace TextRpg
{
    internal class Program
    {
        static void Start()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n" +
                                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n" +
                                "1. 상태 보기\n" +
                                "2. 인벤토리\n" +
                                "3. 상점\n\n" +
                                "원하시는 행동을 입력해주세요");
        }

        //a~b까지 범위에 string(c)으로 입력 받은 값이
        //있는지 없는지 bool값(thereIs)으로 반환
        //입력된 값도 받아와야겠지(d)
        static bool Choice(int a, int b, string c, out int d)
        {
            int isNum = 0;
            bool thereIs = false;

            thereIs = int.TryParse(c, out isNum);
            d = isNum;

            //숫자라면
            if (thereIs)
            {
                //스트링에서 뽑아 넣은 값이 범위 안이면 true
                thereIs = (isNum >= a) && (isNum <= b);
                //숫자 범위를 벗어났을 때
                if (!thereIs) Console.WriteLine("잘못된 범위의 숫자를 입력하셨습니다");
            }
            //문자라면
            else Console.WriteLine("숫자를 입력해주세요");

            return thereIs;
        }

        ////한 글자 짜리 숫자 string을 int로 바꿔 반환
        //static void Input(string a)
        //{
        //    int num = int.Parse(a);
        //}

        class status
        {
            public string name;
            public string jab = "전사";
            public int hp = 100;
            public int level = 1;
            public int attack = 10;
            public int defense = 5;
            public int gold = 1500;

            public void Print()
            {
                Console.WriteLine("\n상태 보기\n캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine($"Lv{level:00}\n" + $"Chad ({jab})");
                Console.WriteLine($"공격력 : {attack}\n" + $"방어력 : {defense}");
                Console.WriteLine($"체 력 : {hp}\n" + $"Gold : {gold} G\n");
                Console.WriteLine("원하시는 행동을 입력해주세요");
            }
        }

        //인벤토리 내역 출력
        static void Inven_Print(List<string> a)
        {
            Console.WriteLine("\n\n인벤토리\n" +
                "보유중인 아이템을 관리할 수 있습니다\n");

            Console.WriteLine("[아이템 목록]\n");
            for (int i = 0; i < a.Count; i++) Console.WriteLine("- "+a[i]);

            Console.WriteLine("1. 장착 관리\n2. 나가기\n");
        }

        //메인 메뉴
        static void MainMenu()
        {

        }

        static void Main(string[] args)
        {
            int player_cho = 0;
            bool coutinue = false;
            status player_sta = new status();
            List<string> inventory = new List<string>();

            Start();

            //옳은 선택지를 입력 할 때 까지 반복
            //(1~3 사이 값을 입력할 때까지)
            while (!coutinue)
            {
                coutinue = Choice(1, 3, Console.ReadLine(), out player_cho);
            }

            if (player_cho == 1) player_sta.Print();
            else if (player_cho == 2) Inven_Print(inventory) ;
            else if (player_cho == 3) ;

        }
    }
}
