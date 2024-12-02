open System.IO

let filePath = "C:\Develop\AOC2024\AOC2024\Puzzles\Day 2\1\input"

let reports = File.ReadAllLines(filePath) |>
              Array.map (fun line -> line.Split(' ') |>
                                     Array.map int |>
                                     Array.toList) |>
              Array.toList              

let safetyCheck (reports: int list list) : int =
    let isSafe report =
        let diffs = List.pairwise report |> List.map (fun (a, b) -> b - a)
        let allIncreasing = List.forall (fun d -> d >= 1 && d <= 3) diffs
        let allDecreasing = List.forall (fun d -> d <= -1 && d >= -3) diffs
        allIncreasing || allDecreasing

    reports |> List.filter isSafe |> List.length

let safeReportsCount = safetyCheck reports
