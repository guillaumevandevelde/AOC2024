open System.IO

let filePath = "C:\\Develop\\AOC2024\\AOC2024\\Puzzles\\Day 2\\2\\input"

let reports = File.ReadAllLines(filePath) |>
              Array.map (fun line -> line.Split(' ') |>
                                     Array.map int |>
                                     Array.toList) |>
              Array.toList

let reportCount = reports.Length

let safetyCheck (reports: int list list) : int =
    let rec isSafe report =
        let diffs = List.pairwise report |> List.map (fun (a, b) -> b - a)
        let allIncreasing = List.forall (fun d -> d >= 1 && d <= 3) diffs
        let allDecreasing = List.forall (fun d -> d <= -1 && d >= -3) diffs
        if allIncreasing || allDecreasing then
            true
        else
            List.exists (fun i ->
                    let newReport = List.take i report @ List.skip (i + 1) report
                    let newDiffs = List.pairwise newReport |> List.map (fun (a, b) -> b - a)
                    let newAllIncreasing = List.forall (fun d -> d >= 1 && d <= 3) newDiffs
                    let newAllDecreasing = List.forall (fun d -> d <= -1 && d >= -3) newDiffs
                    newAllIncreasing || newAllDecreasing
                ) [0..(List.length report - 1)]

    reports |> List.filter isSafe |> List.length

let safeReportsCount = safetyCheck reports
printfn $"Number of safe reports: %d{safeReportsCount}"