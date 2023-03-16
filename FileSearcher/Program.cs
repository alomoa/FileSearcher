// See https://aka.ms/new-console-template for more information

static String GetUserInput()
{
    Console.WriteLine("Enter a directory path");
    var path = Console.ReadLine();
    return path;
}


static void Run()
{
    var path = GetUserInput();

    Directory.GetFiles(path);
}

