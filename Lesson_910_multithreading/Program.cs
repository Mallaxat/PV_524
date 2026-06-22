using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_910_multithreading
{


    /*
     * 
     * Ыуьфзрщку -  WaitOne() ожидание одного обработчика
     * Release() - освобождает место в симафоре
     */
    internal class Program
    {
        static int x = 0;
        static object locker = new  object();





        static void Main(string[] args)
        {
            //поток это часть кода программы, этому потоку выделяется квант времени и при помощи механизма многопоточности
            //Можно сделать чтобы несколько задач выполнялись одновременно


            //1 - основные свойства потока
            /*
                        Thread t = Thread.CurrentThread;                        //создали поток и положили в него текущий поток


                        Console.WriteLine($"Имя потока: {t.Name}");             //Стандартное имя потока
                        t.Name = "Метод Main";
                        Console.WriteLine($"Имя потока: {t.Name}");             //Задать новое имя потока

                        Console.WriteLine($"Запущен ли поток: {t.IsAlive}"); 
                        Console.WriteLine($"Приоритет потока: {t.Priority}");
                        Console.WriteLine($"Статус потока: {t.ThreadState}");

                        //Домен приложения-в какой части работает наш поток. 
                        //Метод возвращает ссылку на домен приложения
                        //Условно домен это что-то вроде адреса приложения 
                        Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");

                        Console.ReadLine();*/

            //2 - создание нескольких потоков и работа через делегат

            /*            //Создается несколько потоков
                        Thread myThread1 = new Thread(Print1);                                       //
                        Thread myThread2 = new Thread(new ThreadStart(Print));                      //Использование делегата ThreadStart
                        Thread myThread3 = new Thread(() => Console.WriteLine("Hello Threads_3"));    //

                        myThread1.Start();
                        myThread2.Start();
                        myThread3.Start();

                        //Метод для делегата
                        void Print1() => Console.WriteLine("Hello Threads_1");
                        void Print() => Console.WriteLine("Hello Threads_2");*/

            //3 Несколько потоков одновременно main это тоже поток
            /*            Thread myThread1 = new Thread(Print);
                        myThread1.Start();
                        for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine($"Первый поток {i}");
                        }
                        Thread.Sleep(300);


            */

            //4 очередность потоков
            /*            //Главный поток получает приоритет, но в каждую иттерацию спит 300 мл, но если этого
                        //времени хватает для выполнения второго потока, то он запустится
                        //Основной поток 
                        Thread myThread = new Thread(new ThreadStart(Count)); //Через делегат запускаем в потоке метод Count
                        myThread.Start(); // запускаем поток

                        for (int i = 1; i < 9; i++)
                        {
                            //Первый раз запустится основной, а потом фоновый режим
                            Console.WriteLine($"Главный поток:  {i}");
                            Console.WriteLine(i + i);
                            Thread.Sleep(50);
                        }

                        Console.ReadLine();*/

            //5 ParametrizedThreadStart запуск через делегат с параметрами
            /*
                        Thread myThread1 = new Thread(new ParameterizedThreadStart(Print)); //Делегат для метода с параметром
                        Thread myThread2 = new Thread(Print);
                        Thread myThread3 = new Thread(message => Console.WriteLine(message));

                        myThread1.Start("Hello");
                        myThread2.Start("Привет");
                        myThread3.Start("Salut");


                        void Print(object mes) => Console.WriteLine(mes);*/

            //6
            /*            Thread myThread1 = new Thread(new ParameterizedThreadStart(Print));
                        Thread myThread2 = new Thread(Print);
                        Thread myThread3 = new Thread(message => Console.WriteLine(message));

                        myThread1.Start("Hello");
                        myThread2.Start("Привет");
                        myThread3.Start("Salut");*/

            //7
            /*            int number = 4;
                        // создаем новый поток
                        Thread myThread = new Thread(new ParameterizedThreadStart(Count));
                        myThread.Start(number);

                        for (int i = 1; i < 9; i++)
                        {
                            Console.WriteLine("Главный поток:");
                            Console.WriteLine(i * i);
                            Thread.Sleep(300);
                        }

                        Console.ReadLine();*/

            //8 Работа с 1 локальной переменной Lock блокирует и ждем
            /* 
                        for (int i = 1; i < 6; i++)
                        {
                            Thread myThread = new Thread(Print);
                            myThread.Name = $"Поток {i}";
                            x++;
                            myThread.Start();
                        }
            */
            //9 Симафор открыто/закрыто доступ к конкретному потоку
            /*
                        for(int i=1;i<6;i++)
                        {
                            Reader reader = new Reader(i);
                        }
            */

            //10
            /*            Person p1 = new Person("Ivan", 30);
                        Thread thr = new Thread(Print);
                        thr.Start(p1);*/

            //11 timer
            int num = 5;
            TimerCallback tm=new TimerCallback(Count);
            Timer timer=new Timer(tm,num,0,2000);
            Console.ReadLine();

        }//Main

        //Методы

        private static void Count(object obj)
        {
            int x = (int)obj;
            for(int i = 0; i < 9; i++,x++)
            {
                Console.WriteLine($"{x*i}");
            }
        }


        //10 Класс в качестве параметра
        /*        private static void Print(object obj)
                {
                    if (obj is Person p)
                    {
                        Console.WriteLine($"{p.Name}");
                        Console.WriteLine($"{p.Age}");
                    }
                }
                public class Person
                {
                    public string Name { get; set; }
                    public int Age { get; set; }
                    public Person(string _name, int _age)
                    {
                        Name = _name;
                        Age = _age;
                    }
                }*/


        //9
        /*
                class Reader
                {
                    // создаем семафор
                    static Semaphore sem = new Semaphore(3, 3);    //Ограничивает кол-во потоков, которые имеют доступ к определенным ресурсам
                    Thread myThread;
                    int count = 3;// счетчик чтения

                    public Reader(int i)
                    {
                        myThread = new Thread(Read);
                        myThread.Name = $"Читатель {i}";
                        myThread.Start();
                    }

                    public void Read()
                    {
                        while (count > 0)
                        {
                            sem.WaitOne();  // ожидаем, когда освободиться место

                            Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
                            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                            Thread.Sleep(1000);

                            Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                            sem.Release();  // освобождаем место

                            count--;
                            Thread.Sleep(1000);
                        }
                    }
                }
        */


        /*        private static void Print()
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine($"Второй поток {i}");
                    }
                    Thread.Sleep(500);
                }*/

        /*        private static void Count()
                {
                    for (int i = 1; i < 9; i++)
                    {
                        Console.WriteLine($"Второй поток: {i} ");
                        Console.WriteLine(i * i);
                        Thread.Sleep(400);
                    }
                }*/
        /*        public static void Count(object x)
                {
                    for (int i = 1; i < 9; i++)
                    {
                        int n = (int)x;

                        Console.WriteLine("Второй поток:");
                        Console.WriteLine(i * n);
                        Thread.Sleep(400);
                    }
                }*/
        //8
        /*        static void Print()

                {
                    // locker Это объект, lock это оператор, который определяет блок кода,
                    // внутри которого блок кода блокируется до завершения работы с текущим потоком
                    //Т.Е очередь ожидания
                    lock (locker)
                    {
                        x = 1;
                        for (int i = 1; i < 6; i++)
                        {
                            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                            x++;
                            Thread.Sleep(100);
                        }
                    }

                }*/

    }
}

