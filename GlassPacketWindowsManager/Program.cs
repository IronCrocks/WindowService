// See https://aka.ms/new-console-template for more information
using GlassPacketWindowsManager;

var articleNumbers = new List<string> {
   "4/16/4",
   "6 SG HD Silver Grey 32 ЗАК/16/6 м1/16/6 ЗАК",
   "4 TOP-N/14/6_м1",
   "4 ПлА2/16/4м1",
   "4 TOP-N/14ar/4 м1/14ar/4_StClBr",
   "10 м1/22/8 м1"};

foreach (var item in articleNumbers)
{
    ShowArticle(item);
}

Console.WriteLine("Введите артикул:");
Console.WriteLine();

string? selectedArticle = Console.ReadLine();
ShowArticle(selectedArticle!);

Console.ReadLine();

static void ShowArticle(string articleNumber)
{
    if (articleNumber is null) return;

    var count = WindowService.GetSegmentsCount(articleNumber);
    var windowThickness = WindowService.GetWindowThickness(articleNumber);
    var glassThickness = WindowService.GetGlassThickness(articleNumber);

    Console.WriteLine($"{articleNumber,-45}|{count,3}|{windowThickness,3}|{glassThickness,3}");
}