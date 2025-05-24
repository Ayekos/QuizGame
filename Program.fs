open Quiz
open System

[<EntryPoint>]
let main argv =
    let questions = loadQuestions "questions.json" |> shuffleQuestions |> List.truncate 10
    Console.ForegroundColor <- ConsoleColor.Cyan
    printfn "Welcome to Quiz Game!"
    Console.ResetColor()

    let score = 
        questions 
        |> List.map askQuestion 
        |> List.sum

    Console.ForegroundColor <- ConsoleColor.Blue
    printfn "\nGame over! Score: %d/%d\n" score questions.Length
    Console.ResetColor()
    0