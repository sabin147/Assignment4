using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1;

namespace Assignment4.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        FootballPlayersManager manager = new FootballPlayersManager();

        [TestMethod()]
        public void GetAllTest()
        {
            List<FootballPlayer> testList = manager.GetAll();

            Assert.AreEqual(4, testList.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            var newPlayer = new FootballPlayer() { Id = 9, Age = 30, Name = "Sharukh", ShirtNumber = 25 };

            var createdResponse = manager.Add(newPlayer);

            Assert.AreEqual(9, createdResponse.Id);
            Assert.AreEqual(5, manager.GetAll().Count);
        }

        [TestMethod()]
        public void GetById()
        {
            var createdResponse = manager.GetById(2);
            var nullResponse = manager.GetById(26);

            Assert.AreEqual("Adeel", createdResponse?.Name);
            Assert.IsNull(nullResponse);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var updates = new FootballPlayer() { Age = 22, Name = "Salman", ShirtNumber = 25 };
            var createdResponse = manager.Update(2, updates);

            Assert.AreEqual("Salman", createdResponse?.Name);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var createdResponse = manager.Delete(1);

            Assert.IsNull(manager.GetById(1));
        }
    }
}