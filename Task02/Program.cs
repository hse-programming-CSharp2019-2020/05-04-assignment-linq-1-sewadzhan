using System;
using System.Linq;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            int[] arr = null;
            string s = Console.ReadLine();
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = ((s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).Select(x => int.Parse(x))).ToArray();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("InvalidOperationException");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("InvalidOperationException");
            }


            var filteredCollection = arr.TakeWhile(x => x != 0);
           
            try
            {
                if (filteredCollection.Count() == 0)
                {
                    throw new Exception();
                }
                // использовать статическую форму вызова метода подсчета среднего
                double averageUsingStaticForm = filteredCollection.Sum(x => Math.Pow(x, 2)) / filteredCollection.Count();
                Console.WriteLine($"{averageUsingStaticForm:F3}".Replace('.', ','));
                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = (from num in filteredCollection
                                                   select Math.Pow(num, 2)).Sum() / filteredCollection.Count();
                Console.WriteLine($"{averageUsingInstanceForm:F3}".Replace('.', ','));


                // вывести элементы коллекции в одну строку
                filteredCollection.ToList().ForEach(x => Console.Write("{0} ", x));
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("InvalidOperationException");
                return;
            }
        }
        
    }
}
