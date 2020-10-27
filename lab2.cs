using System;



namespace lab2
{
    class Program
    {
        class complex  //конвертирование мнимой и действительной части в комплексную форму и перегрузка операторов
        {
            public double re, im;

            public complex()
            {
                re = 0;
                im = 0;
            }
            public complex(double r, double i)
            {
                re = r;
                im = i;  
            }

            public static complex operator +(complex z1,complex z2) //перегрузка сложения
            {
               
                return new complex(z1.re + z2.re, z1.im + z2.im);
               
            }

            public static complex operator -(complex z1, complex z2) //перегрузка вычитания
            {

                return new complex(z1.re - z2.re, z1.im - z2.im);

            }

            public static complex operator *(complex z1, complex z2) //перегрузка умножения
            {

                return new complex(z1.re*z2.re - z1.im * z2.im, z1.re*z2.im + z1.im*z2.re);

            }
        }
 
        public static void Main(string[] args)
        {
         
            Console.WriteLine("В какой форме будет ввод числа?\n1)алгебраическая форма\n2) экспоненциальная\n выберите номер >"); //консольное меню

            int c = Convert.ToInt32(Console.ReadLine());

            if (c == 1){//алгебраическая форма

                Console.WriteLine("Введите действительную часть 1 числа"); //ввод действительной и мнимой частей 1 числа
                double re1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите мнимую часть 1 числа");
                double im1 = Convert.ToDouble(Console.ReadLine());

                complex z1 = new complex(re1, im1); //создание комплексного числа

                Console.WriteLine("Введите действительную часть 2 числа"); //ввод действительной и мнимой частей 2 числа
                double re2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите мнимую часть 2 числа");
                double im2 = Convert.ToDouble(Console.ReadLine());

                complex z2 = new complex(re2, im2);

                Console.WriteLine("Выберите операцию\nСложение - 1\nВычитание - 2\nУмножение - 3"); //выбор операции

                int d = Convert.ToInt32(Console.ReadLine());
                
                if (d == 1)
                {
                    complex s = z1 + z2;
                    Console.WriteLine("{0}+{1}*i", s.re, s.im); //вывод в алгебраической форме

                }
                if (d == 2)
                {
                    complex s = z1 - z2;
                    Console.WriteLine("{0}+{1}*i", s.re, s.im);

                }

                if (d == 3)
                {
                    complex s = z1 * z2;
                    Console.WriteLine("{0}+{1}*i", s.re, s.im);

                }
            }
            else//число в показательной форме
            {
                Console.WriteLine("Введите модуль 1"); //ввод модуля и аргумента для показательной формы
                double r1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите аргумент 1");  //ввод в градусах
                double fi1 = Convert.ToDouble(Console.ReadLine());

                double re1 = r1 * Math.Cos(fi1* Math.PI / 180);  //преобразование в алгебраическую форму для удобства счета
                double im1 = r1 * Math.Sin(fi1 * Math.PI / 180);
                
                complex z1 = new complex (re1,im1); //создание комплексного числа


                Console.WriteLine("Введите модуль 2");
                double r2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите аргумент 2");
                double fi2 = Convert.ToDouble(Console.ReadLine());
                
                double re2 = r1 * Math.Cos(fi2 * Math.PI / 180);
                double im2 = r1 * Math.Sin(fi2 * Math.PI / 180);

                complex z2 = new complex(re2, im2);

                Console.WriteLine("Выберите операцию\nСложение - 1\nВычитание - 2\nУмножение - 3"); //выбор операции

                int d = Convert.ToInt32(Console.ReadLine());

                if (d == 1)
                {
                    complex s = z1 + z2;
                    double r = Math.Sqrt((s.re) * (s.re) + (s.im) * (s.im)); //преобразование в показательную форму
                    double fi = Math.Atan2(s.im , s.re);

                    Console.WriteLine("{0}*exp^({1}*i)", r, fi*180/Math.PI); //вывод в показательной форме

                }
                if (d == 2)
                {
                    complex s = z1 - z2;
                    double r = Math.Sqrt((s.re) * (s.re) + (s.im) * (s.im));
                    double fi = Math.Atan2(s.im , s.re);

                    Console.WriteLine("{0}*exp^({1}*i)", r, fi * 180 / Math.PI);

                }

                if (d == 3)
                {
                    complex s = z1 * z2;
                    double r = Math.Sqrt((s.re) * (s.re) + (s.im) * (s.im));
                    double fi = Math.Atan2(s.im , s.re);

                    Console.WriteLine("{0}*exp^({1}*i)", r, fi * 180 / Math.PI);

                }
            }
            }
        }
    }

