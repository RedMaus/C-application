using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using BL;
using System.Collections.Generic;
using System.Linq;


namespace BL.Tests
{
    [TestClass]
    public class BLTests
    {
        [TestMethod]
        public void Authethification_Fio1andId1_containsFioAndId()
        {
            AdmininRepository _ad = new AdmininRepository();
            EmployeeRepository _em = new EmployeeRepository();
            ManagerRepository _me = new ManagerRepository();

            string FIO_ad = "1";
            string Id_ad = "1";
            string FIO_em = "1";
            string Id_em = "1";
            string FIO_me = "1";
            string Id_me = "1";

            _ad.GetObject(Convert.ToInt32(Id_ad)).FIO = FIO_ad;
            _em.GetObject(Convert.ToInt32(Id_em)).FIO = FIO_em;
            _me.GetObject(Convert.ToInt32(Id_me)).FIO = FIO_me;

            Assert.AreEqual(FIO_ad, Id_ad);
            Assert.AreEqual(FIO_em, Id_em);
            Assert.AreEqual(FIO_me, Id_me);
        }

        [TestMethod]
        public void GetManager_firstId_fiomenager1()
        {
            ManagerRepository _ma = new ManagerRepository();
            //manager ma = new manager();

            int i = 0;
            //string fio = ma.FIO;
            string fio = _ma.GetAllObject().ElementAt(i).FIO;

            Assert.AreEqual(fio, "Evgen Belik");
        }

        [TestMethod]
        public void AddTask_name1_name1Out()
        {
            task t = new task();
            TaskRepository _t = new TaskRepository();
            string name = "Task1";

            t.name = name;

            Assert.AreEqual(t.name, name);
        }

        [TestMethod]
        public void StateTaskManager_stat1_equalstat1()
        {
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            int id = 0;
            string state2 = "";
            string state1 = _t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).state;

            Assert.AreEqual(state1, state2);
        }

        [TestMethod]
        public void StateDedLineManager_stat1_equalstat1()
        {
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            int id = 0;
            string state2 = "";
            string state1 = Convert.ToString(_t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).date_end);

            Assert.AreEqual(state1, state2);
        }

        [TestMethod]
        public void StateNameManager_stat1_equalstat1()
        {
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            int id = 0;
            string state2 = "";
            string state1 = _t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).name;

            Assert.AreEqual(state1, state2);
        }

    }
}
