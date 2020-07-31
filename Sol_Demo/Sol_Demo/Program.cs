using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Demo readCollectionDemo = new Demo();

            #region IReadOnlyCollection Demo

            var listUserCollection = await readCollectionDemo.Demo1();
            foreach (var user in listUserCollection)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }

            List<UserModel> listUserModel1 = listUserCollection.ToList();

            #endregion IReadOnlyCollection Demo

            #region IReadOnlyList Demo

            var userReadOnlyList = await readCollectionDemo.Demo2();
            foreach (var user in userReadOnlyList)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }

            List<UserModel> listUserModel2 = userReadOnlyList.ToList();

            #endregion IReadOnlyList Demo

            #region IReadOnlyDictionary Demo

            var iReadOnlyDicObj = await readCollectionDemo.Demo3();

            foreach (var item in iReadOnlyDicObj)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

            Dictionary<int, String> dicObj = iReadOnlyDicObj as Dictionary<int, String>;

            #endregion IReadOnlyDictionary Demo
        }
    }

    public class UserModel
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }
    }

    public class Demo
    {
        private Task<List<UserModel>> GetUserList()
        {
            return Task.Run(() =>
            {
                var userList = new List<UserModel>();
                userList.Add(new UserModel()
                {
                    FirstName = "Kishor",
                    LastName = "Naik"
                });
                userList.Add(new UserModel()
                {
                    FirstName = "Eshaan",
                    LastName = "Naik"
                });

                return userList;
            });
        }

        public async Task<IReadOnlyCollection<UserModel>> Demo1()
        {
            return await this.GetUserList();
        }

        public async Task<IReadOnlyList<UserModel>> Demo2()
        {
            return await this.GetUserList();
        }

        public Task<IReadOnlyDictionary<int, String>> Demo3()
        {
            return Task.Run<IReadOnlyDictionary<int, String>>(() =>
             {
                 Dictionary<int, String> dicObj = new Dictionary<int, string>();
                 dicObj.Add(1, "Kishor");
                 dicObj.Add(2, "Naik");

                 return dicObj;
             });
        }
    }
}