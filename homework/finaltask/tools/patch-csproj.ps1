$ErrorActionPreference = 'Stop'

$p = Join-Path $PSScriptRoot '..\task.csproj'
$xml = [xml](Get-Content -Raw $p)
$ns = New-Object System.Xml.XmlNamespaceManager($xml.NameTable)
$ns.AddNamespace('msb','http://schemas.microsoft.com/developer/msbuild/2003')

$refIg = $xml.SelectSingleNode("//msb:Project/msb:ItemGroup[msb:Reference]", $ns)
if (-not $refIg) { throw 'No Reference ItemGroup' }

$exists = $refIg.SelectSingleNode("msb:Reference[@Include='System.Windows.Forms.DataVisualization']", $ns)
if (-not $exists) {
  $n = $xml.CreateElement('Reference', $xml.Project.NamespaceURI)
  $n.SetAttribute('Include', 'System.Windows.Forms.DataVisualization')
  [void]$refIg.AppendChild($n)
}

$compileIg = $xml.SelectSingleNode("//msb:Project/msb:ItemGroup[msb:Compile]", $ns)
if (-not $compileIg) { throw 'No Compile ItemGroup' }

function EnsureCompile([string]$inc) {
  $node = $compileIg.SelectSingleNode("msb:Compile[@Include='$inc']", $ns)
  if (-not $node) {
    $n = $xml.CreateElement('Compile', $xml.Project.NamespaceURI)
    $n.SetAttribute('Include', $inc)
    [void]$compileIg.AppendChild($n)
  }
}

EnsureCompile 'AppPaths.cs'
EnsureCompile 'TelemetryRepository.cs'
EnsureCompile 'TelemetrySample.cs'
EnsureCompile 'TelemetryService.cs'

$noneIg = $xml.SelectSingleNode("//msb:Project/msb:ItemGroup[msb:None]", $ns)
if ($noneIg) {
  $pnode = $noneIg.SelectSingleNode("msb:None[@Include='packages.config']", $ns)
  if (-not $pnode) {
    $n = $xml.CreateElement('None', $xml.Project.NamespaceURI)
    $n.SetAttribute('Include', 'packages.config')
    [void]$noneIg.AppendChild($n)
  }
}

$xml.Save($p)
Write-Host 'Patched task.csproj'
