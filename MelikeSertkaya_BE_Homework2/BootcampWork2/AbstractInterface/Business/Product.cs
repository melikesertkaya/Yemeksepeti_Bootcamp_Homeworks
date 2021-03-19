using AbstractInterface.Abstract;
using AbstractInterface.CustomAttribute;
using AbstractInterface.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractInterface.Business
{

    [RoleAccess(UserRole.Admin)]
    [RoleAccess(UserRole.Customer)]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        private User User;

        public Product(int id, string name, int price, User user)
        {
            var typeInfo = typeof(Product);
            RoleAccessAttribute[] roleAttributes =
                typeInfo.GetCustomAttributes(typeof(RoleAccessAttribute), true)
                as RoleAccessAttribute[];

            if (roleAttributes != null)
            {
                if (roleAttributes.All(ra => ra.UserRole.ToString() !=
                   user.GetType().Name))
                {
                    throw new ArgumentException("Kullanıcı yeterli yetkiye sahip değil");
                }
            }

            this.Id = id;
            this.Name = name;
            this.User = user;

        }
    }
}