using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class User
    {
        public string Authethification(string FIO,string Id)
        {
            if (FIO == "" || Id == "") return "";
            AdmininRepository _ad = new AdmininRepository();
            if ((_ad.GetObject(Convert.ToInt32(Id))!= null)&&
                (_ad.GetObject(Convert.ToInt32(Id)).FIO==FIO)) return "admin";
            EmployeeRepository _em = new EmployeeRepository();
            if ((_em.GetObject(Convert.ToInt32(Id)) != null) &&
                (_em.GetObject(Convert.ToInt32(Id)).FIO == FIO)) return "employer";
            ManagerRepository _me = new ManagerRepository();
            if ((_me.GetObject(Convert.ToInt32(Id)) != null) &&
                (_me.GetObject(Convert.ToInt32(Id)).FIO == FIO)) return "manager";
            return "";
        }//проверям есть ли такое сочетание ФИО и ИД в наших таблицах
        public List<Tuple<int,string,string>> GetAllUsers(string Id,string Fio,string position)
        {
            List<Tuple<int, string, string>> tmp=new List<Tuple<int, string, string>>();
            ManagerRepository _me = new ManagerRepository();
            EmployeeRepository _em = new EmployeeRepository();
            AdmininRepository _ad = new AdmininRepository();
            int i = 0;
            while (i < _ad.GetAllObject().Count()) {                
                var tmp1=new Tuple<int, string, string>(_ad.GetAllObject().ElementAt(i).adminId,
                    _ad.GetAllObject().ElementAt(i).FIO, "admin");
                if ((Id != "" && tmp1.Item1 != Convert.ToInt32(Id))
                    || (Fio != "" && !tmp1.Item2.Contains(Fio))
                    || (position != "" && !tmp1.Item3.Contains(position))) i++;
                else{ tmp.Add(tmp1); i++; }
            }
            i = 0;
            while (i < _me.GetAllObject().Count())
            {
                var tmp1 = new Tuple<int, string, string>(_me.GetAllObject().ElementAt(i).managerId,
                    _me.GetAllObject().ElementAt(i).FIO, "manager");
                if ((Id != "" && tmp1.Item1 != Convert.ToInt32(Id))
                    || (Fio != "" && !tmp1.Item2.Contains(Fio))
                    || (position != "" && !tmp1.Item3.Contains(position))) i++;
                else { tmp.Add(tmp1); i++; }
            }
            i = 0;
            while (i < _em.GetAllObject().Count())
            {
                var tmp1 = new Tuple<int, string, string>(_em.GetAllObject().ElementAt(i).emplId,
                    _em.GetAllObject().ElementAt(i).FIO, "employer");
                if ((Id != "" && tmp1.Item1 != Convert.ToInt32(Id))
                    || (Fio != "" && !tmp1.Item2.Contains(Fio))
                    || (position != "" && !tmp1.Item3.Contains(position))) i++;
                else { tmp.Add(tmp1); i++; }
            }            
            return tmp;
        }
        public bool AddUser(int Id,string FIO,string position)
        {
            if(FIO==""||position=="")return false;
            else
            switch (position)
            {
                case "admin":
                    adminin tmp = new adminin();
                    tmp.FIO = FIO;
                    tmp.adminId = Id;
                    AdmininRepository _ad = new AdmininRepository();
                        if (_ad.GetObject(Id) != null) return false;
                        else { _ad.Create(tmp); _ad.Save(); return true; }
                case "employer":
                    EmployeeRepository _em = new EmployeeRepository();
                    employee tmp1 = new employee();
                    tmp1.FIO = FIO;
                    tmp1.emplId = Id;
                    if (_em.GetObject(Id) != null) return false;
                    else { _em.Create(tmp1);_em.Save(); return true; }
                case "manager":
                    ManagerRepository _me= new ManagerRepository();
                        manager tmp2 = new manager();
                        tmp2.FIO = FIO;
                        tmp2.managerId = Id;
                        if (_me.GetObject(Id) != null) return false;
                        else { _me.Create(tmp2); _me.Save(); return true; }
                    default:
                        return false;
            }
        }
        public bool DeleteUser(int Id, string FIO, string position)
        {
                switch (position)
                {
                  case "admin":
                    AdmininRepository _ad = new AdmininRepository();
                    ComandRepository _com = new ComandRepository();
                    if (_com.GetObject(Id) != null) return false;
                    _ad.Delete(Id);
                    _ad.Save();
                    return true;                   
                  case "employer":
                    EmployeeRepository _em = new EmployeeRepository();
                    if (_em.GetObject(Id).comandId != null) return false;
                    _em.Delete(Id);
                    _em.Save();
                    return true;
                  case "manager":                    
                    ManagerRepository _me= new ManagerRepository();
                    if (_me.GetObject(Id).comandId != null) return false;
                    _me.Delete(Id);
                    _me.Save();
                    return true;
                default:
                    return false;
                }
        }
        public bool UpdateUser(int Id,string FIO,string position,int newId,string newFIO,string newPosition)
        {
            if (!position.Contains(newPosition)) {
                if (!DeleteUser(Id, FIO, position))
                {
                    return false;
                }
                AddUser(newId, newFIO, newPosition);
                return true;
            }
            switch (position){
                case "admin":
                    AdmininRepository _ad = new AdmininRepository();
                    _ad.GetObject(Id).FIO = newFIO;
                    _ad.Update(_ad.GetObject(Id));
                    _ad.Save();
                    break;
                case "employer":
                    EmployeeRepository _em = new EmployeeRepository();
                    _em.GetObject(Id).FIO = newFIO;
                    _em.Update(_em.GetObject(Id));
                    _em.Save();
                    break;
                case "manager":
                    ManagerRepository _me = new ManagerRepository();
                    _me.GetObject(Id).FIO = newFIO;
                    _me.Update(_me.GetObject(Id));
                    _me.Save();
                    break;
            }
            return true;
        }
        public int GetUserCOmand(int id)
        {
            EmployeeRepository _em = new EmployeeRepository();
            return Convert.ToInt32(_em.GetObject(id).comandId);
        }//получаем ид команды у сотрудника
    }
}
