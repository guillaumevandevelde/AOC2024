1..24 | ForEach-Object {
    $dayFolder = "C:\develop\AOC2024\AOC2024\Puzzles\Day $_"
    New-Item -ItemType Directory -Path $dayFolder -Force | Out-Null
    "1.fsx","2.fsx","input1","input2","Assignment1.md","Assignment2.md" | ForEach-Object {
        New-Item -ItemType File -Path (Join-Path $dayFolder $_) -Force | Out-Null
    }
}