using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace TextRpg_Retey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameLogic = new GameLogic();

            gameLogic.StartAndRepeat();
        }
        class GameLogic
        {
            //Status 상속
            private Player _player;
            private Inventory _inventory = new Inventory();
            public Shop _shop = new Shop();

            private bool _isGameOver = false;
            private void GameOver()
            {
                //여기서 자꾸 걸리는데 좀 자연스럽게 넘어가는법 없나???
                //Console.Clear();
                Console.WriteLine("\nEnter - 계속  /  ESC - 종료 ");

                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) _isGameOver = true;
            }
            public void StartAndRepeat()
            {
                Init();
                Intro();
                ChoiceJob();

                while (!_isGameOver)
                {
                    MainMenu mainMenu = (MainMenu)ChoiceMainMenu();
                    switch (mainMenu)
                    {
                        case MainMenu.Status:
                            _player.printChoice();
                            break;
                        case MainMenu.Inventory:
                            _inventory.printChoice(_player, _inventory);
                            break;
                        case MainMenu.Shop:
                            _shop.printChoice(_player, _inventory, _shop);
                            break;
                    }
                    GameOver();
                }
                Console.WriteLine("게임이 종료되었습니다.");
            }
            //초기 셋팅
            public void Init()
            {
                weapon weapon1 = new weapon();
                //string이름 int공격 력 int가격 string설명 값을 넣으면 자신에게 넣어주는 함수
                weapon1.InInfo("낡은 검", 2, 600, "쉽게 볼 수 있는 낡은 검 입니다.");
                _shop.shop_item_weapon.Add(weapon1);

                weapon weapon2 = new weapon();
                weapon2.InInfo("청동 도끼", 5, 1500, "어디선가 사용됐던거 같은 도끼입니다.");
                _shop.shop_item_weapon.Add(weapon2);

                weapon weapon3 = new weapon();
                weapon3.InInfo("스파르타의 창", 7, 3000, "스파르타의 전사들이 사용했다는 전설의 창입니다.");
                _shop.shop_item_weapon.Add(weapon3);

                armor armor1 = new armor();
                armor1.InInfo("수련자 갑옷", 5, 1000, "수련에 도움을 주는 갑옷입니다.");
                _shop.shop_item_armor.Add(armor1);

                armor armor2 = new armor();
                armor2.InInfo("무쇠 갑옷", 9, 2000, "무쇠로 만들어져 튼튼한 갑옷입니다.");
                _shop.shop_item_armor.Add(armor2);

                armor armor3 = new armor();
                armor3.InInfo("스파르타의 갑옷", 15, 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
                _shop.shop_item_armor.Add(armor3);
            }
            //인트로에 player정의+이름 정하기 있음
            public void Intro()
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n"
                                  + "이름을 입력해주세요");
                string? playerName = Console.ReadLine();

                while (string.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("잘못된 이름입니다. 다시 입력하세요");
                    playerName = Console.ReadLine();
                }
                _player = new Player(playerName);
                Console.WriteLine($"{_player}님이 입장하셨습니다.");
            }
            public void ChoiceJob()
            {
                //일단 필수만 다 구현하고 물어보러 가장
                //enum의 갯수만큼 반복해서 직업을 적어주기      
                //int jobCount = System.Enum.GetValues(typeof(Job)).Length;
                //Console.WriteLine("직업을 선택해주세요\n");
                //for(int i = 0; i<jobCount;i++)
                //{
                //}
                Console.Clear();
                int numJob;
                Console.WriteLine("직업을 선택하세요 \n[1.Warrior] \n[2.Wizard] \n[3.Archer]");

                bool isNum = int.TryParse(Console.ReadLine(), out numJob);
                bool isCorrectRange;
                if (numJob > 3 || numJob < 1) isCorrectRange = false;
                else isCorrectRange = true;

                //오타 감지 반복
                while (!isNum || !isCorrectRange)
                {
                    Console.WriteLine("잘못입력하셨습니다. 다시입력하세요");
                    isNum = int.TryParse(Console.ReadLine(), out numJob);
                    if (numJob > 3 || numJob < 1) isCorrectRange = false;
                    else isCorrectRange = true;
                }
                //너무 빨리 사라짐...어케 딜레이 주냐
                //선택직업 출력
                _player.job = (Job)numJob;
                switch (_player.job)
                {
                    case Job.Warrior:
                        Console.WriteLine($"{_player.job}을(를) 선택하셨습니다.");
                        break;
                    case Job.Wizard:
                        Console.WriteLine($"{_player.job}을(를) 선택하셨습니다.");
                        break;
                    case Job.Archer:
                        Console.WriteLine($"{_player.job}을(를) 선택하셨습니다.");
                        break;
                }
            }
            //입력 받은 값을 int값으로 돌려줌
            public int ChoiceMainMenu()
            {
                Console.Clear();
                Console.WriteLine("다음 활동을 할 수 있습니다.\n\n" +
                                   "1. 상태 보기\n" +
                                   "2. 인벤토리\n" +
                                   "3. 상점\n\n" +
                                   "원하시는 행동을 입력해주세요");

                int numMainMenu;

                bool isNum = int.TryParse(Console.ReadLine(), out numMainMenu);
                bool isCorrectRange;
                if (numMainMenu > 3 || numMainMenu < 1) isCorrectRange = false;
                else isCorrectRange = true;

                //오타 감지 반복
                while (!isNum || !isCorrectRange)
                {
                    Console.WriteLine("잘못입력하셨습니다. 다시입력하세요");
                    isNum = int.TryParse(Console.ReadLine(), out numMainMenu);

                    if (numMainMenu > 3 || numMainMenu < 1) isCorrectRange = false;
                    else isCorrectRange = true;
                }
                return numMainMenu;
            }
        }

        //Status 상속
        class Player : Status
        {
            public string name;

            public Player(string name)
            {
                this.name = name;
            }
        }

        class Status
        {
            public Job job = Job.Warrior;
            public int hp = 100;
            public int level = 1;
            public int attack = 10;
            public int defense = 5;
            public int gold = 1500;

            public void printChoice()
            {
                Console.Clear();
                Console.WriteLine("\n상태 보기\n캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine($"Lv{level:00}\n" + $"Chad ({job})");
                Console.WriteLine($"공격력 : {attack}\n" + $"방어력 : {defense}");
                Console.WriteLine($"체 력 : {hp}\n" + $"Gold : {gold} G\n");
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.WriteLine("0.나가기");

                int input;
                bool isNum = int.TryParse(Console.ReadLine(), out input);

                while (!isNum || !(input == 0))
                {
                    Console.WriteLine("잘못입력하셨습니다. 다시 입력하세요");
                    isNum = int.TryParse(Console.ReadLine(), out input);
                }
            }
        }
        class Inventory
        {
            public List<weapon> inventory_item_weapon = new List<weapon>();
            public List<armor> inventory_item_armor = new List<armor>();

            public void printChoice(Player player, Inventory inventory)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                    Console.WriteLine("[아이템 목록]\n");

                    for (int i = 0; i < inventory.inventory_item_weapon.Count; i++)
                    {
                        Console.WriteLine($"{inventory.inventory_item_weapon[i].OutInfo()}");
                    }

                    for (int i = 0; i < inventory.inventory_item_armor.Count; i++)
                    {
                        Console.WriteLine($"{inventory.inventory_item_armor[i].OutInfo()}");
                    }

                    Console.WriteLine("\n1. 장착 관리");
                    Console.WriteLine("0. 나가기\n");

                    Console.WriteLine("원하시는 행동을 입력해주세요");

                    int input;
                    bool isNum = int.TryParse(Console.ReadLine(), out input);

                    while (!isNum || !(input == 0 || input == 1))
                    {
                        Console.WriteLine("잘못입력하셨습니다. 다시 입력하세요");
                        //isNum = int.TryParse(Console.ReadLine(), out input);
                        continue;
                    }
                    //1이라면 장착 해제 관리
                    if (input == 1)
                    {
                        equippedAndClear(player, inventory);
                    }
                    //0이면 탈출
                    else if (input == 0)
                    {
                        break;
                    }
                }
            }
            public void equippedAndClear(Player player, Inventory inventory)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("[ 장착 해제 ]\n");

                    Console.WriteLine("[ 아이템 목록 ]");

                    for (int i = 0; i < inventory.inventory_item_weapon.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {inventory.inventory_item_weapon[i].OutInfo()}");
                    }

                    for (int i = 0; i < inventory.inventory_item_armor.Count; i++)
                    {
                        Console.WriteLine($"{i + 1 + inventory.inventory_item_weapon.Count}. {inventory.inventory_item_weapon[i].OutInfo()}");
                    }

                    Console.WriteLine("\n0. 나가기\n");

                    Console.Write("장착할 아이템을 선택하세요\n");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int purchaseNum) || purchaseNum < 0 || purchaseNum > inventory.inventory_item_weapon.Count + inventory.inventory_item_armor.Count)
                    {
                        Console.WriteLine("\n유효한 숫자를 입력해주세요.\n");
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (purchaseNum == 0)
                    {
                        break;
                    }

                    //무기 장착 처리
                    if (purchaseNum-1 <= inventory.inventory_item_weapon.Count)
                    {
                        inventory.inventory_item_weapon[purchaseNum-1].isEquipped = !inventory.inventory_item_weapon[purchaseNum - 1].isEquipped;
                        //창착되지 않았다면 창착하고 공격력 올리고
                        if (inventory.inventory_item_weapon[purchaseNum - 1].isEquipped == true)
                        {
                            player.attack += inventory.inventory_item_weapon[purchaseNum - 1].attack;
                            Console.WriteLine("장착 했습니다");
                        }
                        //아니라면 해제하고 공격력 내리고
                        else
                        {
                            player.attack -= inventory.inventory_item_weapon[purchaseNum - 1].attack;
                            Console.WriteLine("해제 했습니다");
                        }
                    }
                    //방어구 장착 처리
                    else
                    {
                        inventory.inventory_item_armor[purchaseNum - 1-inventory_item_weapon.Count].isEquipped = !inventory.inventory_item_weapon[purchaseNum - 1- inventory_item_weapon.Count].isEquipped;
                        //창착되지 않았다면 창착하고 방어력 올리고
                        if (inventory.inventory_item_armor[purchaseNum - 1].isEquipped == true)
                        {
                            player.defense += inventory.inventory_item_armor[purchaseNum - 1].defense;
                            Console.WriteLine("장착 했습니다");
                        }
                        //아니라면 해제하고 방어력 내리고
                        else
                        {
                            player.defense -= inventory.inventory_item_armor[purchaseNum - 1].defense;
                            Console.WriteLine("해제 했습니다");
                        }
                    }
                    Console.WriteLine("\nEnter 키를 누르면 계속 진행됩니다.");
                    Console.ReadLine(); // 엔터 입력만 받음
                }
            }
        }
        class Shop
        {
            public List<weapon> shop_item_weapon = new List<weapon>();
            public List<armor> shop_item_armor = new List<armor>();

            public void printChoice(Player player, Inventory inventory, Shop shop)
            {
                bool isBack = false;
                while (!isBack)
                {
                    Console.Clear();
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine($"{player.gold}\n");

                    //상점 장비 출력
                    for (int i = 0; i < shop_item_weapon.Count; i++)
                    {
                        Console.WriteLine(shop_item_weapon[i].OutInfo());
                    }
                    for (int i = 0; i < shop_item_armor.Count; i++)
                    {
                        Console.WriteLine(shop_item_armor[i].OutInfo());
                    }

                    Console.WriteLine("\n1. 아이템 구매\n0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요");

                    int input;
                    bool isNum = int.TryParse(Console.ReadLine(), out input);

                    while (!isNum || !(input == 0 || input == 1))
                    {
                        Console.WriteLine("잘못입력하셨습니다. 다시 입력하세요");
                        isNum = int.TryParse(Console.ReadLine(), out input);
                    }
                    //1이라면 아이템 구매
                    if (input == 1)
                    {
                        PurChase(player, inventory, shop);
                    }
                    else if (input == 0)
                    {
                        isBack = true;
                    }
                }
            }
            // 플레이어 class,인벤토리 class,샵 class 입력받아서 산거 반영해주기
            public void PurChase(Player player, Inventory inventory, Shop shop)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("[ 아이템 구매 ]\n");

                    Console.WriteLine("[ 보유 골드 ]");
                    Console.WriteLine($"{player.gold} G\n");

                    Console.WriteLine("[ 아이템 목록 ]");

                    for (int i = 0; i < shop.shop_item_weapon.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {shop.shop_item_weapon[i].OutInfo()}");
                    }

                    for (int i = 0; i < shop.shop_item_armor.Count; i++)
                    {
                        Console.WriteLine($"{i + 1 + shop.shop_item_weapon.Count}. {shop.shop_item_armor[i].OutInfo()}");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("");

                    Console.Write("구매할 아이템 번호를 입력하세요\n");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int purchaseNum) || purchaseNum < 0 || purchaseNum > shop.shop_item_weapon.Count + shop.shop_item_armor.Count)
                    {
                        Console.WriteLine("유효한 숫자를 입력해주세요.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (purchaseNum == 0)
                    {
                        break;
                    }

                    //무기 구매 처리
                    if (purchaseNum <= shop.shop_item_weapon.Count)
                    {
                        weapon selectedWeapon = shop.shop_item_weapon[purchaseNum - 1];

                        if (selectedWeapon.price == 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (player.gold < selectedWeapon.price)
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        else
                        {
                            player.gold -= selectedWeapon.price;
                            inventory.inventory_item_weapon.Add(new weapon(selectedWeapon));
                            shop.shop_item_weapon[purchaseNum - 1].price = 0;
                            Console.WriteLine("아이템을 구매했습니다!");
                        }
                    }
                    //방어구 구매 처리
                    else
                    {
                        int armorIndex = purchaseNum - shop.shop_item_weapon.Count - 1;
                        armor selectedArmor = shop.shop_item_armor[armorIndex];

                        if (selectedArmor.price == 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (player.gold < selectedArmor.price)
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        else
                        {
                            player.gold -= selectedArmor.price;
                            inventory.inventory_item_armor.Add(new armor(selectedArmor));
                            shop.shop_item_armor[armorIndex].price = 0;
                            Console.WriteLine("아이템을 구매했습니다!");
                        }
                    }
                    Console.WriteLine("Enter 키를 누르면 계속 진행됩니다.");
                    Console.ReadLine(); // 엔터 입력만 받음
                }
            }
        }
        class TextArt
        {
            public void wellcome()
            {
                Console.WriteLine("다음으로 넘어가려면 아무키나 눌러주세요");
                Console.ReadLine();
            }
        }
        class equipment
        {
            public string name;
            public int price;
            public string explanation;
            public bool isEquipped = false;

            public equipment()
            {

            }
            public equipment(equipment ohder)
            {
                this.name = ohder.name;
                this.price = ohder.price;
                this.explanation = ohder.explanation;
            }

        }

        //equipment 상속
        class weapon : equipment
        {
            public int attack;

            public weapon() : base() { }
            //무기 복사
            public weapon(weapon ohder) : base(ohder)
            {
                this.attack = ohder.attack;
            }

            //자기 자신의 이름 공격력 가격 설명을 합쳐서 string 값으로 리턴 해주는 함수
            public string OutInfo()
            {
                string waponInfo;

                //가격이 0이라면 판매완료
                if (price == 0)
                {
                    waponInfo = name + " | " + "공격력" + attack + " | " + "판매완료" + " | " + explanation;
                }
                else if(isEquipped == true)
                {
                    waponInfo = "[E]"+name + " | " + "공격력" + attack + " | " + "판매완료" + " | " + explanation;
                }
                else
                {
                    waponInfo = name + " | " + "공격력" + attack + " | " + price + " | " + explanation;
                }

                return waponInfo;
            }
            //string이름 int공격력 int가격 string설명 값을 넣으면 자신에게 넣어주는 함수
            public void InInfo(string _name, int _attack, int _price, string _explanation)
            {
                name = _name;
                attack = _attack;
                price = _price;
                explanation = _explanation;
            }
        }

        //equipment 상속
        class armor : equipment
        {
            public int defense;

            public armor() : base() { }

            //방어구 복사
            public armor(armor ohder) : base(ohder)
            {
                this.defense = ohder.defense;
            }
            //자기 자신의 이름 방어력 가격 설명을 합쳐서 string 값으로 리턴 해주는 함수
            public string OutInfo()
            {
                string armorInfo;

                //가격이 0이라면 판매완료
                if (price == 0)
                {
                    armorInfo = name + " | " + "방어력" + defense + " | " + "판매완료" + " | " + explanation;
                }
                else if(isEquipped == true)
                {
                    armorInfo = "[E]"+name + " | " + "방어력" + defense + " | " + "판매완료" + " | " + explanation;
                }
                else
                {
                    armorInfo = name + " | " + "방어력" + defense + " | " + price + " | " + explanation;
                }

                return armorInfo;
            }
            //string이름 int방어력 int가격 string설명 값을 넣으면 자신에게 넣어주는 함수
            public void InInfo(string _name, int _defense, int _price, string _explanation)
            {
                name = _name;
                defense = _defense;
                price = _price;
                explanation = _explanation;
            }
        }

        public enum Job
        {
            Warrior = 1,
            Wizard,
            Archer
        }
        public enum MainMenu
        {
            Status = 1,
            Inventory,
            Shop
        }
    }
}