using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class TaskT
    {
        private string GetManager(int id)
        {
            ManagerRepository _ma = new ManagerRepository();
            int i = 0;
            while (i<_ma.GetAllObject().Count()&&_ma.GetAllObject().ElementAt(i).comandId != id) i++;
            return _ma.GetAllObject().ElementAt(i).FIO;
        }//получаем ФИО менеджера для других функций
        public List<Tuple<int, string, int,int,string,string>> GetAllTasks()
        {
            List<Tuple<int, string, int, int, string, string>> tmp = new List<Tuple<int, string, int, int, string, string>>();
            TaskRepository _ta = new TaskRepository();

            int i = 0;
            while (i < _ta.GetAllObject().Count())
            {
                var tmp1= new Tuple<int, string, int, int, string, string>(_ta.GetAllObject().ElementAt(i).taskID,
                _ta.GetAllObject().ElementAt(i).name, Convert.ToInt32(_ta.GetAllObject().ElementAt(i).date_start), Convert.ToInt32(_ta.GetAllObject().ElementAt(i).date_end),
                _ta.GetAllObject().ElementAt(i).checkList,GetManager(_ta.GetAllObject().ElementAt(i).taskID));
                tmp.Add(tmp1);
                i++;
            }
            return tmp;
        }//получаем список всех задач
        public bool AddTask(int Id, string name, int date_end,string FIO,int admin)
        {
            task t = new task();
            TaskRepository _t = new TaskRepository();
            t.taskID = Id;
            t.name = name;
            t.date_end = date_end;
            t.date_start =DateTime.Today.Day;
            t.state = "Ready to begin";
            _t.Create(t);
            _t.Save();
            if(CreatChat(Id,name)&& CreateCommand(Id, Id, admin)&&UpdateManager(FIO,Id))
            return true;
            else
            {
                _t.Delete(Id);
                _t.Save();
                return false;
            }
        }//добавляем задачу
        private bool CreatChat(int ID,string name)
        {
            chat c = new chat();
            ChatRepository _c = new ChatRepository();
            c.chatId = ID;
            c.namechat = name;
            _c.Create(c);
            _c.Save();
            return true;
        }//создание чата для задачи
        private bool UpdateManager(string FIO,int Id)
        {
            ManagerRepository _m = new ManagerRepository();
            int i = 0;
            while (i<_m.GetAllObject().Count()&&_m.GetAllObject().ElementAt(i).FIO != FIO) i++;
            if (i == _m.GetAllObject().Count()) return false;
            i = _m.GetAllObject().ElementAt(i).managerId;
            if (_m.GetObject(i).comandId != null) return false;
            _m.GetObject(i).comandId = Id;
            _m.Update(_m.GetObject(i));
            _m.Save();
            return true;

        }//обновляем данные о менеджере(ставим ему в поле задачу)
        private bool CreateCommand(int TId,int CID,int adId)
        {
            comand c = new comand();
            ComandRepository _c = new ComandRepository();
            c.comandId = TId;
            c.chatidID = CID;
            c.adminID = adId;
            c.taskID = TId;
            _c.Create(c);
            _c.Save();
            return true;
        }//создаем команду для задачи
        public bool DeleteTASK(int Id)
        {
            TaskRepository _t = new TaskRepository();

            return true;
        }
    }
}
