// See https://aka.ms/new-console-template for more information


using RobotCleanerCore;

Console.WriteLine("Hello, World!");

InputHandler inputHandler = new InputHandler();

NavigationManager navigationManager = new NavigationManager();
Console.WriteLine("> Enter number of commands(default is 0):");
inputHandler.SetNumberOfInput(Console.ReadLine());

Console.WriteLine("> Enter starting Position (default is 0 0):");
navigationManager.SetStartPosition(Console.ReadLine());

for (int i = 0; i < inputHandler.NumberOfCommands; i++) { 
    Console.WriteLine("> Enter Direction and Steps(eg: N 1):");
    navigationManager.AddCommand(Console.ReadLine());
}
Console.WriteLine("Input complete. Press any key to continue..");

Robot robot = new Robot(navigationManager);

Console.WriteLine("Robot is cleaning ..");
robot.Execute();

Console.WriteLine(robot.ShowResult());
Console.ReadLine();
