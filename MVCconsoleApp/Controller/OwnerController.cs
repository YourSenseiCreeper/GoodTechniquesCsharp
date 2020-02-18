using MVCconsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCconsoleApp.View
{
    public class OwnerController
    {
        public void AddOwner()
        {
            var owner = new Owner
            {
                Name = ViewHelper.AskForString("Podaj imię: "),
                Age = ViewHelper.AskForInt("Podaj ile masz lat: "),
                Money = ViewHelper.AskForDouble("Podaj ilość pieniędzy: ")
            };
            DataAccess.Owners.Add(owner);
        }
    }
}
