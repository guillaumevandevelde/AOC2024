let filePath = __SOURCE_DIRECTORY__ + @"/input"

let corruptedMem = System.IO.File.ReadAllText(filePath)

let ExtractMultiplications (input: string) : (int * int)[] =
    let pattern = @"mul\((\d{1,3}),(\d{1,3})\)"
    let matches = System.Text.RegularExpressions.Regex.Matches(input, pattern)
    [| for m in matches -> (int m.Groups[1].Value, int m.Groups[2].Value) |]
    
let result = ExtractMultiplications corruptedMem
let multiplication = result |> Array.map (fun (a, b) -> a * b)

printfn $"Sum of multiplications: {Array.sum multiplication}"