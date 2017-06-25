using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class Chat
    {
        public List<string> ShowChat(int id)
        {
            List<string> tmp = new List<string>();
            MessagerRepository _m = new MessagerRepository();
            for(int i = 0; i < _m.GetAllObject().Count(); i++)
            {
                if (_m.GetAllObject().ElementAt(i).chatId == id)
                    tmp.Add(_m.GetAllObject().ElementAt(i).text_s+"\n\r send by:"+ _m.GetAllObject().ElementAt(i).employee.FIO);
            }
            return tmp;
        }//записываем в список поэлемнтно сообщения, выбирая их по ид чата
        public void SendMessage(string txt,int otp)
        {
            messager n = new messager();
            MessagerRepository _m = new MessagerRepository();
            EmployeeRepository _em = new EmployeeRepository();
            n.messageId = _m.GetAllObject().Count() + 1;
            n.text_s = txt;
            n.chatId =_em.GetObject(otp).comandId;
            n.sendId = otp;
            n.data_ot = DateTime.Today.Day;
            _m.Create(n);
            _m.Save();
        }//записываем в бд сообщение, с заданным текстом от пользователя
    }
}
