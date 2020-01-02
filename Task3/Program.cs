using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task3
{
    [Serializable]
    [DataContract]
    public class Product
    {
        public Product() { }
        public Product(string name, int calories, double price, int quantity)
        {
            Name = name;
            Calories = calories;
            Price = price;
            Quantity = quantity;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int Calories { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        public override string ToString()
        {
            return "Name:     " + Name + "\n" +
                   "Calories: " + Calories + "\n" +
                   "Price:    " + Price + "\n" +
                   "Quantity: " + Quantity + "\n";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product test1 = new Product("test1", 15, 9.99, 2);

            XmlSerializer formatter = new XmlSerializer(typeof(Product));

            using (FileStream fs = new FileStream("test1.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, test1);
            }

            Product newtest1 = new Product();

            using (FileStream fs = new FileStream("test1.xml", FileMode.OpenOrCreate))
            {
                newtest1 = (Product)formatter.Deserialize(fs);

                if (newtest1 != null)
                {
                    Console.WriteLine($"From File : \n");
                    Console.WriteLine(newtest1);
                }
            }

            Product test2 = new Product("test2", 11, 19.99, 12);

            var JSON = new DataContractJsonSerializer(typeof(Product));
            using (var file3 = new FileStream("test2.json", FileMode.OpenOrCreate))
            {
                JSON.WriteObject(file3, test2);
            }
            using (var file3 = new FileStream("test2.json", FileMode.OpenOrCreate))
            {
                var newProd3 = JSON.ReadObject(file3) as Product;

                if (newProd3 != null)
                {
                    Console.WriteLine($"From File : \n");
                    Console.WriteLine(newProd3);
                }
            }

            Product test3 = new Product("test3", 111, 119.99, 112);

            var BinSer = new BinaryFormatter();
            using (var file = new FileStream("test3.txt", FileMode.OpenOrCreate))
            {
                BinSer.Serialize(file, test3);
            }
            using (var file = new FileStream("test3.txt", FileMode.OpenOrCreate))
            {
                var newProd1 = BinSer.Deserialize(file) as Product;

                if (newProd1 != null)
                {
                    Console.WriteLine($"From File : \n");
                    Console.WriteLine(newProd1);
                }
            }
        }
    }
}
