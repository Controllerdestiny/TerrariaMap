
namespace TerrariaMap;
class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("请输入一个地图路径:");
        var path = Console.ReadLine();
        if(!File.Exists(path))
            throw new FileNotFoundException("找不到指令路径的地图文件!");
        Console.WriteLine("初始化中..");
        CreateMapFile.Instance.Init();
        Console.WriteLine("解析地图内容..");
        var info = CreateMapFile.Instance.Start(File.ReadAllBytes(path));
        Console.WriteLine("写入文件...");
        File.WriteAllBytes(info.Name,info.Buffer);
        Console.WriteLine($"小地图生成成功:{info.Name}");
    }

}

