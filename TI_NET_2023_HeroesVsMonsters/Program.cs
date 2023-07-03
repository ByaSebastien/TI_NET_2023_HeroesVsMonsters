using TI_NET_2023_HeroesVsMonsters;
using TI_NET_2023_HeroesVsMonsters.UI;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.CursorVisible = false;
IUi ui = new Ui();
Game game = new Game(ui);
game.Start();
Console.ReadKey();