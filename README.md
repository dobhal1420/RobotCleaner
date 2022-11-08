# RobotCleaner

Robot cleaner is a simple Console App to implement a Cleaner Prototype.
This Application consists of "RobotCleanerCore" Assembly which has all the logic.


## Contents
  * [Project Architecture](#project-architecture)
  * [Code Flow](#code-flow)
  * [Tests](#tests)

## Project Architecture

TODO

## Code Flow

  * There are 3 sections of the code 
    - InputHandler
    - NavigationCommandManager
    - MovementTracker
    - Robot

#### InputHandler: 
  * Takes Number of command input within a limit.

#### NavigationCommandManager
  * Takes all commands and Parse it.

#### MovementTracker
  * Act on the commands passed and moves robot within a range.
  * Return result.

#### Robot
  * Actual object which show the result - Number
