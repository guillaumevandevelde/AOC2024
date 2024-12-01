open System.IO

let filePath = "C:\Develop\AOC2024\AOC2024\Puzzles\Day 1\2\input"

let parseFile (filePath: string) =
    let lines = File.ReadAllLines(filePath)
    let leftList, rightList =
        lines
        |> Array.map (fun line -> line.Split([| ' '; '\t' |], System.StringSplitOptions.RemoveEmptyEntries))
        |> Array.map (fun columns -> int columns.[0], int columns.[1])
        |> Array.unzip
    leftList, rightList
        
let leftList , rightList = parseFile filePath

//check for each number in leftlist the occurence in rightlist and store the value with occurence in a keymap
let keyMap = 
    leftList
    |> Array.map (fun x -> x, rightList |> Array.filter (fun y -> y = x) |> Array.length)
    |> Array.toSeq
    |> Map.ofSeq

//now in the leftlist multiply the value with the occurence 
let similiarityScoreList =
    leftList |> Array.map (fun x -> x * keyMap.[x])
    
let sum = Array.sum similiarityScoreList
    

 