

using BethanyPieShop.InventoryManagement;
using BethanysPieShop.InventoryManagement;

PrintWelcome();

Utilities.InitializeStock();
Utilities.ShowMainMenu();
Console.WriteLine("Application shutting down ...");

Console.ReadLine();

#region Layout
static void PrintWelcome()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
  ____  _              _____            _           
 |  _ \| |            |  __ \          | |          
 | |_) | |_   _  ___  | |__) |___  _ __| | ___  ___ 
 |  _ <| | | | |/ _ \ |  _  // _ \| '__| |/ _ \/ __|
 | |_) | | |_| |  __/ | | \ \ (_) | |  | |  __/\__ \
 |____/|_|\__,_|\___| |_|  \_\___/|_|  |_|\___||___/
");
    Console.ResetColor();

    Console.WriteLine("Press Enter key to start logging in");

    Console.ReadLine();
    Console.Clear();

}

#endregion
