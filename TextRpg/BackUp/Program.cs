public void PurChase(Player player, Inventory inventory, Shop shop)
{
    //int purChaseNum;
    //bool isNum;
    //bool isPriceLow = false;
    //bool isZoro = false;

    //Console.WriteLine("구매할 물건의 번호를 적어주세요\n0.뒤로가기");
    //string input = Console.ReadLine();
    //isNum = int.TryParse(input, out purChaseNum);
    ////뒤로가기
    //if (purChaseNum == 0) isZoro = true;

    //while (!isZoro)
    //{
    //    //플레이어 돈보다 가격이 높을 때 반복
    //    while (!isPriceLow)
    //    {
    //        //숫자가 아니거나 무기와 방어구 수의 범위 밖이면 반복
    //        while (!isNum || !(purChaseNum < 1 || purChaseNum > (shop_item_weapon.Count + shop_item_armor.Count)))
    //        {
    //            Console.WriteLine("잘못입력하셨습니다 \n목록에 수 중에 선택해주세요");
    //            input = Console.ReadLine();
    //            isNum = int.TryParse(input, out purChaseNum);
    //        }

    //        //무기라면
    //        if (purChaseNum < shop_item_weapon.Count)
    //        {
    //            weapon selectedWeapon = shop.shop_item_weapon[purChaseNum - 1];

    //            //이미 산 물건일 때 반복 
    //            if (shop.shop_item_weapon[purChaseNum - 1].price == 0)
    //            {
    //                Console.WriteLine("이미 구매한 아이템입니다.");
    //                continue;
    //            }
    //            //플레이어 돈보다 가격이 높을 때 반복
    //            else if (selectedWeapon.price > player.gold)
    //            {
    //                isPriceLow = false;
    //                Console.WriteLine("돈이 모자릅니다.");
    //                continue;
    //            }
    //            isPriceLow = true;

    //            player.gold -= selectedWeapon.price;
    //            //값이 0일때 판매완료가 출력되게 만듬
    //            shop.shop_item_weapon[purChaseNum - 1].price = 0;

    //            //아니라면 인벤에 추가
    //            inventory.inventory_item_weapon.Add(selectedWeapon);
    //            Console.WriteLine("인벤토리에 " + inventory.inventory_item_weapon[purChaseNum - 1].name + " 추가되었습니다.");

    //        }

    //        //방어구라면
    //        else
    //        {
    //            purChaseNum -= shop_item_weapon.Count;
    //            armor selectedArmor = shop.shop_item_armor[purChaseNum - 1];

    //            //이미 산 물건일 때 반복 
    //            if(shop.shop_item_armor[purChaseNum - 1].price == 0)
    //            {
    //                continue;
    //            }
    //            //플레이어 돈보다 가격이 높을 때 반복
    //            else if (selectedArmor.price > player.gold)
    //            {
    //                isPriceLow = false;
    //                Console.WriteLine("돈이 모자릅니다.");
    //                continue;
    //            }
    //            isPriceLow = true;

    //            player.gold -= selectedArmor.price;
    //            //값이 0일때 판매완료가 출력되게 만듬
    //            shop.shop_item_armor[purChaseNum - 1].price = 0;

    //            //아니라면 인벤에 추가
    //            inventory.inventory_item_armor.Add(selectedArmor);
    //            Console.WriteLine("인벤토리에 " + inventory.inventory_item_armor[purChaseNum - 1].name + " 추가되었습니다.");
    //        }
    //    }
    //}
}