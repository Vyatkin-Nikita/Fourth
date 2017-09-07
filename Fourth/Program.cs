using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourth
{
    /*
       Программа высчитывает приблизительное значение уравнения x^5 - x - 0.2 = 0 с заданной точностью,
       (у уравнения нет корней в заданном диапозоне)
    */
    class Program
    {
        static double eps, X1 = 1.0, X2 = 1.1, Xmid;
        static double VvodProverka()//Проверка вводимой с клавиатуры точности
        {
            bool ok;
            double n;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n);
                if (!ok) { Console.WriteLine("Ошибка. Неверный формат данных. Повторите ввод."); continue; }
                if (n <= 0 || n > 0.1) { Console.WriteLine("Ошибка. Точность должна быть больше 0, но меньше или равна 0,1. Повторите ввод."); ok = false; }
            } while (!ok);
            Console.WriteLine();
            return n;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите точность E");//Ввод и проверка точности
            eps = VvodProverka();

            do //Метод деления отрезка пополам
            {
                Xmid = (X1 + X2) / 2.0;
                if ((Math.Pow(Xmid, 5) - Xmid - 0.2) == 0) { break; } //Если с полученным значением значение выражения равно 0, значит найден точный корень
                if ((Math.Pow(X1, 5) - X1 - 0.2) * (Math.Pow(Xmid, 5) - Xmid - 0.2) < 0) { X2 = Xmid; }//Если если при концевых значениях левого отрезка выражение имеет разные знаки, значит работает дальше с этой половиной
                else { X1 = Xmid; }//Иначе работаем с правой половиной
            }
            while (X2 - X1 > eps);//Алгоритм работает до достижения заданной точности

            Console.WriteLine("Приближённое значение корня выражения x^5 - x - 0.2 = 0 равно " + Xmid);
            Console.ReadLine();
        }
    }
}
