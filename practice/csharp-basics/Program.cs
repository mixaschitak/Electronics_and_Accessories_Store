Console.OutputEncoding = System.Text.Encoding.UTF8;

// Задание 1
// string name;
// int quantity, price;
// name = "Пепперони";
// quantity = 2;
// price = 590;
// int total = quantity * price;
// Console.WriteLine($"{name} × {quantity} = {total} ₽");

// Задание 2
// int totalMinutes = 135;
// int hours = totalMinutes / 60;
// int minutes = totalMinutes % 60;
// Console.WriteLine($"Доставка займёт {hours} ч {minutes} мин");

// Задание 3
// int order = 1490;
// int MoneyHave = 2000;
// int change = MoneyHave - order;
// int banknote = change / 100;
// int SmallChange = change % 100;
// Console.WriteLine($"Купюр по 100: {banknote}, мелочью: {SmallChange}");

// Задание 4
// string pizza = "Четыре Сыра";
// Console.WriteLine(pizza.ToUpper());
// Console.WriteLine(pizza.ToLower());
// Console.WriteLine($"Длина: {pizza.Length}");

// Задание 5
// string userInput = " маргарита ";
// string menuItem = "Маргарита";
// string cleanInput = userInput.Trim().ToLower();
// string cleanMenu = menuItem.Trim().ToLower();
// bool isMatch = cleanInput == cleanMenu;
// Console.WriteLine($"Совпадает: {isMatch}");

// Задание 6
// string slovo = "пепперони";
// slovo = char.ToUpper(slovo[0]) + slovo.Substring(1);
// Console.WriteLine(slovo);

// Задание 7
// string text = "томаты моцарелла базилик оливковое масло";
// string[] words = text.Split(' ');
// int count = words.Length;
// Console.WriteLine($"Слов в составе: {count}");

// Задание 8
// string str = "Иванов Иван Петрович";
// char firstChar = str[7];
// char firstChar1 = str[12];
// Console.WriteLine($"{str.Substring(0, 6)} {firstChar}. {firstChar1}.");

// Задание 9
// string inputNumber = "+7 900 123-45-67";
// string cleanNumber = inputNumber.Replace(" ", "").Replace("-", "");
// Console.WriteLine(cleanNumber);
// 
// if (cleanNumber.StartsWith("+7") && cleanNumber.Length == 12)
// {
//     Console.WriteLine("Номер подходит");
// }
// else
// {
//     Console.WriteLine("Неверный номер");
// }

// Задание 10
// int number = 1003;
// 
// if (number % 2 == 0)
// {
//     Console.WriteLine("Четное");
// }
// else
// {
//     Console.WriteLine("Нечетное");
// }

// Задание 11
// int currentHour = 23;
// int openHour = 10;
// int closeHour = 22;
// 
// if (currentHour >= openHour && currentHour < closeHour)
// {
//     Console.WriteLine("Открыто");
// }
// else
// {
//     Console.WriteLine("Закрыто, откроемся в 10:00");
// }

// Задание 12
// int diameter = 30;
// 
// if (diameter == 25)
// {
//     Console.WriteLine("Маленькая");
// }
// else if (diameter == 30)
// {
//     Console.WriteLine("Средняя");
// }
// else if (diameter == 35)
// {
//     Console.WriteLine("Большая");
// }
// else
// {
//     Console.WriteLine("Такого размера нет");
// }

// Задание 13
// int total = 2350;
// int small = 1000;
// int big = 2000;
// int percent;
// int discount;
// int sum;
// 
// if (total >= big)
// {
//     percent = 10;
// }
// else if (total >= small)
// {
//     percent = 5;
// }
// else
// {
//     percent = 0;
// }
// 
// discount = total * percent / 100;
// sum = total - discount;
// 
// Console.WriteLine($"Скидка {percent}%: {discount} ₽, к оплате {sum} ₽");

// Задание 14
// string inputLogin = "admin";
// string inputPassword = "1234";
// string correctLogin = "admin";
// string correctPassword = "12345";
// 
// if (inputLogin == correctLogin)
// {
//     if (inputPassword == correctPassword)
//     {
//         Console.WriteLine("Добро пожаловать");
//     }
//     else
//     {
//         Console.WriteLine("Неверный пароль");
//     }
// }
// else
// {
//     Console.WriteLine("Пользователь не найден");
// }

// Задание 15
// int dayNumber = 3;
// 
// switch (dayNumber)
// {
//     case 1:
//         Console.WriteLine("Понедельник");
//         break;
//     case 2:
//         Console.WriteLine("Вторник");
//         break;
//     case 3:
//         Console.WriteLine("Среда");
//         break;
//     case 4:
//         Console.WriteLine("Четверг");
//         break;
//     case 5:
//         Console.WriteLine("Пятница");
//         break;
//     case 6:
//         Console.WriteLine("Суббота");
//         break;
//     case 7:
//         Console.WriteLine("Воскресенье");
//         break;
//     default:
//         Console.WriteLine("Нет такого дня");
//         break;
// }


// Задание 16
// Console.OutputEncoding = System.Text.Encoding.UTF8;
// int stock = 0;
// string status = stock > 0 ? "В наличии" : "Нет в наличии";
// Console.WriteLine($"Маргарита: {status}");


// Задание 17
// Console.OutputEncoding = System.Text.Encoding.UTF8;
// int count = 3;
// string word = count == 1 ? "пицца" : "пиццы";
// Console.WriteLine($"В корзине {count} {word}");


// Задание 18
// int price1 = 590;
// int price2 = 620;
// int maxPrice = price1 > price2 ? price1 : price2;
// Console.WriteLine($"Дороже: {maxPrice} ₽");



// Задание 19
// Console.OutputEncoding = System.Text.Encoding.UTF8;
//  double rating = 4.2;
// string grade = rating >= 4.5 ? "Отлично" : (rating >= 3.5 ? "Хорошо" : "Так себе");
// Console.WriteLine($"Оценка: {grade}");


// Задание 20
// for (int i = 1; i <= 10; i++)
//     {
//         Console.Write(i + " ");
//     }
// Console.WriteLine();