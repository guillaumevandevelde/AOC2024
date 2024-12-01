open System.IO

let filePath = "C:\Develop\AOC2024\AOC2024\Puzzles\Day 1\1\input"

let parseFile (filePath: string) =
    let lines = File.ReadAllLines(filePath)
    let leftList, rightList =
        lines
        |> Array.map (fun line -> line.Split([| ' '; '\t' |], System.StringSplitOptions.RemoveEmptyEntries))
        |> Array.map (fun columns -> int columns.[0], int columns.[1])
        |> Array.unzip
    leftList, rightList

let leftList, rightList = parseFile filePath

let sortedLeftList = Array.sort leftList
let sortedRightList = Array.sort rightList

let differences = Array.map2 (fun x y -> abs (x - y)) sortedLeftList sortedRightList
let sum = Array.sum differences

printf $"%A{sum}"