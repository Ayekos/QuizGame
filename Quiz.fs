module Quiz

open System
open System.IO
open Newtonsoft.Json

type Question = {
    question: string
    options: string[]
    answer: int
}

let loadQuestions (path: string) =
    let json = File.ReadAllText(path)
    JsonConvert.DeserializeObject<Question list>(json)

let shuffleQuestions (questions: Question list) : Question list =
    let rnd = System.Random()
    questions |> List.sortBy (fun _ -> rnd.Next())

let askQuestion (q: Question) =
    printfn "\n%s" q.question
    q.options
    |> Array.iteri (fun i opt -> printfn "%d) %s" (i + 1) opt)

    printf "Answer (1-%d): " q.options.Length
    match System.Int32.TryParse(System.Console.ReadLine()) with
    | (true, choice) when choice - 1 = q.answer ->
        Console.ForegroundColor <- ConsoleColor.Green
        printfn "CORRECT!"
        Console.ResetColor()
        1
    | _ ->
        Console.ForegroundColor <- ConsoleColor.Red
        printfn "WRONG! The right answer is: %s" q.options.[q.answer]
        Console.ResetColor()
        0