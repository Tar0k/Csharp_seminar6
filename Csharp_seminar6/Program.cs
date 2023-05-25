
var tasks = new Dictionary<int, Action>
{
    { 41, Task41 },
    { 43, Task43 }
};
tasks[GetTaskFromUser(tasks.Keys.ToArray())].Invoke();


void Task41()
{
    // Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
    // 0, 7, 8, -2, -2 -> 2
    // 1, -7, 567, 89, 223-> 3
    Console.WriteLine("Задача 41");
    var userInput = GetStringFromUser("числа (через ,)");
    var numbers = userInput.Split(",")
        .Select(number => int.TryParse(number, out var num) ? num : 0);
    var positiveNumbers = numbers.Count(number => number > 0);
    Console.WriteLine($"Введено {positiveNumbers} положительных чисел");
}

void Task43()
{
    // Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых,
    // заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
    // b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
    
    //k1x - k2x = b2 - b1
    //5x - 9x = 4 - 2
    //-4x = 2
    // x  = -0.5
    Console.WriteLine("Задача 43");
    var b1 = GetIntFromUser("b1");
    var k1 = GetIntFromUser("k1");
    var b2 = GetIntFromUser("b2");
    var k2 = GetIntFromUser("k2");
    if (k1 == k2)
    {
        Console.WriteLine("Прямые параллельны друг други и не имеют пересечений");
        return;
    }
    var temp1 = k1 - k2;
    var temp2 = b2 - b1;
    var xCoord = (double)temp2 / temp1;

    var yCoord = k1 * xCoord + b1;
    
    Console.WriteLine($"Пересечение прямых в точке x = {xCoord}, y = {yCoord}");
}



int GetTaskFromUser(int[] availableTasks)
{
    while (true)
    {
        Console.Write("Введите номер задания: ");
        var userInput = Console.ReadLine();

        if (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("!!!НИЧЕГО НЕ ВВЕДЕНО!!!");
            continue;
        }
        
        if (!int.TryParse(userInput, out var taskNumber))
        {
            Console.WriteLine("!!!НЕ КОРРЕКТНЫЙ ВВОД!!!"); 
            continue;
        }

        if (availableTasks.Contains(taskNumber)) return taskNumber;
        Console.WriteLine("!!!ДАННОЙ ЗАДАЧИ НЕ ЗАЛОЖЕНО!!!");
    }
}

string GetStringFromUser(string valueDescription = "данные")
{
    while (true)
    {
        Console.Write($"Введите {valueDescription}: ");
        var userInput = Console.ReadLine();

        if (!string.IsNullOrEmpty(userInput)) return userInput;
        Console.WriteLine("!!!НИЧЕГО НЕ ВВЕДЕНО!!!");
    }
}

int GetIntFromUser(string valueDescription = "число")
{
    while (true)
    {
        Console.Write($"Введите {valueDescription}: ");
        var userInput = Console.ReadLine();
        
        if (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("!!!НИЧЕГО НЕ ВВЕДЕНО!!!");
            continue;
        }

        if (int.TryParse(userInput, out var number)) return number;
        Console.WriteLine("!!!НЕ КОРРЕКТНЫЙ ВВОД!!!");
    }
}


