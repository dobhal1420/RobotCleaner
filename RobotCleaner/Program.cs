// See https://aka.ms/new-console-template for more information
using RobotCleanerClient;
using RobotCleanerCore;

Console.WriteLine("Hello, World!");

CommandHandler commandHandler = new CommandHandler();
Console.WriteLine("> Enter number of commands(default is 0):");
commandHandler.AddInput(Console.ReadLine());

Console.WriteLine("> Enter starting Position (default is 0 0):");
commandHandler.AddInput(Console.ReadLine());

for (int i = 0; i < commandHandler.NumberOfCommands; i++) { 
    Console.WriteLine("> Enter Direction and Steps(eg: N 1):");
    commandHandler.AddInput(Console.ReadLine());
}
Console.WriteLine("Input complete. Press any key to continue..");

Robot robot = new Robot(commandHandler);

Console.WriteLine("Robot is cleaning ..");
robot.Execute();

Console.WriteLine(robot.ShowResult());
Console.ReadLine();
