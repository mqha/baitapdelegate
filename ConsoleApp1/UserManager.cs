using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class UserManager
    {
        private List<User> userList;

        public UserManager()
        {
            userList = new List<User>();
        }

        public delegate void UserAction(User user);  //delegate cho các hành động với user

        public event UserAction Top10UsersUpdated;   //event cập nhật danh sách top 10 user

        public void CrearUser() // Tạo user mới
        {
            User user = new User();

            Console.WriteLine("Nhap ID nguoi choi: ");
            user.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap NickName: ");
            user.NickName = Console.ReadLine();

            Console.WriteLine("Nhap khu vuc (0 - Africa, 1 - Europe, 2 - Asean): ");
            user.Area = (Area)int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập cấp độ: ");
            user.Level = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập số vàng của người chơi:");
            user.Gold = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập hạng của người chơi (0 - Đồng, 1 - Bạc, 2 - Vàng, 3 - Kim cương):");
            user.Rank = (Rank)int.Parse(Console.ReadLine());

            userList.Add(user);

            Top10UsersUpdated?.Invoke(user);  // Gọi event Top10UsersUpdated để cập nhật danh sách top 10
        }

        public void UpdateInfoUser()
        {
            Console.WriteLine("Nhap ID cua nguoi choi can thay doi: ");
            int userId = int.Parse(Console.ReadLine());

            User userUpdate = userList.Find(user => user.Id == userId);

            if(userUpdate != null)
            {
                Console.WriteLine("Nhập Nick Name mới:");
                userUpdate.NickName = Console.ReadLine();

                Console.WriteLine("Nhập khu vực mới (0 - Africa, 1 - Europe, 2 - Asean):");
                userUpdate.Area = (Area)int.Parse(Console.ReadLine());

                Console.WriteLine("Nhập cấp độ mới:");
                userUpdate.Level = int.Parse(Console.ReadLine());

                Console.WriteLine("Nhập số vàng mới:");
                userUpdate.Gold = int.Parse(Console.ReadLine());

                Console.WriteLine("Nhập hạng mới (0 - Đồng, 1 - Bạc, 2 - Vàng, 3 - Kim cương):");
                userUpdate.Rank = (Rank)int.Parse(Console.ReadLine());

                Top10UsersUpdated?.Invoke(userUpdate);
            }
            else 
            {
                Console.WriteLine("Không tìm thấy người chơi với ID đã nhập.");
            }
        }

        public void DeleteUser()
        {
            Console.WriteLine("Nhap ID nguoi choi can xoa: ");
            int userId = int.Parse(Console.ReadLine());

            User userDelete = userList.Find(User => User.Id == userId);

            if (userDelete != null)
            {
                userList.Remove(userDelete);
                Console.WriteLine("Da xoa thanh cong nguoi choi co ID: " + userId);

                Top10UsersUpdated?.Invoke(userDelete);
            }
            else
            {
                Console.WriteLine("Không tìm thấy người chơi với ID đã nhập.");
            }
        }

        public void DisplayInfoUser()
        {
            Console.WriteLine("Nhap ID nguoi choi can hien thi thong tin: ");
            int userId = int.Parse(Console.ReadLine());

            User userDisplay = userList.Find( user => user.Id == userId);

            if (userDisplay != null)
            {
                Console.WriteLine("Thông tin người chơi:");
                Console.WriteLine("ID: " + userDisplay.Id);
                Console.WriteLine("Nick Name: " + userDisplay.NickName);
                Console.WriteLine("Khu vực: " + userDisplay.Area);
                Console.WriteLine("Cấp độ: " + userDisplay.Level);
                Console.WriteLine("Số vàng: " + userDisplay.Gold);
                Console.WriteLine("Hạng: " + userDisplay.Rank);
            }
            else
            {
                Console.WriteLine("Không tìm thấy người chơi với ID đã nhập.");
            }

        }

        public void FilterUser(Area area, Rank rank, int minLevel, int minGold)
        {
            List<User> filterUser = userList.FindAll(user => user.Area == area && user.Rank == rank && user.Level >= minLevel && user.Gold >= minGold);
            
            if(filterUser.Count > 0)
            {
                Console.WriteLine("Danh sach thoa man dieu kien: ");
                foreach (User user in filterUser)
                {
                    Console.WriteLine("ID: " + user.Id);
                    Console.WriteLine("Nick Name: " + user.NickName);
                    Console.WriteLine("Khu vực: " + user.Area);
                    Console.WriteLine("Cấp độ: " + user.Level);
                    Console.WriteLine("Số vàng: " + user.Gold);
                    Console.WriteLine("Hạng: " + user.Rank);
                    Console.WriteLine("--------------------");
                }
            }

            else
            {
                Console.WriteLine("Khong co user thoa man dieu kien.");
            }
        
        }

        public void SortUser()
        {
            userList.Sort((user1, user2) =>
            {
                int areaComparison = user1.Area.CompareTo(user2.Area);
                if (areaComparison != 0)
                    return areaComparison;

                int rankComparison = user1.Rank.CompareTo(user2.Rank);
                if (rankComparison != 0)
                    return rankComparison;

                int goldComparison = user2.Gold.CompareTo(user1.Gold);
                if (goldComparison != 0)
                    return goldComparison;

                return user2.Level.CompareTo(user1.Level);
            });

            Console.WriteLine("Đã sắp xếp danh sách người chơi.");
        }


    }
}
