Console.OutputEncoding = System.Text.Encoding.UTF8;

string name;
int quantity, price;
name = "Пепперони";
quantity = 2;
price = 590;
 int total = quantity * price;

Console.WriteLine($"{name} × {quantity} = {total} ₽");