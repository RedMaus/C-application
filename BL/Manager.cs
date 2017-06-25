using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class ManagerCl
    {
        Chat c = new Chat();
        public string State(int id)
        {
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            if(_m.GetObject(id).comandId!=null)
            return _t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).state;
            else
            return "";
        }//получаем состояние задачи у менеджера
        public string Deadline(int id)
        {
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            if (_m.GetObject(id).comandId != null)
                return Convert.ToString(_t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).date_end);
            else
                return "";
        }//получаем дедлайн у менеджера
        public string GetName(int id)
        {
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            if (_m.GetObject(id).comandId != null)
                return _t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).name;
            else
                return "";
        }
        public void ChangeState(int id,string edit,string state)
        {
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            _t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).state=state;
            _t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).checkList = edit;
            _t.Update(_t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)));
            _t.Save();
        }//получаем меняем состояние задачи у менеджера с записью правок и самого состояния
        public void ChangeDeadline(int id, string edit, int dead)
        {
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            _t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).date_end = dead;
            _t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).checkList = edit;
            _t.Update(_t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)));
            _t.Save();
        }
        public List<string> ShowEdits(int id)
        {
            List<string> tmp = new List<string>();
            ManagerRepository _m = new ManagerRepository();
            ComandRepository _c = new ComandRepository();
            TaskRepository _t = new TaskRepository();
            tmp.Add(_t.GetObject(Convert.ToInt32(_c.GetObject(Convert.ToInt32(_m.GetObject(id).comandId)).taskID)).checkList);

            return tmp;
        }//получаем в список правки
        public List<Tuple<int,string>> GetAllEmployers(int id)
        {
            List<Tuple<int, string>> tmp = new List<Tuple<int, string>>();
            EmployeeRepository _em = new EmployeeRepository();
            ManagerRepository _m = new ManagerRepository();
            int id1=Convert.ToInt32(_m.GetObject(id).comandId);
            for(int i=0;i<_em.GetAllObject().Count();i++)
                if (_em.GetAllObject().ElementAt(i).comandId == id1)
                {
                    Tuple<int, string> tmp1 = new Tuple<int, string>(_em.GetAllObject().ElementAt(i).emplId, _em.GetAllObject().ElementAt(i).FIO);
                    tmp.Add(tmp1);
                }
            return tmp;
        }//получаем всех сотрудников на этой задаче
        public void AddEmploye(int id,string FIO)
        {
            ManagerRepository _m = new ManagerRepository();
            EmployeeRepository _n = new EmployeeRepository();
            id = Convert.ToInt32(_m.GetObject(id).comandId);
            int i = 0;
            while (_n.GetAllObject().ElementAt(i).FIO != FIO) i++;
            i = _n.GetAllObject().ElementAt(i).emplId;
            _n.GetObject(i).comandId = id;
            _n.Update(_n.GetObject(i));
            _n.Save();
        }//добавляем по ФИО сотрудника на задачу
        public void DeleteEmploye(int id, string FIO)
        {
            ManagerRepository _m = new ManagerRepository();
            EmployeeRepository _n = new EmployeeRepository();
            id = Convert.ToInt32(_m.GetObject(id).comandId);
            int i = 0;
            while (_n.GetAllObject().ElementAt(i).FIO != FIO) i++;
            i = _n.GetAllObject().ElementAt(i).emplId;
            _n.GetObject(i).comandId = null;
            _n.Update(_n.GetObject(i));
            _n.Save();
        }
        public int GetCom(int id)
        {
            ManagerRepository _m = new ManagerRepository();

            return Convert.ToInt32(_m.GetObject(id).comandId);
        }
    }
}
