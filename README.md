# Ansi-Ascii

This repo showcases ANSI escape codes through the use of ASCII art. **Ascii** and **Gallery** are both runnable, while **Selector** is a dependency used by the latter. This repo is buildable via Visual Studio or Visual Studio Code: simply open the solution file in Visual Studio or the root folder in Code.

## Prerequisites

- Visual Studio or Visual Studio Code
- .NET 10 SDK or later

# Projects

## Ascii

A simple program that displays an [ASCII artwork of fire](https://ascii-motion.app/community/project/44870d67-36e2-4e2a-a6de-96eb077c81eb), colored using ANSI escape codes.

## Selector

Provides the `ConsoleSelector` class with the `QuestionSelect` method, allowing the user to graphically answer a question by selecting between a few options stored in a `string` array.

## Gallery

A program that includes three hard-coded ASCII animations: fire, matrix rain, and rain drops. The user can also specify the frame rate at which the animation runs. The [`System.Timers.Timer`](https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer) class is used to refresh the output, overwriting the drawn frame with a new one at a constant interval that matches the aforementioned frame rate.

## [Console Formatting Presentation](https://github.com/tomczyki/Ansi-Ascii/blob/main/docs/Console%20Formatting.pdf)

A presentation regarding ANSI escape codes — what they are, how to use them, and their applications.
