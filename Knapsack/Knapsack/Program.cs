using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }
        public double ValuePerWeight => (double)Value / Weight;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo các đồ vật
            var items = new List<Item>
        {
            new Item { Value = 120, Weight = 10 },
            new Item { Value = 60, Weight = 12 },
            new Item { Value = 90, Weight = 15 },
            new Item { Value = 80, Weight = 20 }
        };

            // Sắp xếp các đồ vật theo giá trị trên đơn vị trọng lượng giảm dần
            items = items.OrderByDescending(item => item.ValuePerWeight).ToList();

            // Khối lượng tối đa của balo
            int capacity = 60;

            // Biến để theo dõi trọng lượng hiện tại của balo và tổng giá trị
            int currentWeight = 0;
            int totalValue = 0;

            // Mảng để đếm số lượng mỗi đồ vật đã chọn
            int[] itemCount = new int[items.Count];

            // Thuật toán tham lam
            foreach (var item in items)
            {
                // Chọn tối đa 2 cái của mỗi loại đồ vật
                while (itemCount[items.IndexOf(item)] < 2 && currentWeight + item.Weight <= capacity)
                {
                    currentWeight += item.Weight;
                    totalValue += item.Value;
                    itemCount[items.IndexOf(item)]++;
                }
            }

            Console.WriteLine($"Tong gia tri lon nhat co the dat duoc la: {totalValue}");
            Console.ReadKey();
        }
    }
}
