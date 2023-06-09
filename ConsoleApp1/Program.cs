using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static UserManager userManager;

        static void UpdateTop10users(User user)
        {
            Console.WriteLine("Đã cập nhật danh sách top 10 người chơi.");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            userManager = new UserManager();

            userManager.Top10UsersUpdated += UpdateTop10users;

            bool exitProgram = false;
            while (!exitProgram)
            {
                Console.WriteLine("----- MENU -----");
                Console.WriteLine("1. Tạo tài khoản user mới");
                Console.WriteLine("2. Thay đổi thông tin tài khoản");
                Console.WriteLine("3. Xóa tài khoản");
                Console.WriteLine("4. Hiển thị thông tin tài khoản");
                Console.WriteLine("5. Hiển thị danh sách các tài khoản được lọc");
                Console.WriteLine("6. Sắp xếp danh sách người chơi");
                Console.WriteLine("7. Thoát chương trình");
                Console.WriteLine("-----------------");
                Console.WriteLine("Nhập lựa chọn của bạn:");



                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        userManager.CrearUser();
                        break;

                    case 2:
                        userManager.UpdateInfoUser();
                        break;
                    case 3:
                        userManager.DeleteUser();
                        break;
                    case 4:
                        userManager.DisplayInfoUser();
                        break;
                    case 5:
                        Console.WriteLine("Nhập khu vực (0 - Africa, 1 - Europe, 2 - Asean):");
                        Area area = (Area)int.Parse(Console.ReadLine());

                        Console.WriteLine("Nhập hạng (0 - Đồng, 1 - Bạc, 2 - Vàng, 3 - Kim cương):");
                        Rank rank = (Rank)int.Parse(Console.ReadLine());

                        Console.WriteLine("Nhập cấp độ tối thiểu:");
                        int minLevel = int.Parse(Console.ReadLine());

                        Console.WriteLine("Nhập số vàng tối thiểu:");
                        int minGold = int.Parse(Console.ReadLine());

                        userManager.FilterUser(area, rank, minLevel, minGold);
                        break;
                    case 6:
                        userManager.SortUser();
                        break;
                    case 7:
                        exitProgram = true;
                        break;

                    default: Console.WriteLine("Lua chon khong hop le");
                        break;
                }
            }
        }
    }
}
