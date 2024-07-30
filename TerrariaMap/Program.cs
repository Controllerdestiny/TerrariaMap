
using System.IO.MemoryMappedFiles;

namespace TerrariaMap;
class Program
{
    static void Main(string[] args)
    {
        CreateMapFile.Instance.Init();
        var param = ParseArguements(Environment.GetCommandLineArgs());
		var name = param["-mapname"];
		//var res = CreateMapFile.Instance.Start(File.ReadAllBytes("地图.wld"));
		//File.WriteAllBytes(res.Name, res.Buffer);
		IPC.Start(name);
	}

    
 

    public static Dictionary<string, string> ParseArguements(string[] args)
	{
		string text = null;
		string text2 = "";
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < args.Length; i++)
		{
			if (args[i].Length == 0)
			{
				continue;
			}
			if (args[i][0] == '-' || args[i][0] == '+')
			{
				if (text != null)
				{
					dictionary.Add(text.ToLower(), text2);
					text2 = "";
				}
				text = args[i];
				text2 = "";
			}
			else
			{
				if (text2 != "")
				{
					text2 += " ";
				}
				text2 += args[i];
			}
		}
		if (text != null)
		{
			dictionary.Add(text.ToLower(), text2);
			text2 = "";
		}
		return dictionary;
	}


}

