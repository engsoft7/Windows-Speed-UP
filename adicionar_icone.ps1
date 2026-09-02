$dir = "C:\Users\HP\.gemini\antigravity-ide\scratch\OtimizadorCPU"
Set-Location $dir

# Mata o processo se estiver rodando para permitir que o compilador substitua o .exe
Stop-Process -Name "UltraOptimizer" -Force -ErrorAction SilentlyContinue

Add-Type -AssemblyName System.Drawing
$bmp = New-Object System.Drawing.Bitmap 64, 64
$g = [System.Drawing.Graphics]::FromImage($bmp)
$g.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
$g.Clear([System.Drawing.Color]::Transparent)

# Desenha o ícone
$g.FillEllipse([System.Drawing.Brushes]::Black, 2, 2, 60, 60)
$pen = New-Object System.Drawing.Pen ([System.Drawing.Color]::Cyan), 4
$g.DrawEllipse($pen, 2, 2, 60, 60)

$font = New-Object System.Drawing.Font "Impact", 22
$g.DrawString("IA", $font, [System.Drawing.Brushes]::Cyan, 14, 14)

$icon = [System.Drawing.Icon]::FromHandle($bmp.GetHicon())
$fs = New-Object System.IO.FileStream "icone.ico", Create
$icon.Save($fs)
$fs.Close()

# Compila
& C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /win32icon:icone.ico /out:UltraOptimizer.exe UltraIA.cs
