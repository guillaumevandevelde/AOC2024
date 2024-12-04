let filePath = __SOURCE_DIRECTORY__ + @"/input1"

let corruptedMem = System.IO.File.ReadAllText(filePath)

let DoOrDontFilter (input: string) : string =
    let mutable enabled = true
    let result = System.Text.StringBuilder()
    let pattern = @"(do\(\)|don't\(\)|mul\(\d{1,3},\d{1,3}\))"
    let matches = System.Text.RegularExpressions.Regex.Matches(input, pattern)
    for m in matches do
        match m.Value with
        | "do()" -> enabled <- true
        | "don't()" -> enabled <- false
        | _ when enabled -> result.Append(m.Value) |> ignore
        | _ -> ()
    result.ToString()

let ExtractMultiplications (input: string) : (int * int)[] =
    let pattern = @"mul\((\d{1,3}),(\d{1,3})\)"
    let matches = System.Text.RegularExpressions.Regex.Matches(input, pattern)
    [| for m in matches -> (int m.Groups[1].Value, int m.Groups[2].Value) |]

let filteredMem = DoOrDontFilter corruptedMem
let result = ExtractMultiplications filteredMem
let multiplication = result |> Array.map (fun (a, b) -> a * b)

printfn $"Sum of multiplications: {Array.sum multiplication}"